import React from 'react';
import Menu from '../../../components/Menu';
import {StatusBar} from 'react-native';
import {Container, Title, TitleView, BackgroundLinear} from './styles';
import DashboardContent from '../../../components/DashboardContent';
import {useError} from '../../../contexts/error';

const Dashboard: React.FC = () => {
  const {loading, errors} = useError();

  return (
    <BackgroundLinear>
      <StatusBar backgroundColor="transparent" barStyle="light-content" />
      <Container>
        <Menu />
        <TitleView>
          <Title>JarWiz </Title>
        </TitleView>
        <DashboardContent errors={errors} loading={loading} />
      </Container>
    </BackgroundLinear>
  );
};

export default Dashboard;
