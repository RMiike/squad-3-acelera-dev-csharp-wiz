import React, {useRef, useCallback, useState} from 'react';
import {TextInput, ScrollView, Platform, Alert} from 'react-native';
import ActivityIndicatorComponent from '../../../components/ActivityIndicator';
import {Form} from '@unform/mobile';
import {useNavigation} from '@react-navigation/native';
import Icon from 'react-native-vector-icons/Feather';
import getValidationErrors from '../../../utils/validationError';
import {FormHandles} from '@unform/core';
import * as Yup from 'yup';
import {
  Textarea,
  Text,
  FormArea,
  Space,
  FinalArea,
  FinalText,
  FinalAreaTouchable,
  FinalAreaTouchableText,
  BackgroundLinear,
} from './styles';
import Button from '../../../components/Form/Button';
import Input from '../../../components/Form/Input';
import api from '../../../services/api';

interface SignUpFormData {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Register: React.FC = () => {
  const formRef = useRef<FormHandles>(null);
  const emailInputRef = useRef<TextInput>(null);
  const passwordInputRef = useRef<TextInput>(null);
  const confirmPasswordInputRef = useRef<TextInput>(null);
  const [loading, setLoading] = useState(false);

  const route = useNavigation();

  const register = useCallback(
    async ({fullName, email, password, confirmPassword}: SignUpFormData) => {
      try {
        setLoading(true);

        formRef.current?.setErrors({});

        const yupSchema = Yup.object().shape({
          fullName: Yup.string().required('Required full name field'),
          email: Yup.string()
            .required('Required email field')
            .email('Invalid email'),
          password: Yup.string()
            .required('Required password field')
            .min(8, 'Password should have at least 8 chars'),
          confirmPassword: Yup.string().oneOf(
            [Yup.ref('password'), undefined],
            'Passwords must match',
          ),
        });

        await yupSchema.validate(
          {fullName, email, password, confirmPassword},
          {abortEarly: false},
        );

        const resp = await api.post('register', {
          fullName,
          email,
          password,
          confirmPassword,
        });
        Alert.alert(resp.data.message);
        setLoading(false);

        route.navigate('SignIn');
      } catch (e) {
        setLoading(false);

        if (e instanceof Yup.ValidationError) {
          const errors = getValidationErrors(e);
          formRef.current?.setErrors(errors);
          return;
        }
        Alert.alert(
          'User already exists',
          'Please, confirm your e-mail and sign in.',
        );
      }
    },
    [route],
  );

  return (
    <ScrollView
      contentContainerStyle={{flex: 1}}
      keyboardShouldPersistTaps="handled">
      <BackgroundLinear>
        <Textarea>
          <Icon
            onPress={() => {
              route.navigate('Home');
            }}
            name="x"
            size={20}
            color="#fff"
          />

          <Text>Register</Text>
        </Textarea>

        <FormArea
          behavior={Platform.OS === 'ios' ? 'padding' : undefined}
          enabled>
          <Form ref={formRef} onSubmit={register}>
            <Input
              autoCapitalize="words"
              name="fullName"
              icon="user"
              placeholder="Full Name"
              returnKeyType="next"
              onSubmitEditing={() => emailInputRef.current?.focus()}
            />
            <Input
              ref={emailInputRef}
              keyboardType="email-address"
              autoCorrect={false}
              autoCapitalize="none"
              name="email"
              icon="mail"
              placeholder="E-mail"
              returnKeyType="next"
              onSubmitEditing={() => passwordInputRef.current?.focus()}
            />
            <Input
              ref={passwordInputRef}
              secureTextEntry
              name="password"
              icon="lock"
              placeholder="Password"
              textContentType="newPassword"
              returnKeyType="next"
              onSubmitEditing={() => formRef.current?.submitForm()}
            />
            <Input
              ref={confirmPasswordInputRef}
              secureTextEntry
              name="confirmPassword"
              icon="lock"
              placeholder="Confirm Password"
              textContentType="newPassword"
              returnKeyType="send"
              onSubmitEditing={() => formRef.current?.submitForm()}
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
        <Space />
        <FinalArea>
          <FinalText>Already a member?</FinalText>
          <FinalAreaTouchable
            onPress={() => {
              route.navigate('SignIn');
            }}>
            <FinalAreaTouchableText>Sign In</FinalAreaTouchableText>
          </FinalAreaTouchable>
        </FinalArea>
      </BackgroundLinear>
    </ScrollView>
  );
};

export default Register;
