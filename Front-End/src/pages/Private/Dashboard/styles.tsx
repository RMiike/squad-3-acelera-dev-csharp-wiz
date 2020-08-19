import styled from 'styled-components';

export const Container = styled.div`
    width: 100vw;
    height: 100vh;
    main {
     margin: 3.2rem auto;
     width: 90%;
    color: var(--color-title);
   }
   @media(min-width:  700px){
    max-width: 100%;
    main {
      padding: 3.2rem 0;
      max-width: 740px;
      margin: 0 auto;
      h1 {
         width:100%;
         text-align:center;
         font: 700 3.4rem Montserrat;
          color: var(--color-title);
          margin:  50px auto;
      }
    }
   }
`

export const FormPageHeader = styled.form`
   margin-top: 3.2rem;
   label {
    color: var(--color-text);
   }
   @media(min-width:  700px){
    position:absolute;
    width:100%;
    display: grid;
    grid-template-columns: repeat(3,1fr);
    column-gap: 16px;
    bottom: -28px;
    left: 50%;

   }
`