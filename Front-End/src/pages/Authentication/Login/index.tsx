import React, { useState, useCallback, useRef } from 'react';
import logo from '../../../assets/logo.png'
import { useAuth } from '../../../context/auth';
import * as Yup from 'yup'
import {
  Container,
  LogoContainer,
  FormContainer,
  Logo,
  FormContent,
  SignInTitle,
  MidleDiv,
  LinkTo
} from './styles'
import Input from '../../../components/Form/Input';
import CheckBox from '../../../components/Form/CheckBox';
import Button from '../../../components/Form/Button';
import {
  FiMail,
  FiLock
} from 'react-icons/fi'
import { FormHandles } from '@unform/core';
import getValidationErrors from '../../../utils/validationErros';
import { Alert } from '@material-ui/lab';

interface LoginData {
  email: string;
  password: string;
}


const Login: React.FC = () => {
  const formRef = useRef<FormHandles>(null);
  const { signIn, rememberMe, rememberData, notRememberMe } = useAuth();
  const [loading, setLoading] = useState(false);
  const [remember, setRemember] = useState(!!rememberData?.rememberEmail);
  const [warning, setWarning] = useState('');

  function handleCheck() {
    setRemember(!remember);
  }

  const handleSubmit = useCallback(async (data: LoginData) => {
    setWarning('');
    try {
      const { email, password } = data;
      setLoading(true);

      formRef.current?.setErrors({});

      const yupSchema = Yup.object().shape({
        email: Yup.string()
          .required('Required email field')
          .email('Invalid email'),
        password: Yup.string()
          .required('Required password field')
          .min(8, 'Password should have at least 8 chars'),
      });
      await yupSchema.validate({ email, password }, { abortEarly: false });

      await signIn({ email, password });
      if (remember) {
        await rememberMe({ rememberEmail: email, rememberPassword: password })
      } else {
        await notRememberMe();
      }
      setLoading(false);
    } catch (e) {
      setLoading(false);
      if (e instanceof Yup.ValidationError) {
        const errors = getValidationErrors(e);
        formRef.current?.setErrors(errors);
        return;
      }
      setWarning(e);
    }
  }, [notRememberMe, remember, rememberMe, signIn]);

  return (
    <Container>
      <LogoContainer>
        <Logo src={logo} alt="jarwiz" />
      </LogoContainer>
      <FormContainer>
        <div className="alert">
          {
            warning &&
            <Alert severity="error">Email não registrado ou password inválido.</Alert>
          }
        </div>
        <FormContent ref={formRef} onSubmit={handleSubmit}>
          <SignInTitle>Sign In</SignInTitle>
          <Input name="email" type="email" placeholder='E-mail' value={rememberData?.rememberEmail}>
            <FiMail size={22} />
          </Input>
          <Input name="password" type="password" placeholder='Password ' value={rememberData?.rememberPassword} >
            <FiLock size={22} />
          </Input>
          <MidleDiv>
            <CheckBox type='checkbox' name="checkbox" checked={remember} onChange={handleCheck} >
              <p>Remember-me</p>
            </CheckBox>
            <LinkTo to='/forgot_password'>
              Forgot Password
              </LinkTo>

          </MidleDiv>
          {loading ? (
            <Button disabled style={{ background: '#e7e9e9', color: '#212133' }}>
              Carregando
            </Button >
          ) : (
              <Button type="submit">
                Enter
              </Button>
            )}

        </FormContent>
        <div className='register-field'>
          <p>
            Not a user?
          </p>
          <LinkTo to='/register'>Register</LinkTo>
        </div>
      </FormContainer>
    </Container >
  );
}

export default Login;