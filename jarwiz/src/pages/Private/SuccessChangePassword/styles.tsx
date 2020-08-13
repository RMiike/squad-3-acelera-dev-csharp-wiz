import styled from 'styled-components';

export const Container = styled.div`
  width: 100vw;
  height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  color: var(--color-text-in-primary);
  background: var(--color-background-secondary);


  @media (max-width: 800px){
    background: var(--color-background-secondary);
  flex-direction: column;
  }
`

export const Content = styled.div`
display:flex;
flex-direction:column;
align-items:center;
justify-content:center;
  max-width: 550px;
  h1 {
    width:100%;
    text-align:center;
    margin-top: 20px;
    font: 700 3.4rem Montserrat;
    color: var(--color-title);
  }
  p{
    width:100%;
    text-align:center;
    font: 400 1.6rem Montserrat;
    margin-top: 20px;
    color: var(--color-text-secondary);
  }
  button {
    margin-top:40px;
    width: 50%;
  }  
`
