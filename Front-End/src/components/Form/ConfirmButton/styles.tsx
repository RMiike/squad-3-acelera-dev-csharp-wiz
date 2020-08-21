import styled from 'styled-components';

export const Container = styled.div`
  position: absolute;
  width: 100%;
  height:92%;
  background: var(--color-background-secondary);
  opacity: 0.9;
  border-radius: 8px;
  border: 1px solid #32264D;
  flex-direction: column;
  svg{
    margin-top: 50px;
    width:100%;
    margin-left: 250px;
  }
  p{
    margin-top: 60px;
    text-align:center;
    color:var(--color-title);
    font: 700 1.6rem Montserrat ;
  }
  button {
    margin-top: 80px;
    width: 100%;
  }
`;

