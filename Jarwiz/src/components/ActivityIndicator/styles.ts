import styled from 'styled-components/native';
import {ActivityIndicator, Colors} from 'react-native-paper';

export const Container = styled.SafeAreaView`
  flex: 1;
  width: 100%;
  align-items: center;
  justify-content: center;
`;

export const Activity = styled(ActivityIndicator).attrs({
  animating: 'true',
  color: 'Colors.red9000',
  size: 'large',
})``;
