import React, {useRef, useCallback, useState} from 'react';
import {StatusBar, ScrollView, Platform, TextInput, Alert} from 'react-native';
import getValidationErrors from '../../../utils/validationError';
import ActivityIndicatorComponent from '../../../components/ActivityIndicator';
import api from '../../../services/api';
import {useAuth} from '../../../contexts/auth';
import PicProfile from '../../../assets/Profile.png';
import {FormHandles} from '@unform/core';
import {Form} from '@unform/mobile';
import Button from '../../../components/Form/Button';
import Menu from '../../../components/Menu';
import Input from '../../../components/Form/Input';
import {
  EveProfile,
  Title,
  ProfileDataContainer,
  Icon,
  UserData,
  Textarea,
  FormArea,
  BackgroundLinear,
} from './styles';
import * as Yup from 'yup';

interface ChangePassFormData {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
}

const Profile: React.FC = () => {
  const formRef = useRef<FormHandles>(null);
  const oldInputRef = useRef<TextInput>(null);
  const newInputRef = useRef<TextInput>(null);
  const confirmInputRef = useRef<TextInput>(null);
  const [loading, setLoading] = useState(false);
  const {user} = useAuth();

  const handleChangePassword = useCallback(async (data: ChangePassFormData) => {
    try {
      setLoading(true);
      formRef.current?.setErrors({});

      const yupSchema = Yup.object().shape({
        oldPassword: Yup.string()
          .required('Required oldPassword field')
          .min(8, 'Password should have at least 8 chars'),
        newPassword: Yup.string()
          .required('Required newPassword field')
          .min(8, 'Password should have at least 8 chars'),
        confirmPassword: Yup.string().oneOf(
          [Yup.ref('newPassword'), undefined],
          'Passwords must match',
        ),
      });

      await yupSchema.validate(data, {abortEarly: false});

      const {oldPassword, newPassword, confirmPassword} = data;
      const resp = await api.post('changepassword', {
        oldPassword,
        newPassword,
        confirmPassword,
      });
      setLoading(false);
      Alert.alert(resp.data.message);
    } catch (e) {
      setLoading(false);
      if (e instanceof Yup.ValidationError) {
        const errors = getValidationErrors(e);
        formRef.current?.setErrors(errors);
        return;
      }
      Alert.alert(
        'Invalid values',
        'Please, confirm your oldPassword and change.',
      );
    }
  }, []);

  return (
    <ScrollView
      contentContainerStyle={{flex: 1}}
      keyboardShouldPersistTaps="handled">
      <StatusBar backgroundColor="transparent" barStyle="light-content" />
      <BackgroundLinear>
        <Menu />
        <EveProfile source={PicProfile} />
        <Textarea>
          <Title>My profile</Title>
        </Textarea>
        <ProfileDataContainer>
          <Icon name="user" size={20} color="#F29657" />
          <UserData>{user?.fullName}</UserData>
        </ProfileDataContainer>
        <ProfileDataContainer>
          <Icon name="mail" size={20} color="#F29657" />
          <UserData>{user?.email}</UserData>
        </ProfileDataContainer>
        {loading ? (
          <ActivityIndicatorComponent />
        ) : (
          <FormArea
            behavior={Platform.OS === 'ios' ? 'padding' : undefined}
            enabled>
            <Form ref={formRef} onSubmit={handleChangePassword}>
              <Input
                ref={oldInputRef}
                secureTextEntry
                name="oldPassword"
                icon="lock"
                placeholder="Old Password"
                textContentType="password"
                returnKeyType="next"
                onSubmitEditing={() => oldInputRef.current?.focus()}
              />
              <Input
                ref={newInputRef}
                secureTextEntry
                name="newPassword"
                icon="lock"
                placeholder="New Password"
                textContentType="newPassword"
                returnKeyType="next"
                onSubmitEditing={() => newInputRef.current?.focus()}
              />
              <Input
                ref={confirmInputRef}
                secureTextEntry
                name="confirmPassword"
                icon="lock"
                placeholder="Confirm Password"
                textContentType="newPassword"
                returnKeyType="send"
                onSubmitEditing={() => confirmInputRef.current?.focus()}
              />
            </Form>
            <Button
              onPress={() => {
                formRef.current?.submitForm();
              }}>
              Change Password
            </Button>
          </FormArea>
        )}
      </BackgroundLinear>
    </ScrollView>
  );
};

export default Profile;
