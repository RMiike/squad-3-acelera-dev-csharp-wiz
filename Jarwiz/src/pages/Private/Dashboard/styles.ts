import styled from 'styled-components';
import {Platform} from 'react-native';
import LinearGradient from 'react-native-linear-gradient';

export const BackgroundLinear = styled(LinearGradient).attrs({
  colors: ['#28023D', 'rgba(51, 21, 72, 0.854068)', 'rgba(79, 69, 100, 0.5)'],
})`
  flex: 1;
`;

export const Container = styled.KeyboardAvoidingView`
  flex: 1;
  padding: 0 30px ${Platform.OS === 'android' ? 60 : 40}px;
  align-items: center;
  padding-top: 120px;
`;

export const Title = styled.Text`
  font-size: 20px;
  font-family: Montserrat;
  color: #e7e9e9;
`;

export const TitleView = styled.View`
  top: 80px;
  align-items: center;
  justify-content: center;
  position: absolute;
  width: 95%;
  padding-bottom: 10px;
  border-bottom-width: 0.2px;
  border-bottom-color: #e7e9e9;
`;
