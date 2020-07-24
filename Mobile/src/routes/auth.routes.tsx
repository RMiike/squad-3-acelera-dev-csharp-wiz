import React from 'react';

import Home from '../pages/Home';
import SignIn from '../pages/SignIn';
import Register from '../pages/Register';
import ForgotPassword from '../pages/ForgotPassword';

import {createStackNavigator} from '@react-navigation/stack';

const AuthStack = createStackNavigator();

const AuthRoutes: React.FC = () => (
  <AuthStack.Navigator>
    <AuthStack.Screen
      name="Home"
      component={Home}
      options={{headerShown: false}}
    />

    <AuthStack.Screen
      name="SignIn"
      component={SignIn}
      options={{headerShown: false}}
    />
    <AuthStack.Screen
      name="Register"
      component={Register}
      options={{headerShown: false}}
    />
    <AuthStack.Screen
      name="ForgotPassword"
      component={ForgotPassword}
      options={{headerShown: false}}
    />
  </AuthStack.Navigator>
);

export default AuthRoutes;
