import React, {useRef, useCallback} from 'react';
import {TextInput, ScrollView, Platform, Alert} from 'react-native';
import {Form} from '@unform/mobile';
import {FormHandles} from '@unform/core';
import getValidationErrors from '../../utils/validationError';
import {useAuth} from '../../contexts/auth';
import Icon from 'react-native-vector-icons/Feather';
import * as Yup from 'yup';
import {
  Background,
  Textarea,
  Text,
  FormArea,
  Space,
  FinalArea,
  FinalText,
  FinalAreaTouchable,
  FinalAreaTouchableText,
} from './styles';
import Button from '../../components/Form/Button';
import Input from '../../components/Form/Input';
import {useNavigation} from '@react-navigation/native';

interface SignInFormData {
  email: string;
  password: string;
}

const SignIn: React.FC = () => {
  const formRef = useRef<FormHandles>(null);
  const emailInputRef = useRef<TextInput>(null);
  const passwordInputRef = useRef<TextInput>(null);
  const {signIn} = useAuth();
  const route = useNavigation();

  const handleSignIn = useCallback(
    async ({email, password}: SignInFormData) => {
      try {
        formRef.current?.setErrors({});

        const yupSchema = Yup.object().shape({
          email: Yup.string()
            .required('Required email field')
            .email('Invalid email'),
          password: Yup.string()
            .required('Required password field')
            .min(8, 'Password should have at least 8 chars'),
        });

        await yupSchema.validate({email, password}, {abortEarly: false});

        await signIn({email, password});
      } catch (e) {
        console.log(e);
        if (e instanceof Yup.ValidationError) {
          const errors = getValidationErrors(e);
          formRef.current?.setErrors(errors);
          return;
        }

        Alert.alert(
          'Please, confirm your email',
          'Verify your password. Verify your user name and try again.',
        );
      }
    },
    [],
  );

  return (
    <ScrollView
      contentContainerStyle={{flex: 1}}
      keyboardShouldPersistTaps="handled">
      <Background>
        <Textarea>
          <Icon
            onPress={() => {
              route.navigate('Home');
            }}
            name="x"
            size={20}
            color="#fff"
          />
          <Text>Sign In</Text>
        </Textarea>
        <FormArea
          behavior={Platform.OS === 'ios' ? 'padding' : undefined}
          enabled>
          <Form ref={formRef} onSubmit={handleSignIn}>
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
              returnKeyType="send"
              onSubmitEditing={() => formRef.current?.submitForm()}
            />
          </Form>
          <Button
            onPress={() => {
              formRef.current?.submitForm();
            }}>
            Enter
          </Button>
        </FormArea>
        <Space />
        <FinalArea>
          <FinalText>Not a user?</FinalText>
          <FinalAreaTouchable
            onPress={() => {
              route.navigate('Register');
            }}>
            <FinalAreaTouchableText>Register</FinalAreaTouchableText>
          </FinalAreaTouchable>
        </FinalArea>
      </Background>
    </ScrollView>
  );
};

export default SignIn;
