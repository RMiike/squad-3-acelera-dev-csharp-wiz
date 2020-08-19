import React, { useCallback, useState, useRef } from 'react';
import { useHistory } from 'react-router-dom'
import * as Yup from 'yup';
import { useAuth } from '../../../context/auth';
import getValidationErrors from '../../../utils/validationErros';
import Input from '../../../components/Form/Input';
import Button from '../../../components/Form/Button';
import { Alert } from '@material-ui/lab'
import {
  Container,
  LogoContainer,
  FormContainer,
  Logo,
  FormContent,
  SignInTitle,
} from './styles'
import logo from '../../../assets/logo.png'
import {
  FiMail,
  FiArrowLeft
} from 'react-icons/fi'
import { FormHandles } from '@unform/core';


interface ForgotData {
  email: string;
}

const Register: React.FC = () => {
  const { forgotPassword } = useAuth();
  const formRef = useRef<FormHandles>(null);
  const { push, goBack } = useHistory();
  const [loading, setLoading] = useState(false);
  const [warning, setWarning] = useState('');

  function handleGoBack() {
    goBack();
  }

  const handleSubmit = useCallback(async (
    { email }: ForgotData) => {
    try {
      setWarning('');
      setLoading(true);
      formRef.current?.setErrors({});

      const yupSchema = Yup.object().shape(
        {
          email: Yup.string()
            .required('Required email field')
            .email('Invalid email')
        });

      await yupSchema.validate(
        { email },
        { abortEarly: false },
      );

      await forgotPassword({ email });
      setLoading(false);
      push('successforgotpassword')
    } catch (e) {
      setLoading(false);
      if (e instanceof Yup.ValidationError) {
        const errors = getValidationErrors(e);
        formRef.current?.setErrors(errors);
        return;
      }
      setWarning(e);
    }
  }, [forgotPassword, push])

  return (
    <Container>
      <FormContainer >
        <div className='icon-container' >
          <FiArrowLeft onClick={handleGoBack} size={22} color='#8257E5' />
        </div>
        <div className="alert">
          {
            warning &&
            <Alert severity="error">Email não registrado, verifique e tente novamente.</Alert>
          }
        </div>
        <FormContent ref={formRef} onSubmit={handleSubmit}>
          <SignInTitle>Forgot password</SignInTitle>

          <Input name="email" type="email" placeholder='E-mail'>
            <FiMail size={22} />
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