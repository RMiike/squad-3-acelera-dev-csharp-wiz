import React, {useRef, useCallback} from 'react';
import {TextInput, ScrollView, Platform, Alert, StyleSheet} from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import {Form} from '@unform/mobile';
import {useNavigation} from '@react-navigation/native';
import Icon from 'react-native-vector-icons/Feather';
import getValidationErrors from '../../utils/validationError';
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
} from './styles';
import Button from '../../components/Form/Button';
import Input from '../../components/Form/Input';
import api from '../../services/api';

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
  const route = useNavigation();

  const register = useCallback(
    async ({fullName, email, password, confirmPassword}: SignUpFormData) => {
      try {
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
        route.navigate('SignIn');
      } catch (e) {
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
      <LinearGradient
        colors={[
          '#28023Dfe',
          'rgba(51, 21, 72, 0.854068)',
          'rgba(79, 69, 100, 0.9)',
        ]}
        style={styles.linearGradient}>
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
          <Button
            onPress={() => {
              formRef.current?.submitForm();
            }}>
            Enter
          </Button>
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
      </LinearGradient>
    </ScrollView>
  );
};

export default Register;
var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
    padding: '5%',
  },
});
