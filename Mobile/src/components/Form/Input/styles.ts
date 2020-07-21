import styled, {css} from 'styled-components/native';
import FeatherIcon from 'react-native-vector-icons/Feather';

interface ContainerProps {
  Focused: boolean;
  Error: boolean;
}

export const Container = styled.View<ContainerProps>`
  flex-direction: row;
  align-items: center;
  width: 100%;
  height: 42px;
  padding: 0 16px;
  background: #ffffff;
  border-radius: 10px;
  margin-bottom: 26px;
  border-width: 2px;
  border-color: #e3d9d9;
  ${(props) =>
    props.Error &&
    css`
      border-color: #c53030;
    `}
  ${(props) =>
    props.Focused &&
    css`
      border-color: #f29657;
    `}
`;

export const Icon = styled(FeatherIcon)`
  margin-right: 16px;
`;

export const TextInput = styled.TextInput`
  flex: 1;
  color: #4f4564;
  font-size: 18px;
  font-family: 'Montserrat';
`;
