import React from 'react';
import { Switch, Route } from 'react-router-dom'
import Dashboard from '../pages/Private/Dashboard';
import Profile from '../pages/Private/Profile';
import { ErrorProvider } from '../context/error';
import SuccessChangePassword from '../pages/Private/SuccessChangePassword';

const PrivateRoutes: React.FC = () => {
  return (
    <ErrorProvider>
      <Switch>
        <Route path='/' exact component={Dashboard} />
        <Route path='/profile' component={Profile} />
        <Route path='/success' component={SuccessChangePassword} />
      </Switch>;
    </ErrorProvider>
  )
}

export default PrivateRoutes;