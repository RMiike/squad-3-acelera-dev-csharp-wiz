import React from 'react';
import {StyleSheetProperties} from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import {useError} from '../../../contexts/error';
import {useNavigation, useRoute} from '@react-navigation/native';
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
  BtnDetails,
  DetailButton,
  UserDataView,
  UserDataName,
  UserDataId,
  Icon,
  UpdateText,
  UpdateButton,
} from './styles';

const Details: React.FC = () => {
  const navigate = useNavigation();
  const route = useRoute();
  const error = route.params.data;

  const {handleUpdate, handleDelete} = useError();

  async function handleUpdateData() {
    const {id, archived} = error;
    const resp = await handleUpdate({id, archived});
    if (resp !== undefined) {
      await navigate.goBack();
    }
  }
  async function handleDeleteData() {
    const {id} = error;
    const resp = await handleDelete({id});
    if (resp !== undefined) {
      navigate.goBack();
    }
  }
  return (
    <LinearGradient
      colors={[
        '#28023D',
        'rgba(51, 21, 72, 0.854068)',
        'rgba(79, 69, 100, 0.5)',
      ]}
      style={styles.linearGradient}>
      <Content>
        <MainContent>
          <Icon
            name="chevron-left"
            size={24}
            color="#FFF"
            onPress={() => {
              navigate.goBack();
            }}
          />
          <ErrorTitle>{error?.title}</ErrorTitle>
          <DataContent>
            <DataView>
              <DataViewTitle>Level:</DataViewTitle>
              <DataViewContent>{error?.level}</DataViewContent>
            </DataView>
            <DataView>
              <DataViewTitle>Address:</DataViewTitle>
              <DataViewContent>{error?.address}</DataViewContent>
            </DataView>
            <DataView>
              <DataViewTitle>Environment:</DataViewTitle>
              <DataViewContent>{error?.environment}</DataViewContent>
            </DataView>
          </DataContent>
          <DescriptionView>
            <Description>{error?.details}</Description>
          </DescriptionView>
        </MainContent>
        <AreaButton>
          <UpdateButton
            onPress={() => {
              handleUpdateData();
            }}>
            <UpdateText>{error?.archived ? 'Unarchive' : 'Archive'}</UpdateText>
          </UpdateButton>
          <DetailButton
            onPress={() => {
              handleDeleteData();
            }}>
            <BtnDetails>Delete</BtnDetails>
          </DetailButton>
        </AreaButton>
      </Content>
      <UserDataView>
        <UserDataName>Coletado por: {error?.fullName} </UserDataName>
        <UserDataId>Token: {error?.userId}</UserDataId>
        <UserDataId>Criado: {error?.createdAt}</UserDataId>
      </UserDataView>
    </LinearGradient>
  );
};

export default Details;

var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
  },
});
