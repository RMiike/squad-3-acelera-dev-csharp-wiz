import styled from 'styled-components/native';

export const Container = styled.View`
  flex: 1;
  justify-content: center;
`;

export const Indicator = styled.ActivityIndicator.attrs({
  size: 'large',
})`
  color: #666;
`;
