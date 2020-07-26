import 'react-native-gesture-handler';

import React from 'react';
import {StatusBar} from 'react-native';
import {NavigationContainer} from '@react-navigation/native';
import {AuthProvider} from './contexts/auth';

import Routes from './routes';

const App: React.FC = () => {
  return (
    <NavigationContainer>
      <AuthProvider>
        <StatusBar
          backgroundColor="#fff"
          barStyle="dark-content"
          translucent={true}
        />
        <Routes />
      </AuthProvider>
    </NavigationContainer>
  );
};

export default App;
