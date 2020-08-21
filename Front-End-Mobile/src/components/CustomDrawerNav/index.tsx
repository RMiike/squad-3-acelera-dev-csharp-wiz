import React from 'react';
import {StatusBar} from 'react-native';
import {
  CustomDrawerContentScrollView,
  Container,
  DrawerContent,
  CustomDrawerContainer,
  Footer,
  TextFooter,
  CustomDrawerItems,
} from './styles';
import Icon from 'react-native-vector-icons/Feather';
import SignoutBtn from './logoutBtn';
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
          <CustomDrawerItems
            icon={({size}) => <Icon name="home" color="#fff" size={size} />}
            label="Home"
            onPress={() => {
              navigation.navigate('Dashboard');
            }}
          />
        </CustomDrawerContainer>
        <CustomDrawerContainer>
          <CustomDrawerItems
            icon={({size}) => <Icon name="list" color="#fff" size={size} />}
            label="Filters"
            onPress={() => {
              navigation.navigate('Search');
            }}
          />
        </CustomDrawerContainer>
        <CustomDrawerContainer>
          <CustomDrawerItems
            icon={({size}) => <Icon name="user" color="#fff" size={size} />}
            label="Profile"
            onPress={() => {
              navigation.navigate('Profile');
            }}
          />
        </CustomDrawerContainer>
        <SignoutBtn />
      </CustomDrawerContentScrollView>
      <Footer>
        <TextFooter>© 2020 Jarwiz.</TextFooter>
        <TextFooter> All rights reserved.</TextFooter>
      </Footer>
    </Container>
  );
};

export default CustomDrawerNav;
