import styled from 'styled-components';

export const Header = styled.header`
  display: flex;
  background-color: var(--color-background);
  flex-direction:column;

  @media(min-width: 700px){
    height: 200px;
  flex-direction: row;
  }
`


export const Content = styled.div`
  width: 90%;
  margin: 0 auto;
  
  position: relative;
  margin: 3.2rem auto;
  strong {
    font: 700 1.9rem Montserrat;
    line-height: 4.2rem;
    color: var(--color-text);
    margin-left: 30px;
    text-align: left;
    max-width:100%;
  }
  p{
    max-width: 30rem;

    margin-left: 30px;

    font-size: 1.9rem;
    line-height: 2.6rem;
    color: var(--color-text);
  }

  @media(min-width: 700px){
    max-width: 740px;
    margin: 0 auto;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
    strong {
      max-width: 350px;
    }
    p{
      max-width: 30rem;
      font-size: 1.5rem;
      line-height: 2.6rem;
      color: var(--color-text);
    }
  }
`

export const TopBar = styled.div`
  position: absolute;
  top:15px;
  right:0;
  color: var(--color-text-in-primary);
  padding: 1.6rem 0;  
  a {
    text-decoration:none;
    display:flex;
    flex-direction:column;
    color: #fff;
    font: 400 1.6rem Montserrat;
  }
  svg {
    margin-right: 100px;
    border: 1px solid #fff;
    border-radius: 50%;
  }
  @media(min-width: 700px){
    width: 90%;
    position:relative;
    margin: 0 auto; 
    top:0;
    right:0;
    display: flex;
    justify-content:flex-end;
    flex-direction:row;
    align-items: center;
  }
`






