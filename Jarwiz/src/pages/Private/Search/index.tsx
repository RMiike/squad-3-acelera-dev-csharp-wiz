import React, {useState, useEffect} from 'react';
import LinearGradient from 'react-native-linear-gradient';
import {StatusBar, StyleSheet} from 'react-native';
import Filter from '../../../components/Filter';
import Menu from '../../../components/Menu';
import FilterResults from '../../../components/FilterResults';
import {Container, Title, TitleView} from './styles';
import api from '../../../services/api';

const Search: React.FC = () => {
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
          <Title>JarWiz</Title>
        </TitleView>
        <Filter updateIndex={updateIndex} selectedIndex={selectedIndex} />
        <FilterResults errors={errors} selectedIndex={selectedIndex} />
      </Container>
    </LinearGradient>
  );
};

export default Search;

var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
  },
});
