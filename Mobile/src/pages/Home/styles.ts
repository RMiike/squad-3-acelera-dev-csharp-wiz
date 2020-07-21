import styled from 'styled-components';
import {Platform} from 'react-native';

export const Background = styled.View`
  flex: 1;
  background-color: #28023d;
`;
export const Container = styled.KeyboardAvoidingView`
  flex: 1;
  padding: 0 30px ${Platform.OS === 'android' ? 60 : 40}px;
  align-items: center;
  justify-content: space-around;
`;

export const ButtonArea = styled.View`
  align-items: center;
  width: 100%;
`;

export const Space = styled.View`
  width: 100%;
  margin: 20px;
  border: 0.5px;
  border-color: rgba(231, 233, 233, 0.4);
`;

export const LogoHome = styled.Image`
  border-width: 1px;
  padding: 30px;
  border-radius: 20px;
  border-color: #18a0fb;
`;

export const SignInButton = styled.TouchableOpacity`
  align-items: center;
  justify-content: center;
  background-color: #e7e9e9;
  height: 46px;
  width: 85%;
  border-radius: 15px;
`;
export const SignInButtonText = styled.Text`
  font-size: 25px;
  font-family: Montserrat;
`;

export const RegisterButton = styled.TouchableOpacity`
  align-items: center;
  justify-content: center;
  border: 1px;
  height: 46px;
  border-color: #e7e9e9;
  width: 85%;
  border-radius: 15px;
`;
export const RegisterButtonText = styled.Text`
  font-size: 25px;
  color: #fff;
  font-family: 'Montserrat';
`;
