import React from 'react';
import LinearGradient from 'react-native-linear-gradient';
import Menu from '../../../components/Menu';
import {StatusBar, StyleSheet} from 'react-native';
import {Container, Title, TitleView} from './styles';
import DashboardContent from '../../../components/DashboardContent';
import {useError} from '../../../contexts/error';

const Dashboard: React.FC = () => {
  const {loading, errors} = useError();

  return (
    <LinearGradient
      colors={[
        '#28023D',
        'rgba(51, 21, 72, 0.854068)',
        'rgba(79, 69, 100, 0.5)',
      ]}
      style={styles.linearGradient}>
      <StatusBar backgroundColor="transparent" barStyle="light-content" />
      <Container>
        <Menu />
        <TitleView>
          <Title>JarWiz </Title>
        </TitleView>
        <DashboardContent errors={errors} loading={loading} />
      </Container>
    </LinearGradient>
  );
};

export default Dashboard;

var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
  },
});
