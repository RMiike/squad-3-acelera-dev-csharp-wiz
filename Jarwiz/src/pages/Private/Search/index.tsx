import React, {useState} from 'react';
import LinearGradient from 'react-native-linear-gradient';
import {StatusBar, StyleSheet} from 'react-native';
import Filter from '../../../components/Filter';
import Menu from '../../../components/Menu';
import FilterResults from '../../../components/FilterResults';
import {Container, Title, TitleView} from './styles';
import {useError} from '../../../contexts/error';

const Search: React.FC = () => {
  const [selectedIndex, setselectedIndex] = useState(0);
  const {loading, errors} = useError();

  function updateIndex(selectedIndex) {
    setselectedIndex(selectedIndex);
  }

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
        <FilterResults
          errors={errors}
          selectedIndex={selectedIndex}
          loading={loading}
        />
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
