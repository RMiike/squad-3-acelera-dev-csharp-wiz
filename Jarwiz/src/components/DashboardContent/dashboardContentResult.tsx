import React from 'react';
import {useNavigation} from '@react-navigation/native';
import {
  Content,
  MainContent,
  ErrorTitle,
  DataContent,
  DataView,
  DataViewContent,
  DataViewTitle,
  DescriptionView,
  Description,
  AreaButton,
  Details,
  ErrorId,
  DetailButton,
} from './styles';

const DashboardContentResult: React.FC = ({data}) => {
  const navigation = useNavigation();

  function navigateToDetails() {
    navigation.navigate('Details', {data});
  }
  return (
    <Content>
      <MainContent>
        <ErrorId>{data.id}</ErrorId>
        <ErrorTitle>{data.title}</ErrorTitle>
        <DataContent>
          <DataView>
            <DataViewTitle>Level:</DataViewTitle>
            <DataViewContent>{data.level}</DataViewContent>
          </DataView>
          <DataView>
            <DataViewTitle>Address:</DataViewTitle>
            <DataViewContent>{data.address}</DataViewContent>
          </DataView>
          <DataView>
            <DataViewTitle>Environment:</DataViewTitle>
            <DataViewContent>{data.environment}</DataViewContent>
          </DataView>
        </DataContent>
        <DescriptionView>
          <Description>{data.details}</Description>
        </DescriptionView>
      </MainContent>
      <AreaButton>
        <DetailButton
          onPress={() => {
            navigateToDetails();
          }}>
          <Details>Details</Details>
        </DetailButton>
      </AreaButton>
    </Content>
  );
};

export default DashboardContentResult;
