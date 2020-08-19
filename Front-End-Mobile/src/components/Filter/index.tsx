import React from 'react';
import {FilterView, ButtonsGroups} from './styles';

const Filter: React.FC = ({updateIndex, selectedIndex}) => {
  const buttons = ['Environment', 'Level', 'Address'];

  return (
    <FilterView>
      <ButtonsGroups
        onPress={updateIndex}
        selectedIndex={selectedIndex}
        buttons={buttons}
      />
    </FilterView>
  );
};

export default Filter;
