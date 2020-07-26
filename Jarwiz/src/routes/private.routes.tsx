import React from 'react';
import Dashboard from '../pages/Dashboard';
import Search from '../pages/Search';
import Details from '../pages/Details';
import Profile from '../pages/Profile';
import CustomDrawerNav from '../components/CustomDrawerNav';
import {createDrawerNavigator} from '@react-navigation/drawer';

const PrivateDrawer = createDrawerNavigator();

const PrivateRoutes: React.FC = () => (
  <PrivateDrawer.Navigator drawerContent={CustomDrawerNav}>
    <PrivateDrawer.Screen name="Dashboard" component={Dashboard} />
    <PrivateDrawer.Screen name="Search" component={Search} />
    <PrivateDrawer.Screen name="Details" component={Details} />
    <PrivateDrawer.Screen name="Profile" component={Profile} />
  </PrivateDrawer.Navigator>
);

export default PrivateRoutes;
