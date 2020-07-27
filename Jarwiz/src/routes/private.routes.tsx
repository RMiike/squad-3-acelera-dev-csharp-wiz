import React from 'react';
import Dashboard from '../pages/Private/Search';
import Details from '../pages/Private/Details';
import Search from '../pages/Private/Dashboard';
import Profile from '../pages/Private/Profile';
import CustomDrawerNav from '../components/CustomDrawerNav';
import {createDrawerNavigator} from '@react-navigation/drawer';

const PrivateDrawer = createDrawerNavigator();

const PrivateRoutes: React.FC = () => (
  <PrivateDrawer.Navigator drawerContent={CustomDrawerNav}>
    <PrivateDrawer.Screen name="Search" component={Search} />
    <PrivateDrawer.Screen name="Dashboard" component={Dashboard} />
    <PrivateDrawer.Screen name="Profile" component={Profile} />
    <PrivateDrawer.Screen name="Details" component={Details} />
  </PrivateDrawer.Navigator>
);

export default PrivateRoutes;
