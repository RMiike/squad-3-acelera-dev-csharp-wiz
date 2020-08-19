import React from 'react';
import { Switch, Route } from 'react-router-dom'
import Login from '../pages/Authentication/Login';
import Register from '../pages/Authentication/Register';
import ForgotPassword from '../pages/Authentication/ForgotPassword';
import Success from '../pages/Authentication/Success';
import SuccessForgotPassword from '../pages/Authentication/SuccessForgotPassword';
import SuccessConfirmEmail from '../pages/Authentication/SuccessConfirmEmail';

const AuthRoutes: React.FC = () => {
  return (
    <Switch>
      <Route path='/' exact component={Login} />
      <Route path='/register' component={Register} />
      <Route path='/forgot_password' component={ForgotPassword} />
      <Route path='/success' component={Success} />
      <Route path='/successforgotpassword' component={SuccessForgotPassword} />
      <Route path='/successConfirmEmail/:username/:token' component={SuccessConfirmEmail} />
    </Switch>);
}

export default AuthRoutes;