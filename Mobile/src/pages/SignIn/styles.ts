import styled from 'styled-components';
import {Platform} from 'react-native';

export const Text = styled.Text`
  font-family: 'Montserrat';
  font-size: 25px;
  color: #fff;
  left: -80px;
  margin-left: 140px;
`;

export const Textarea = styled.KeyboardAvoidingView`
  flex: 1;
  padding: 0 30px ${Platform.OS === 'android' ? 60 : 40}px;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding: 10%;
`;

export const FormArea = styled.View`
  align-items: center;
  justify-content: center;
  height: 320px;
  background: #e7e9e9;
  padding: 10%;
  border-radius: 15px;
  width: 100%;
`;

export const ForgotPasswordButton = styled.TouchableOpacity``;

export const ForgotPasswordText = styled.Text`
  text-align: center;
  font-family: 'Montserrat';
  font-size: 15px;
  font-weight: 300;
  color: #28023dee;
`;

export const Space = styled.View`
  width: 100%;
  margin-top: 70px;
  border: 0.5px;
  border-color: rgba(231, 233, 233, 0.4);
`;

export const FinalArea = styled.View`
  align-items: center;
  justify-content: space-around;
  flex-direction: row;
  padding: 10%;
  border-radius: 15px;
  width: 100%;
`;

export const FinalText = styled.Text`
  font-family: 'Montserrat';
  font-size: 15px;
  margin-right: 120px;
  color: rgba(250, 250, 250, 0.9);
`;
export const FinalAreaTouchable = styled.TouchableOpacity``;

export const FinalAreaTouchableText = styled.Text`
  font-family: 'Montserrat';
  font-size: 17px;
  color: rgba(250, 250, 250, 0.9);
  font-weight: 700;
`;
