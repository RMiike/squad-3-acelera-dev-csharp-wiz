import React from 'react';
import { Container, Content } from './styles';
import { FiCheckSquare } from 'react-icons/fi'
import Button from '../../../components/Form/Button';
import { useHistory } from 'react-router-dom';

const Success: React.FC = () => {
  const { push } = useHistory();
  function handlePushLoginPage() {
    push('/')
  }
  return (
    <Container>
      <Content>

        <FiCheckSquare size={100} color='#04D361 ' />
        <h1>Cadastro realizado com sucesso.</h1>
        <p>Antes de realizar o login, confirme o email de cadastro.</p>
        <Button onClick={handlePushLoginPage}>
          Realizar login
      </Button>
      </Content>
    </Container>
  );
}

export default Success;