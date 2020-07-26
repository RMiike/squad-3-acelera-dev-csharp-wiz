import styled from 'styled-components';
import {DrawerContentScrollView} from '@react-navigation/drawer';

export const DrawerContent = styled(DrawerContentScrollView)`
  background-color: rgba(51, 21, 72, 0.2);
`;

export const LogoHome = styled.Image`
  width: 205px;
  height: 65px;
  border-width: 1px;
  padding: 30px;
  border-radius: 20px;
`;

export const LogoView = styled.View`
  width: 100%;
  height: 65px;
  align-items: center;
  justify-content: center;
  margin-top: 25px;
  margin-bottom: 25px;
`;
