import React from 'react';
import { Container, Content } from './styles';
import { FiCheckCircle } from 'react-icons/fi'
import Button from '../../../components/Form/Button';
import { useHistory } from 'react-router-dom';

const SuccessForgotPassword: React.FC = () => {
  const { push } = useHistory();
  function handlePushLoginPage() {
    push('/')
  }
  return (
    <Container>
      <Content>

        <FiCheckCircle size={100} color='#04D361 ' />
        <h1>Redefinição de senha realizado.</h1>
        <p>Uma nova senha foi enviada para o email de cadastro. Aproveite para redefini-la na página do usuário.</p>
        <Button onClick={handlePushLoginPage}>
          Realizar login
      </Button>
      </Content>
    </Container>
  );
}

export default SuccessForgotPassword;

