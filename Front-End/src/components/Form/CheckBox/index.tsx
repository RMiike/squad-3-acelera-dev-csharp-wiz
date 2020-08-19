import React, { InputHTMLAttributes } from 'react';
import { Container, Content, TextLabel } from './styles';

interface CheckBoxProps extends InputHTMLAttributes<HTMLInputElement> {
  name: string;
}

const CheckBox: React.FC<CheckBoxProps> = ({ name, children, ...rest }) => {
  return (
    <Container >
      <Content
        id={name}
        {...rest}
      />
      <TextLabel>
        {children}
      </TextLabel>
    </Container>
  );
}

export default CheckBox;