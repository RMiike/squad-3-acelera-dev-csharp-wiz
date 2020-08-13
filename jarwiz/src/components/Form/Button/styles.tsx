import styled from 'styled-components';

export const Container = styled.button`
  width: 100%;
  height: 46px;
  background: var(--color-button);
  border-radius: 8px;
  justify-content: center;
  align-items: center;
  margin-bottom: 24px;
  color:var(--color-text);
  font: 500 1.6rem Montserrat ;
  &:hover {
    opacity: 0.8;
    transition:  0.8s;
  }

`;

