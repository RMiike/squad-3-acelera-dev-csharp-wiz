import React from 'react';
import Jarwiz from '../../assets/jarwiz.svg'
import { DotsContainer, MainDiv } from './styles';

const Loading: React.FC = () => {
  return (
    <MainDiv>
      <DotsContainer>
        <img src={Jarwiz} alt="" />
      </DotsContainer>
    </MainDiv>

  );
}

export default Loading;