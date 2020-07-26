import styled from 'styled-components';
import {Platform} from 'react-native';

export const Container = styled.KeyboardAvoidingView`
  flex: 1;
  padding: 0 30px ${Platform.OS === 'android' ? 60 : 40}px;
  align-items: center;
  padding-top: 190px;
`;

export const ButtonArea = styled.View`
  align-items: center;
  width: 100%;
`;

export const Filter = styled.View`
  position: absolute;
  top: 90px;
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

export const FilterBtn = styled.TouchableOpacity`
  align-items: center;
  justify-content: center;
  background-color: #f29657;
  width: 99px;
  height: 38px;
  border-radius: 15px;
`;

export const FilterText = styled.Text`
  font-size: 12px;
  font-family: Montserrat;
  color: #fff;
`;

export const ResultsText = styled.Text`
  font-size: 15px;
  font-weight: bold;
  font-family: Montserrat;
  color: #4f4564;
`;

export const ResultsBtnText = styled.Text`
  font-size: 12px;
  font-family: Montserrat;
  color: #fff;
`;
export const ResultsBtn = styled.TouchableOpacity`
  align-items: center;
  justify-content: center;
  background-color: #f29657;
  width: 99px;
  height: 38px;
  border-radius: 15px;
`;

export const Results = styled.View`
  align-items: center;
  justify-content: space-around;
  flex-direction: row;
  width: 100%;
  margin: 10px;
  border: 0.5px;
  border-radius: 15px;
  background-color: #e7e9e9;
  border-color: rgba(231, 233, 233, 1);
  height: 60px;
`;

export const FilterBtns = styled.TouchableOpacity`
  align-items: center;
  justify-content: center;
  width: 99px;
  height: 38px;
  border-radius: 15px;
`;

export const FilterTexts = styled.Text`
  font-size: 12px;
  font-family: Montserrat;
  color: #663e7c;
`;

export const Title = styled.Text`
  font-size: 20px;
  font-family: Montserrat;
  color: #e7e9e9;
`;

export const TitleView = styled.View`
  top: 60px;
  align-items: center;
  justify-content: center;
  position: absolute;
  width: 100%;
  padding-bottom: 5px;
  border-bottom-width: 0.2px;
  border-bottom-color: #e7e9e9;
`;
