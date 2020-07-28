import React from 'react';
import {View, FlatList} from 'react-native';
import ActivityIndicatorComponent from '../ActivityIndicator';
import ResultsView from './results';
const FilterResults: React.FC = ({errors, selectedIndex, loading}) => {
  return loading ? (
    <ActivityIndicatorComponent />
  ) : (
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
