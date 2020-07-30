import styled from 'styled-components';

export const Content = styled.View`
  width: 100%;
  height: 270px;
  margin-top: 15px;
  border: 0.5px;
  border-radius: 15px;
  background-color: #e7e9e9;
  border-color: rgba(231, 233, 233, 1);
  align-items: center;
  justify-content: center;
  flex-direction: column;
`;

export const MainContent = styled.View`
  flex: 1;
  align-items: center;
  flex-direction: column;
`;

export const ErrorTitle = styled.Text`
  font-size: 20px;
  margin-top: 18px;
  font-weight: bold;
  font-family: Montserrat;
  color: #663e7c;
`;

export const ErrorId = styled.Text`
  margin-top: 18px;
  position: absolute;
  right: 60px;
  font-size: 15px;
  font-family: Montserrat;
  color: #f29657ff;
`;

export const DataContent = styled.View`
  align-items: center;
  flex-direction: column;
  margin: 30px 37px;
`;

export const DataView = styled.View`
  flex-direction: row;
`;

export const DataViewTitle = styled.Text`
  width: 50%;
  margin-left: 70px;
  text-align: justify;
  font-size: 15px;
  font-weight: bold;
  font-family: Montserrat;
  color: #663e7c;
`;

export const DataViewContent = styled.Text`
  width: 50%;
  text-align: justify;
  font-size: 12px;
  font-weight: 300;
  font-family: Montserrat;
  color: #663e7c;
`;

export const DescriptionView = styled.View`
  justify-content: center;
  align-items: center;
`;

export const Description = styled.Text`
  font-size: 15px;
  text-align: justify;
  margin: 0 19px;
  font-weight: 300;
  font-family: 'Montserrat';
  color: #663e7c;
`;

export const AreaButton = styled.View`
  width: 100%;
  justify-content: space-around;
  margin-bottom: 21px;
  flex-direction: row;
  align-items: center;
`;

export const DetailButton = styled.TouchableOpacity`
  align-items: center;
  border-width: 0.2px;
  justify-content: center;
  border-radius: 15px;
  background-color: #663e7c99;
  height: 30px;
  width: 141px;
`;

export const Details = styled.Text`
  font-size: 12px;
  text-align: justify;
  margin: 0 19px;
  font-weight: 300;
  font-family: 'Montserrat';
  color: #fff;
`;
