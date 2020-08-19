import React, { useCallback, useState, useRef } from 'react';
import { useHistory } from 'react-router-dom'
import * as Yup from 'yup';
import getValidationErrors from '../../../utils/validationErros';
import { FiLogOut } from 'react-icons/fi'
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
import profileImg from '../../../assets/Profile.png'
import {
  FiMail,
  FiLock,
  FiUser,
  FiArrowLeft
} from 'react-icons/fi'
import { FormHandles } from '@unform/core';
import { Alert } from '@material-ui/lab';


interface ChangePasswordData {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
}

const Register: React.FC = () => {
  const formRef = useRef<FormHandles>();
  const { push, goBack } = useHistory();
  const [loading, setLoading] = useState(false);
  const [warning, setWarning] = useState('');
  const { user, changePassword, signOut } = useAuth();

  function handleGoBack() {
    goBack();
  }
  function handleLogout() {
    signOut()
    push('/')
  }

  const handleSubmit = useCallback(async (
    { oldPassword,
      newPassword,
      confirmPassword }: ChangePasswordData) => {
    setWarning('')

    try {
      setLoading(true);
      formRef.current?.setErrors({});
      const yupSchema = Yup.object().shape({
        oldPassword: Yup.string()
          .required('Required oldPassword field')
          .min(8, 'Password should have at least 8 chars'),
        newPassword: Yup.string()
          .required('Required newPassword field')
          .min(8, 'Password should have at least 8 chars'),
        confirmPassword: Yup.string().oneOf(
          [Yup.ref('newPassword'), undefined],
          'Passwords must match',
        ),
      });

      await yupSchema.validate({
        oldPassword,
        newPassword,
        confirmPassword
      }, { abortEarly: false });
      await changePassword({ oldPassword, newPassword, confirmPassword });
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
  }, [changePassword, push])

  return (
    <Container>
      <FormContainer>
        <div className='icon-container' >
          <FiArrowLeft onClick={handleGoBack} size={22} color='#8257E5' />
          <div>
            <p>Logout</p>
            <FiLogOut onClick={handleLogout} size={22} color='#8257E5' />
          </div>
        </div>
        <div className="alert">
          {
            warning &&
            <Alert severity="error">Password inválido, verifique e tente novamente.</Alert>
          }
        </div>
        <FormContent ref={formRef} onSubmit={handleSubmit}>
          <SignInTitle>Change password</SignInTitle>
          <Input name="oldPassword" type="password" placeholder='Old Password'>
            <FiUser size={22} />
          </Input>
          <Input name="newPassword" type="password" placeholder='New Passowrd'>
            <FiMail size={22} />
          </Input>
          <Input name="confirmPassword" type="password" placeholder='Confirm password'>
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
        <Logo src={profileImg} alt="jarwiz" />
        <p>Bem vindo, <strong>{user?.fullName}</strong></p>
        <p>Token: <strong>{user?.id}</strong></p>
        <p>Email: <strong>{user?.email}</strong></p>
      </LogoContainer>
    </Container >);
}

export default Register;