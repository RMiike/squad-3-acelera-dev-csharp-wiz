import React from 'react';
import Dashboard from '../pages/Private/Dashboard';
import Details from '../pages/Private/Details';
import Search from '../pages/Private/Search';
import Profile from '../pages/Private/Profile';
import CustomDrawerNav from '../components/CustomDrawerNav';
import {createDrawerNavigator} from '@react-navigation/drawer';
import {ErrorProvider} from '../contexts/error';

const PrivateDrawer = createDrawerNavigator();

const PrivateRoutes: React.FC = () => (
  <ErrorProvider>
    <PrivateDrawer.Navigator drawerContent={CustomDrawerNav}>
      <PrivateDrawer.Screen name="Dashboard" component={Dashboard} />
      <PrivateDrawer.Screen name="Search" component={Search} />
      <PrivateDrawer.Screen name="Profile" component={Profile} />
      <PrivateDrawer.Screen name="Details" component={Details} />
    </PrivateDrawer.Navigator>
  </ErrorProvider>
);

export default PrivateRoutes;
