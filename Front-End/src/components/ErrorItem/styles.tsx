import styled from 'styled-components';

export const ItemBox = styled.article`
  background: #fff;
  border: 1px solid var(--color-line-in-white);
  border-radius: 0.8rem;
  overflow: hidden;
  margin-top: 2.4rem;
  display: flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;
  position:relative;
  padding:30px 30px 0;
  .colectedBy {
    width: 100%;
    margin: 20px auto;
    p {
      font: 400 1.3rem Montserrat;
      color: var(--color-title);
    }
  }
  .button-container{
    margin-top: 30px ;
    width:100%;
    display:flex;
    align-items:center;
    justify-content:space-around;
  }
  
  button {
    width: 20%;
    height: 5.6rem;

   }
  @media(min-width: 700px){
    button {
    width: 20%;
    height:46px;
   }
  }
`
export const Id = styled.p`
  position:absolute;
  right:20px;
  top:20px;
  font: 700 1.3rem Montserrat;
  color: var(--color-title);
`


export const HeaderBox = styled.div`
  display: flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;
`
export const Title = styled.strong`
  font: 700 2.3rem Montserrat;
  color: var(--color-title);
`


export const MidBox = styled.div`
  display: flex;
  width:100%;
  flex-direction:column;
  align-items:center;
  justify-content:center;
  margin-bottom: 20px;
`


export const MidBoxItem = styled.div`
  width:100%;
  display: flex;
  flex-direction:row;
  margin-bottom: 15px;
  align-items:center;
  justify-content:space-around;
  p{
    font: 400 1.6rem Montserrat;
  color: var(--color-input-text);
  }
  strong {
    font: 700 1.6rem Montserrat;
    color: var(--color-input-text);
  }
`
export const Description = styled.p`
    font: 400 1.6rem Montserrat;
    line-height: 3.3.rem;
    color: var(--color-input-text);
    text-align: justify;
`
