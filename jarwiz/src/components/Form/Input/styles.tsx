import styled from 'styled-components/';

export const Container = styled.div`
  display:grid;
  position:relative;
  grid-template-columns: 1fr 5fr;
  align-items: center;
  width: 100%;
  height: 52px;
  background: var(--color-input-background);
  border-radius: 8px;
  margin-bottom: 26px; 
  border-width: 2px;
  font: 400 1.6rem Montserrat;
  color:  var(--color-input-text);

`;

export const IconContainer = styled.div`
width:100%;
display:flex;
align-items:center;
justify-content:center;
`;

export const Content = styled.input`
  width: 100%;
  background: var(--color-input-background);
  border-width: 0;
  outline: none;
  font: 400 1.6rem Montserrat;
  color:  var(--color-input-text);
`;
