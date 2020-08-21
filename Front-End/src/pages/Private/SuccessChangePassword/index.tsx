import React from 'react';
import { Container, Content } from './styles';
import { FiCheckSquare } from 'react-icons/fi'
import Button from '../../../components/Form/Button';
import { useHistory } from 'react-router-dom';

const Success: React.FC = () => {
  const { goBack } = useHistory();
  function handlePushLoginPage() {
    goBack()
  }
  return (
    <Container>
      <Content>

        <FiCheckSquare size={100} color='#04D361 ' />
        <h1>Senha modificada com sucesso.</h1>
        <Button onClick={handlePushLoginPage}>
          Voltar
      </Button>
      </Content>
    </Container>
  );
}

export default Success;