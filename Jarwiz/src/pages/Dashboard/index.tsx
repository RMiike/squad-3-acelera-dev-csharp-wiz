import React, {useState, useEffect} from 'react';
import LinearGradient from 'react-native-linear-gradient';
import {StatusBar, StyleSheet, Text, View} from 'react-native';
import Filter from '../../components/Filter';
import FilterResults from '../../components/FilterResults';
import {Container, Title, TitleView} from './styles';
import api from '../../services/api';

const Dashboard: React.FC = () => {
  const [errors, setErrors] = useState([]);
  const [selectedIndex, setselectedIndex] = useState(0);

  function updateIndex(selectedIndex) {
    setselectedIndex(selectedIndex);
  }

  useEffect(() => {
    async function handleFilterError() {
      const resp = await api.get('errors');
      setErrors(resp.data);
    }
    handleFilterError();
  }, []);
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
        <TitleView>
          <Title>JarWiz Search</Title>
        </TitleView>
        <Filter updateIndex={updateIndex} selectedIndex={selectedIndex} />
        <FilterResults errors={errors} selectedIndex={selectedIndex} />
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
