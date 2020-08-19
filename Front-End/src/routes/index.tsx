import React from 'react';
import AuthRoutes from './auth';
import { useAuth } from '../context/auth';
import PrivateRoutes from './private';
import Loading from '../components/Loading';

const Routes: React.FC = () => {
  const { signed, loading } = useAuth();
  if (loading) {
    return <Loading />;
  }
  return signed ? <PrivateRoutes /> : <AuthRoutes />
}

export default Routes;