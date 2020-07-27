import React from 'react';
import {FlatList, View} from 'react-native';
import DashboardContentResult from './dashboardContentResult';

const DashboardContent: React.FC = ({errors}) => {
  return (
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
