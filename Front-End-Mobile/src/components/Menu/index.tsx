import React from 'react';
import {useNavigation} from '@react-navigation/native';
import {Icon} from './styles';

const Menu: React.FC = () => {
  const navigation = useNavigation();

  return (
    <Icon
      name="menu"
      size={26}
      color="#fff"
      onPress={() => navigation.toggleDrawer()}
    />
  );
};

export default Menu;
