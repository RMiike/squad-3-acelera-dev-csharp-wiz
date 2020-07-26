import React, {useState} from 'react';
import {ButtonGroup} from 'react-native-elements';
import {FilterView} from './styles';
// import { Container } from './styles';

const Filter: React.FC = ({updateIndex, selectedIndex}) => {
  const buttons = ['Environment', 'Level', 'Address'];

  return (
    <FilterView>
      <ButtonGroup
        onPress={updateIndex}
        selectedIndex={selectedIndex}
        buttons={buttons}
        containerStyle={{
          width: '100%',
          backgroundColor: 'transparent',
          paddingRight: 8,
          paddingLeft: 8,
        }}
        selectedButtonStyle={{backgroundColor: '#f29657', borderRadius: 15}}
        selectedTextStyle={{fontSize: 12, fontFamily: 'Montserrat'}}
        innerBorderStyle={{width: 0}}
      />
    </FilterView>
  );
};

export default Filter;
