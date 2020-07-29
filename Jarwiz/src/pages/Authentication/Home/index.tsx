import React from 'react';
import {StatusBar} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import Logo from '../../../assets/Logo.png';
import {
  Container,
  ButtonArea,
  LogoHome,
  RegisterButton,
  RegisterButtonText,
  SignInButton,
  SignInButtonText,
  BackgroundLinear,
  Space,
} from './styles';

const Home: React.FC = () => {
  const route = useNavigation();
  return (
    <BackgroundLinear>
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
    </BackgroundLinear>
  );
};

export default Home;
