import styled from 'styled-components/';

export const Container = styled.div`
  display:grid;
  grid-template-columns: 1fr 2fr;
  align-items: center;
  width: 100%;
  height: 52px;
  border-radius: 8px;
  border-width: 2px;
  font: 400 1.6rem Montserrat;
  color:  var(--color-input-text);
  p {
  font: 400 1.4rem Montserrat;
  color: var(--color-input-text);
  width: 100%;

  }

`;

export const TextLabel = styled.div`
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
