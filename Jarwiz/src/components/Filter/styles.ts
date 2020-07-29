import styled from 'styled-components';
import {ButtonGroup} from 'react-native-elements';

export const FilterView = styled.View`
  position: absolute;
  top: 105px;
  width: 100%;
  margin: 20px;
  border: 0.5px;
  border-radius: 15px;
  background-color: #e7e9e9;
  border-color: rgba(231, 233, 233, 1);
  height: 60px;
  align-items: center;
  justify-content: space-evenly;
  flex-direction: row;
`;

export const ButtonsGroups = styled(ButtonGroup).attrs({
  containerStyle: {
    width: '100%',
    backgroundColor: 'transparent',
    paddingRight: 8,
    paddingLeft: 8,
  },
  selectedButtonStyle: {
    backgroundColor: '#f29657',
    borderRadius: 15,
  },
  selectedTextStyle: {
    fontSize: 12,
    fontFamily: 'Montserrat',
  },
  innerBorderStyle: {
    width: 0,
  },
})``;
