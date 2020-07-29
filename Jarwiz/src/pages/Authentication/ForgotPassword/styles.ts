import styled from 'styled-components';
import {Platform} from 'react-native';
import FeatherIcon from 'react-native-vector-icons/Feather';

export const Text = styled.Text`
  font-family: 'Montserrat';
  font-size: 20px;
  font-weight: bold;
  color: #fff;
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
  background: rgba(79, 69, 100, 0.9);
  padding: 10%;
  border-radius: 15px;
  height: 300px;
  width: 100%;
`;
export const Icon = styled(FeatherIcon)`
  margin-right: 16px;
  position: absolute;
  top: 15px;
  right: 9px;
`;
export const MailIcon = styled(FeatherIcon)`
  margin-right: 16px;
`;
export const AreaInput = styled.View`
  flex-direction: row;
  align-items: center;
  width: 100%;
  height: 42px;
  padding: 0 16px;
  background: #ffffff;
  border-radius: 10px;
  margin-bottom: 26px;
  border-width: 2px;
  border-color: #f29657;
`;

export const Form = styled.View``;

export const Input = styled.TextInput`
  flex: 1;
  color: #4f4564;
  font-size: 18px;
  font-family: 'Montserrat';
`;

export const ButtonArea = styled.TouchableOpacity`
  height: 46px;
  background: #f29657;
  border-radius: 15px;
  justify-content: center;
  align-items: center;
  margin-bottom: 24px;
`;

export const ButtonText = styled.Text`
  font-family: 'Montserrat';
  color: #ffffff;
  font-size: 20px;
`;
