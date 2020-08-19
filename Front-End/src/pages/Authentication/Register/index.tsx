import React, { useCallback, useState, useRef } from 'react';
import { useHistory } from 'react-router-dom'
import * as Yup from 'yup';
import getValidationErrors from '../../../utils/validationErros';
import { useAuth } from '../../../context/auth';
import {
  Container,
  LogoContainer,
  FormContainer,
  Logo,
  FormContent,
  SignInTitle,
} from './styles'
import Input from '../../../components/Form/Input';
import Button from '../../../components/Form/Button';
import logo from '../../../assets/logo.png'
import {
  FiMail,
  FiLock,
  FiUser,
  FiArrowLeft
} from 'react-icons/fi'
import { FormHandles } from '@unform/core';
import { Alert } from '@material-ui/lab';


interface RegisterData {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Register: React.FC = () => {
  const formRef = useRef<FormHandles>();
  const { signUp } = useAuth();
  const { push, goBack } = useHistory();
  const [warning, setWarning] = useState('');
  const [loading, setLoading] = useState(false);
  function handleGoBack() {
    goBack();
  }

  const handleSubmit = useCallback(async (
    { fullName,
      email,
      password,
      confirmPassword }: RegisterData) => {
    setWarning('')
    try {
      setLoading(true);
      formRef.current?.setErrors({});
      const yupSchema = Yup.object().shape(
        {

          fullName: Yup.string().required('Required full name field'),
          email: Yup.string()
            .required('Required email field')
            .email('Invalid email'),
          password: Yup.string()
            .required('Required password field')
            .min(8, 'Password should have at least 8 chars'),
          confirmPassword: Yup.string().oneOf(
            [Yup.ref('password'), undefined],
            'Passwords must match',
          ),
        });

      await yupSchema.validate(
        { fullName, email, password, confirmPassword },
        { abortEarly: false },
      );

      await signUp({ fullName, email, password, confirmPassword });

      setLoading(false);
      push('success');
    } catch (e) {
      setLoading(false);

      if (e instanceof Yup.ValidationError) {
        const errors = getValidationErrors(e);
        formRef.current?.setErrors(errors);
        return;
      }
      setWarning(e)
    }
  }, [push, signUp])

  return (
    <Container>
      <FormContainer>
        <div className='icon-container' >
          <FiArrowLeft onClick={handleGoBack} size={22} color='#8257E5' />
        </div>
        <div className="alert">
          {
            warning &&
            <Alert severity="error">Usuário já cadastrado.</Alert>
          }
        </div>
        <FormContent ref={formRef} onSubmit={handleSubmit}>
          <SignInTitle>Register</SignInTitle>
          <Input name="fullName" type="text" placeholder='Full Name'>
            <FiUser size={22} />
          </Input>
          <Input name="email" type="email" placeholder='E-mail'>
            <FiMail size={22} />
          </Input>
          <Input name="password" type="password" placeholder='Password'>
            <FiLock size={22} />
          </Input>
          <Input
            name="confirmPassword"
            type="password"
            placeholder='Confirm Password'
          >
            <FiLock size={22} />
          </Input>
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
      </FormContainer>
      <LogoContainer>
        <Logo src={logo} alt="jarwiz" />
      </LogoContainer>
    </Container >);
}

export default Register;