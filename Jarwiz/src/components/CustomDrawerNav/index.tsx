import React from 'react';
import {StatusBar, Button} from 'react-native';
import Logo from '../../assets/Logo.png';
import {LogoHome, LogoView, DrawerContent} from './styles';
import {DrawerItemList} from '@react-navigation/drawer';

const CustomDrawerNav: React.FC = (props) => {
  return (
    <DrawerContent {...props}>
      <StatusBar backgroundColor="transparent" barStyle="light-content" />
      <LogoView>
        <LogoHome source={Logo} />
      </LogoView>
      <DrawerItemList {...props} />
    </DrawerContent>
  );
};

export default CustomDrawerNav;
