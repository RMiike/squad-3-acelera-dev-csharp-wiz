import React, { useEffect, useState } from 'react';
import { Container, Content } from './styles';
import { FiCheckSquare } from 'react-icons/fi'
import Button from '../../../components/Form/Button';
import { useHistory, RouteComponentProps } from 'react-router-dom';
import { useAuth } from '../../../context/auth';

export interface ConfirmEmailData {
  userEmail: string;
  token: string;
}
const SuccessConfirmEmail: React.FC<RouteComponentProps<any>> = (props) => {
  const [message, setMessage] = useState('');
  const { confirmEmail } = useAuth();
  const { push } = useHistory();
  function handlePushLoginPage() {
    push('/')
  }

  useEffect(() => {
    async function handleSearch() {
      const { username, token } = props.match.params

      const resp = await confirmEmail({ userEmail: username, token });

      setMessage(resp);
    }
    handleSearch()
  }, [confirmEmail, props.match.params])

  return (
    <Container>
      <Content>
        <FiCheckSquare size={100} color='#04D361 ' />
        <h1>{message && message}</h1>
        <Button onClick={handlePushLoginPage}>
          Realizar login
      </Button>
      </Content>
    </Container>
  );
}

export default SuccessConfirmEmail;