import React from 'react';
import {useAuth} from '../../contexts/auth';
import {DrawerContainer, CustomDrawerItems} from './styles';
import Icon from 'react-native-vector-icons/Feather';

const SignoutBtn: React.FC = () => {
  const {signOut} = useAuth();
  return (
    <DrawerContainer>
      <CustomDrawerItems
        icon={({size}) => <Icon name="log-out" color="#fff" size={size} />}
        label="Sign Out"
        onPress={signOut}
      />
    </DrawerContainer>
  );
};

export default SignoutBtn;
