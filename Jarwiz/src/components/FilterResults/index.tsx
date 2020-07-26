import React from 'react';
import {View, FlatList} from 'react-native';
import {Results, ResultsText, ResultsBtn, ResultsBtnText} from './styles';

const FilterResults: React.FC = ({errors, selectedIndex}) => {
  return (
    <View>
      <FlatList
        showsVerticalScrollIndicator={false}
        data={errors}
        keyExtractor={(item) => item.id}
        renderItem={({item}) => {
          let value;
          if (selectedIndex === 0) {
            value = item.environment;
          }
          if (selectedIndex === 1) {
            value = item.level;
          }
          if (selectedIndex === 2) {
            value = item.adress;
          }
          return (
            <Results>
              <ResultsText>{value}</ResultsText>
              <ResultsBtn>
                <ResultsBtnText>Details</ResultsBtnText>
              </ResultsBtn>
            </Results>
          );
        }}
      />
    </View>
  );
};

export default FilterResults;
