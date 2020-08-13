import styled from "styled-components"

export const MainDiv = styled.div`
 width: 100vw;
  height: 100vh;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  color: var(--color-text-in-primary);
  background: var(--color-background);
`

export const DotsContainer = styled.div`
height: 80%;
display: flex;
  max-height:940px;
  border-radius: 20px;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  img{
    width: 20rem;
    background-color:transparent;
    margin-right: 2.4rem;
  }
`