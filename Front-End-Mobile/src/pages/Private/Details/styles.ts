import styled from 'styled-components';
import FeatherIcon from 'react-native-vector-icons/Feather';
import LinearGradient from 'react-native-linear-gradient';

export const BackgroundLinear = styled(LinearGradient).attrs({
  colors: ['#28023D', 'rgba(51, 21, 72, 0.854068)', 'rgba(79, 69, 100, 0.5)'],
})`
  flex: 1;
`;
export const Content = styled.View`
  flex: 1;
  width: 100%;
`;

export const MainContent = styled.View`
  align-items: center;
  margin-top: 60px;
  margin-bottom: 60px;
`;

export const ErrorTitle = styled.Text`
  margin-top: 108px;
  font-size: 25px;
  font-weight: bold;
  font-family: Montserrat;
  color: #f29657;
`;

export const DataContent = styled.View`
  align-items: center;
  flex-direction: column;
  margin: 43px auto 61px;
`;

export const DataView = styled.View`
  flex-direction: row;
`;

export const ErrorId = styled.Text`
  margin-top: 58px;
  position: absolute;
  right: 60px;
  font-size: 15px;
  font-family: Montserrat;
  color: #f29657ff;
`;

export const DataViewTitle = styled.Text`
  width: 50%;
  margin-left: 60px;
  text-align: justify;
  font-size: 19px;
  font-weight: bold;
  font-family: Montserrat;
  color: #ffffffbb;
`;

export const DataViewContent = styled.Text`
  width: 50%;
  text-align: justify;
  font-size: 17px;
  font-weight: 300;
  font-family: Montserrat;
  color: #ffffff99;
`;

export const DescriptionView = styled.View`
  justify-content: center;
  align-items: center;
`;

export const Description = styled.Text`
  font-size: 25px;
  text-align: justify;
  color: #ffffff99;
  margin: 0 25px 20px;
  font-weight: 300;
  font-family: 'Montserrat';
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
  background-color: #ff000077;
  height: 30px;
  width: 141px;
`;

export const UpdateButton = styled.TouchableOpacity`
  align-items: center;
  border-width: 0.2px;
  justify-content: center;
  border-radius: 15px;
  background-color: #f2965799;
  height: 30px;
  width: 141px;
`;

export const BtnDetails = styled.Text`
  font-size: 12px;
  text-align: justify;
  margin: 0 19px;
  font-weight: 300;
  font-family: 'Montserrat';
  color: #fff;
`;
export const UpdateText = styled.Text`
  font-size: 12px;
  text-align: justify;
  margin: 0 19px;
  font-weight: 300;
  font-family: 'Montserrat';
  color: #fff;
`;

export const UserDataView = styled.View`
  width: 100%;
  margin-bottom: 61px;
  margin-left: 61px;
  flex-direction: column;
`;

export const UserDataName = styled.Text`
  font-size: 20px;
  text-align: justify;
  font-weight: bold;
  font-family: 'Montserrat';
  color: #21213399;
`;
export const UserDataId = styled.Text`
  width: 70%;
  font-size: 20px;
  text-align: justify;
  font-weight: 300;
  font-family: 'Montserrat';
  color: #21213399;
`;
export const Icon = styled(FeatherIcon)`
  position: absolute;
  left: 0;
  margin-left: 46px;
  margin-top: 36px;
`;
