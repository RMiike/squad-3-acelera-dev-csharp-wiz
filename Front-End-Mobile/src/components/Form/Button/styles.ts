import styled from 'styled-components/native';
import {RectButton} from 'react-native-gesture-handler';

export const Container = styled(RectButton)`
  width: 100%;
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
