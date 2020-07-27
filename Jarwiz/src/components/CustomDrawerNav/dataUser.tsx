import React from 'react';
import {
  AvatarStyled,
  TitleStyled,
  CaptionStyled,
  UserInfoSection,
  UserInfoContainer,
  UserInfoContent,
} from './styles';
import Profile from '../../assets/Profile.png';
import {useAuth} from '../../contexts/auth';

const CustomDrawerNav: React.FC = () => {
  const {user} = useAuth();
  return (
    <UserInfoSection>
      <UserInfoContainer>
        <AvatarStyled source={Profile} size={50} />
        <UserInfoContent>
          <TitleStyled>Name: {user?.fullName}</TitleStyled>
          <CaptionStyled>Id: {user?.id}</CaptionStyled>
        </UserInfoContent>
      </UserInfoContainer>
    </UserInfoSection>
  );
};

export default CustomDrawerNav;
