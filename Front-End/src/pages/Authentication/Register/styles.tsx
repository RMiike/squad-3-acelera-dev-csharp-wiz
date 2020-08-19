import styled from 'styled-components';
import { Form } from '@unform/web'

export const Container = styled.div`
  width: 100vw;
  height: 100vh;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  color: var(--color-text-in-primary);
  background: var(--color-background-secondary);
  @media (max-width: 800px){
    background: var(--color-background-secondary);
  flex-direction: column;
    
  }
`
export const LogoContainer = styled.div`
  width: 100%;
  height: 100%;
  background: var(--color-background);
  display: flex;
  justify-content: center;
  align-items: center;
  @media (max-width: 800px){
    background: var(--color-background-secondary);
    height: 0;

  }
`
export const Logo = styled.img`
  width: 404px;
  @media (max-width: 800px){
    width: 0;

  }

`

export const FormContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction:column;
  background: var(--color-background-secondary);
  position:relative;
  
  .icon-container {
    width:100%;
    svg {
      margin-left: 40px;
      cursor: pointer;
    }
  }
  

`

export const FormContent = styled(Form)`
  display:flex;
  flex-direction: column;
  justify-content:center;
  align-items: center;
  width: 352px;
  height: 528px;

`



export const SignInTitle = styled.h3`
  color: #32264D;
  font: 700 3.4rem Montserrat;
  margin-bottom: 37px;
`

