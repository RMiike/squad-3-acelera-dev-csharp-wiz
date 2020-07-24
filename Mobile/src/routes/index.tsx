import React from 'react';
import {useAuth} from '../contexts/auth';
import ActivityIndicatorComponent from '../components/ActivityIndicator';

import AuthRoutes from './auth.routes';
import PrivateRoutes from './private.routes';

const Routes: React.FC = () => {
  const {signed, loading} = useAuth();

  if (loading) {
    return <ActivityIndicatorComponent />;
  }
  return signed ? <PrivateRoutes /> : <AuthRoutes />;
};

export default Routes;
