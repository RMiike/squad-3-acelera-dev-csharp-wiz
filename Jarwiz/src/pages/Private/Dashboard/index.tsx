import React, {useState, useEffect} from 'react';
import LinearGradient from 'react-native-linear-gradient';
import Menu from '../../../components/Menu';
import {StatusBar, StyleSheet} from 'react-native';
import {Container, Title, TitleView} from './styles';
import DashboardContent from '../../../components/DashboardContent';
import api from '../../../services/api';

const Dashboard: React.FC = () => {
  const [errors, setErrors] = useState([]);

  useEffect(() => {
    async function handleFilterError() {
      const resp = await api.get('errors');
      setErrors(resp.data);
    }
    handleFilterError();
  }, [errors]);

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
        <DashboardContent errors={errors} />
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
