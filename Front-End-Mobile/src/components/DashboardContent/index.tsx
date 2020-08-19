import React from 'react';
import ActivityIndicatorComponent from '../ActivityIndicator';
import {FlatList, View} from 'react-native';
import DashboardContentResult from './dashboardContentResult';

const DashboardContent: React.FC = ({errors, loading}) => {
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
          return <DashboardContentResult data={item} />;
        }}
      />
    </View>
  );
};

export default DashboardContent;
