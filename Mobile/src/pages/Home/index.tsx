import React from 'react';
import {StatusBar} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import Icon from 'react-native-vector-icons/dist/FontAwesome';

import Logo from '../../assets/Logo.png';
import {
  Background,
  Container,
  ButtonArea,
  LogoHome,
  RegisterButton,
  RegisterButtonText,
  SignInButton,
  SignInButtonText,
  Space,
} from './styles';

const Home: React.FC = () => {
  const route = useNavigation();
  return (
    <Background>
      <StatusBar backgroundColor="transparent" barStyle="light-content" />
      <Container>
        <LogoHome source={Logo} />
        <ButtonArea>
          <SignInButton
            onPress={() => {
              route.navigate('SignIn');
            }}>
            <SignInButtonText>Sign In</SignInButtonText>
          </SignInButton>
          <Space />
          <RegisterButton
            onPress={() => {
              route.navigate('Register');
            }}>
            <RegisterButtonText>Register</RegisterButtonText>
          </RegisterButton>
        </ButtonArea>
      </Container>
    </Background>
  );
};

export default Home;
