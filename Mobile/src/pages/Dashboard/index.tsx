import React from 'react';
import {Button} from 'react-native';
import styled from 'styled-components';
import {useAuth} from '../../contexts/auth';

const Dashboard: React.FC = () => {
  const {signed, signOut} = useAuth();

  function handleSignOut() {
    signOut();
    console.log(signed);
  }

  return (
    <Container>
      <Button title="Sign Out" onPress={handleSignOut} />
    </Container>
  );
};

export default Dashboard;

const Container = styled.View`
  flex: 1;
  justify-content: center;
`;
