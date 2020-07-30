import React, {useRef, useCallback, useState} from 'react';
import {ScrollView, Platform, Alert, TextInput} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import ActivityIndicatorComponent from '../../../components/ActivityIndicator';
import {FormHandles} from '@unform/core';
import getValidationErrors from '../../../utils/validationError';
import Button from '../../../components/Form/Button';
import {useAuth} from '../../../contexts/auth';
import Input from '../../../components/Form/Input';
import {Form} from '@unform/mobile';
import {Textarea, Text, FormArea, Icon, BackgroundLinear} from './styles';
import * as Yup from 'yup';

interface ForgotPasswordData {
  email: string;
}
const ForgotPassword: React.FC = () => {
  const route = useNavigation();
  const formRef = useRef<FormHandles>(null);
  const emailInputRef = useRef<TextInput>(null);
  const [loading, setLoading] = useState(false);
  const {forgotPassword} = useAuth();

  const handleForgotPassword = useCallback(
    async ({email}: ForgotPasswordData) => {
      try {
        setLoading(true);
        formRef.current?.setErrors({});

        const yupSchema = Yup.object().shape({
          email: Yup.string()
            .required('Required email field')
            .email('Invalid email'),
        });

        await yupSchema.validate({email}, {abortEarly: false});

        const resp = await forgotPassword({email});
        const {message} = resp;

        setLoading(false);

        Alert.alert('Successfuly reseted.', message);
        route.navigate('SignIn');
      } catch (e) {
        setLoading(false);
        if (e instanceof Yup.ValidationError) {
          const errors = getValidationErrors(e);
          formRef.current?.setErrors(errors);
          return;
        }
        Alert.alert('Invalid email', 'Verify your email and try again.');
      }
    },
    [forgotPassword, route],
  );

  return (
    <ScrollView
      contentContainerStyle={{flex: 1}}
      keyboardShouldPersistTaps="handled">
      <BackgroundLinear>
        <FormArea
          behavior={Platform.OS === 'ios' ? 'padding' : undefined}
          enabled>
          <Icon
            name="x"
            size={20}
            color="#fff"
            onPress={() => {
              route.goBack();
            }}
          />
          <Textarea>
            <Text>Forgot your password?</Text>
          </Textarea>
          <Form ref={formRef} onSubmit={handleForgotPassword}>
            <Input
              ref={emailInputRef}
              keyboardType="email-address"
              autoCorrect={false}
              autoCapitalize="none"
              name="email"
              icon="mail"
              placeholder="E-mail"
              returnKeyType="next"
              onSubmitEditing={() => emailInputRef.current?.focus()}
            />
          </Form>
          {loading ? (
            <ActivityIndicatorComponent />
          ) : (
            <Button
              onPress={() => {
                formRef.current?.submitForm();
              }}>
              Enter
            </Button>
          )}
        </FormArea>
      </BackgroundLinear>
    </ScrollView>
  );
};

export default ForgotPassword;
