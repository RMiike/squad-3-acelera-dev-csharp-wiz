import React from 'react';
import {View, FlatList} from 'react-native';
import ResultsView from './results';
const FilterResults: React.FC = ({errors, selectedIndex}) => {
  return (
    <View>
      <FlatList
        data={errors}
        keyExtractor={(item) => item.id.toString()}
        showsVerticalScrollIndicator={false}
        onEndReachedThreshold={0.2}
        renderItem={({item}) => {
          return <ResultsView data={item} selectedIndex={selectedIndex} />;
        }}
      />
    </View>
  );
};

export default FilterResults;
