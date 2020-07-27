import styled from 'styled-components';
import {Platform} from 'react-native';
import FeatherIcon from 'react-native-vector-icons/Feather';

export const Textarea = styled.KeyboardAvoidingView`
  justify-content: center;
  flex-direction: row;
  align-items: center;
`;

export const FormArea = styled.View`
  align-items: center;
  justify-content: center;
  width: 100%;
  margin-bottom: 135px;
`;

export const Container = styled.View`
  flex: 1;
  justify-content: center;
  padding: 0 30px ${Platform.OS === 'android' ? 60 : 40}px;
`;

export const EveProfile = styled.Image`
  width: 186px;
  height: 186px;
  border-radius: 98px;
  margin-top: 32px;
  align-self: center;
`;
export const Title = styled.Text`
  font-size: 20px;
  color: rgba(250, 250, 250, 0.9);
  font-family: 'Montserrat';
  font-weight: bold;
  margin: 24px 0;
`;

export const ProfileDataContainer = styled.View`
  flex-direction: row;
  align-items: center;
  width: 100%;
  height: 42px;
  padding: 0 16px;
  border-radius: 10px;
`;

export const UserData = styled.Text`
  color: #fff;
  font-size: 18px;
  font-family: 'Montserrat';
`;
export const Icon = styled(FeatherIcon)`
  margin-right: 16px;
`;
