import React from 'react';
import LinearGradient from 'react-native-linear-gradient';
import {StatusBar, StyleSheet} from 'react-native';
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
  Space,
} from './styles';

const Home: React.FC = () => {
  const route = useNavigation();
  return (
    <LinearGradient
      colors={[
        '#28023D',
        'rgba(51, 21, 72, 0.854068)',
        'rgba(79, 69, 100, 0.5)',
      ]}
      style={styles.linearGradient}>
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
    </LinearGradient>
  );
};

export default Home;

var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
  },
});
