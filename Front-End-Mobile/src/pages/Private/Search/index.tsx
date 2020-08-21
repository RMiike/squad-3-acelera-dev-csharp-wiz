import React, {useState} from 'react';
import {StatusBar} from 'react-native';
import Filter from '../../../components/Filter';
import Menu from '../../../components/Menu';
import FilterResults from '../../../components/FilterResults';
import {Container, Title, TitleView, BackgroundLinear} from './styles';
import {useError} from '../../../contexts/error';

const Search: React.FC = () => {
  const [selectedIndex, setselectedIndex] = useState(0);
  const {loading, errors} = useError();

  function updateIndex(selectedIndex) {
    setselectedIndex(selectedIndex);
  }

  return (
    <BackgroundLinear>
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
    </BackgroundLinear>
  );
};

export default Search;
