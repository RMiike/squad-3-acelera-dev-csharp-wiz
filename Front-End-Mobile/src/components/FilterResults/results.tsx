import React from 'react';
import {useNavigation} from '@react-navigation/native';
import {Results, ResultsText, ResultsBtn, ResultsBtnText} from './styles';

const ResultsView: React.FC = ({data, selectedIndex}) => {
  const navigation = useNavigation();

  function navigateToDetails() {
    navigation.navigate('Details', {data});
  }
  let title;
  if (selectedIndex === 0) {
    title = data.environment;
  }
  if (selectedIndex === 1) {
    title = data.level;
  }
  if (selectedIndex === 2) {
    title = data.address;
  }
  return (
    <Results>
      <ResultsText>
        {data.id}- {title}
      </ResultsText>
      <ResultsBtn
        onPress={() => {
          navigateToDetails(data);
        }}>
        <ResultsBtnText>Details</ResultsBtnText>
      </ResultsBtn>
    </Results>
  );
};

export default ResultsView;
