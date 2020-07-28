import styled from 'styled-components';
import {DrawerContentScrollView} from '@react-navigation/drawer';
import {Drawer, Caption, Avatar, Title} from 'react-native-paper';

export const Container = styled.View`
  flex: 1;
`;

export const CustomDrawerContentScrollView = styled(DrawerContentScrollView)`
  background-color: #212133;
`;

export const LogoHome = styled.Image`
  width: 65px;
  height: 65px;
  border-width: 1px;
  padding: 30px;
  border-radius: 20px;
`;
export const LogoText = styled.Text`
  width: 100%;
  color: #fff;
`;

export const LogoView = styled.View`
  width: 100%;
  height: 65px;
  flex-direction: row;
  align-items: center;
  justify-content: space-evenly;
  margin-top: 25px;
  margin-bottom: 25px;
  border-bottom-width: 0.2px;
  border-bottom-color: #ffffff99;
`;

export const UserView = styled.View`
  width: 50%;
  align-items: center;
  justify-content: center;
`;

export const DrawerContainer = styled(Drawer.Section)`
  margin-bottom: 15px;
  background-color: rgba(33, 33, 51, 0.2);
  border-top-color: #f4f4f4;
  border-top-width: 1px;
`;

export const CaptionStyled = styled(Caption)`
  font-size: 14px;
  width: 80%;
  line-height: 14px;
  color: #fff;
`;

export const AvatarStyled = styled(Avatar.Image)`
  background-color: rgba(33, 33, 51, 0.2);
`;

export const TitleStyled = styled(Title)`
  font-size: 16px;
  color: #fff;
  margin-top: 3px;
  font-weight: bold;
`;

export const UserInfoSection = styled.View`
  padding-left: 20px;
`;

export const UserInfoContainer = styled.View`
  flex-direction: row;
  margin-top: 15px;
`;

export const UserInfoContent = styled.View`
  margin-left: 15px;
  flex-direction: column;
`;

export const DrawerContent = styled.View`
  flex: 1;
`;

export const CustomDrawerContainer = styled(Drawer.Section)`
  background-color: rgba(33, 33, 51, 0.2);
`;

export const Footer = styled.View`
  width: 100%;
  flex-direction: row;
  padding-bottom: 20px;
  padding-left: 30px;
  background-color: #212133;
`;

export const TextFooter = styled.Text`
  color: #fff;
`;
