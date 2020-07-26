import React, {useRef, useCallback, useState} from 'react';
import {TextInput, ScrollView, Platform, Alert, StyleSheet} from 'react-native';
import {Form} from '@unform/mobile';
import LinearGradient from 'react-native-linear-gradient';
import {FormHandles} from '@unform/core';
import ForgotPassword from '../ForgotPassword';
import getValidationErrors from '../../utils/validationError';
import {useAuth} from '../../contexts/auth';
import Icon from 'react-native-vector-icons/Feather';
import * as Yup from 'yup';
import {
  Textarea,
  Text,
  FormArea,
  ForgotPasswordButton,
  Space,
  FinalArea,
  ForgotPasswordText,
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
  const [isVisible, setVisible] = useState(false);

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

  function handleViewForgotPass() {
    setVisible(!isVisible);
  }
  return (
    <ScrollView
      contentContainerStyle={{flex: 1}}
      keyboardShouldPersistTaps="handled">
      <LinearGradient
        colors={[
          '#28023Dfe',
          'rgba(51, 21, 72, 0.854068)',
          'rgba(79, 69, 100, 0.9)',
        ]}
        style={styles.linearGradient}>
        <ForgotPassword
          isVisible={isVisible}
          handleViewForgotPass={handleViewForgotPass}
        />
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
              onSubmitEditing={() => emailInputRef.current?.focus()}
            />
            <Input
              ref={passwordInputRef}
              secureTextEntry
              name="password"
              icon="lock"
              placeholder="Password"
              textContentType="newPassword"
              returnKeyType="send"
              onSubmitEditing={() => passwordInputRef.current?.focus()}
            />
          </Form>
          <Button
            onPress={() => {
              formRef.current?.submitForm();
            }}>
            Enter
          </Button>
          <ForgotPasswordButton onPress={handleViewForgotPass}>
            <ForgotPasswordText>Forgot Password?</ForgotPasswordText>
          </ForgotPasswordButton>
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
      </LinearGradient>
    </ScrollView>
  );
};

export default SignIn;

var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
    padding: '5%',
  },
});
