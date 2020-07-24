import React from 'react';
import Dashboard from '../pages/Dashboard';
import Search from '../pages/Search';
import Details from '../pages/Details';
import Profile from '../pages/Profile';

import {createBottomTabNavigator} from '@react-navigation/bottom-tabs';

const PrivateDrawer = createBottomTabNavigator();

const PrivateRoutes: React.FC = () => (
  <PrivateDrawer.Navigator>
    {/* <PrivateDrawer.Screen name="Dashboard" component={Dashboard} />
    <PrivateDrawer.Screen name="Search" component={Search} />
    <PrivateDrawer.Screen name="Details" component={Details} /> */}
    <PrivateDrawer.Screen name="Profile" component={Profile} />
  </PrivateDrawer.Navigator>
);

export default PrivateRoutes;
