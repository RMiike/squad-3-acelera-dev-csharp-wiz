import React from 'react';
import {StatusBar, View, StyleSheet} from 'react-native';
import {
  CustomDrawerContentScrollView,
  Container,
  DrawerContent,
  CustomDrawerContainer,
} from './styles';
import Icon from 'react-native-vector-icons/Feather';
import SignoutBtn from './logoutBtn';
import {DrawerItem} from '@react-navigation/drawer';
import DataUser from './dataUser';

const CustomDrawerNav: React.FC = (props) => {
  const {navigation} = props;
  return (
    <Container>
      <CustomDrawerContentScrollView {...props}>
        <StatusBar backgroundColor="transparent" barStyle="light-content" />
        <DrawerContent>
          <DataUser />
        </DrawerContent>
        <CustomDrawerContainer>
          <DrawerItem
            labelStyle={{color: '#fff'}}
            icon={({size}) => <Icon name="home" color="#fff" size={size} />}
            label="Home"
            onPress={() => {
              navigation.navigate('Search');
            }}
          />
        </CustomDrawerContainer>
        <CustomDrawerContainer>
          <DrawerItem
            labelStyle={{color: '#fff'}}
            icon={({size}) => <Icon name="list" color="#fff" size={size} />}
            label="Filters"
            onPress={() => {
              navigation.navigate('Dashboard');
            }}
          />
        </CustomDrawerContainer>
        <CustomDrawerContainer>
          <DrawerItem
            labelStyle={{color: '#fff'}}
            icon={({size}) => <Icon name="user" color="#fff" size={size} />}
            label="Profile"
            onPress={() => {
              navigation.navigate('Profile');
            }}
          />
        </CustomDrawerContainer>
        <SignoutBtn />
      </CustomDrawerContentScrollView>
    </Container>
  );
};

export default CustomDrawerNav;

const styles = StyleSheet.create({
  section: {
    flexDirection: 'row',
    alignItems: 'center',
    marginRight: 15,
  },
  paragraph: {
    fontWeight: 'bold',
    marginRight: 3,
  },
  drawerSection: {
    marginTop: 15,
  },
  preference: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    paddingVertical: 12,
    paddingHorizontal: 16,
  },
});
