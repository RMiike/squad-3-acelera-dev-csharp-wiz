import styled from 'styled-components/native';
import {ActivityIndicator} from 'react-native-paper';

export const Container = styled.SafeAreaView`
  flex: 1;
  width: 100%;
  align-items: center;
  justify-content: center;
`;

export const Activity = styled(ActivityIndicator).attrs({
  animating: true,
  color: '#f7b37e',
  size: 'large',
})``;
