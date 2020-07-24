import React, {useRef} from 'react';
import {
  StyleSheet,
  StatusBar,
  ScrollView,
  Platform,
  TextInput,
} from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import {useAuth} from '../../contexts/auth';
import PicProfile from '../../assets/Profile.png';
import {FormHandles} from '@unform/core';
import {Form} from '@unform/mobile';
import Button from '../../components/Form/Button';
import Input from '../../components/Form/Input';
import {
  BackButton,
  EveProfile,
  Title,
  ProfileDataContainer,
  Icon,
  UserData,
  Textarea,
  FormArea,
} from './styles';

const Profile: React.FC = () => {
  const formRef = useRef<FormHandles>(null);
  const oldPasswordInputRef = useRef<TextInput>(null);
  const newPasswordInputRef = useRef<TextInput>(null);
  const confirmPasswordInputRef = useRef<TextInput>(null);

  const {signOut, user} = useAuth();
  return (
    <ScrollView
      contentContainerStyle={{flex: 1}}
      keyboardShouldPersistTaps="handled">
      <StatusBar backgroundColor="transparent" barStyle="light-content" />
      <LinearGradient
        colors={[
          '#28023Dfe',
          'rgba(51, 21, 72, 0.854068)',
          'rgba(79, 69, 100, 0.9)',
        ]}
        style={styles.linearGradient}>
        <BackButton onPress={signOut}>
          <Icon name="log-out" size={24} color="#f56c0099" />
        </BackButton>
        <EveProfile source={PicProfile} />
        <Textarea>
          <Title>My profile</Title>
        </Textarea>
        <ProfileDataContainer>
          <Icon name="user" size={20} color="#F29657" />
          <UserData>Renato Miike</UserData>
        </ProfileDataContainer>
        <ProfileDataContainer>
          <Icon name="mail" size={20} color="#F29657" />
          <UserData>{user}</UserData>
        </ProfileDataContainer>
        <FormArea
          behavior={Platform.OS === 'ios' ? 'padding' : undefined}
          enabled>
          <Form ref={formRef} onSubmit={() => {}}>
            <Input
              ref={oldPasswordInputRef}
              secureTextEntry
              name="password"
              icon="lock"
              placeholder="Old Password"
              textContentType="newPassword"
              returnKeyType="next"
              onSubmitEditing={() => formRef.current?.submitForm()}
            />
            <Input
              ref={newPasswordInputRef}
              secureTextEntry
              name="password"
              icon="lock"
              placeholder="New Password"
              textContentType="newPassword"
              returnKeyType="next"
              onSubmitEditing={() => formRef.current?.submitForm()}
            />
            <Input
              ref={confirmPasswordInputRef}
              secureTextEntry
              name="password"
              icon="lock"
              placeholder="Confirm Password"
              textContentType="newPassword"
              returnKeyType="next"
              onSubmitEditing={() => formRef.current?.submitForm()}
            />
          </Form>
          <Button
            onPress={() => {
              formRef.current?.submitForm();
            }}>
            Change Password
          </Button>
        </FormArea>
      </LinearGradient>
    </ScrollView>
  );
};

export default Profile;

var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: '5%',
  },
});
