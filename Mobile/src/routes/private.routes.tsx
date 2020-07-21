import React from 'react';
import Dashboard from '../pages/Dashboard';

import {createBottomTabNavigator} from '@react-navigation/bottom-tabs';

const PrivateBottomTab = createBottomTabNavigator();

const PrivateRoutes: React.FC = () => (
  <PrivateBottomTab.Navigator>
    <PrivateBottomTab.Screen name="Dashboard" component={Dashboard} />
  </PrivateBottomTab.Navigator>
);

export default PrivateRoutes;
