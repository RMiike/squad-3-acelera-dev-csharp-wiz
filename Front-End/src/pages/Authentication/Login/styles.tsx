import styled from 'styled-components';
import { Form } from '@unform/web'
import { Link } from 'react-router-dom'

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

`

export const FormContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  position:relative;
  flex-direction:column;
  background: var(--color-background-secondary);
  
  .register-field {
    display:flex;
    flex-direction:column;
    align-items: center;
    justify-content: center;
    p {
    font: 400  1,6rem Montserrat;
    color: #32264D;
    }
    a {
      font: 700  1,6rem Montserrat;
      font-weight:bold;
      color: #32264D;
    }
  }
  

`

export const FormContent = styled(Form)`
  display:flex;
  flex-direction: column;
  justify-content:center;
  align-items: center;
  width: 352px;
  height: 360px;
  
`



export const SignInTitle = styled.h3`
  color: #32264D;
  font: 700 3.4rem Montserrat;
  margin-bottom: 37px;
`

export const MidleDiv = styled.div`
  margin-top: -22px;
  width: 100%;
  max-height: 52px;
  display: flex;
  align-items: center;
`
export const LinkTo = styled(Link)`
  text-decoration: none;
  margin-right: 20px;
  text-align: end;
  width:100%;
  font: 400 1.4rem Montserrat;
  color: var(--color-input-text);
`