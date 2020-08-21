import React from 'react';
import Button from '../Button'
import { FiXCircle } from 'react-icons/fi'
import { Container } from './styles';
import { useError } from '../../../context/error';

interface ConfirmButtonProps {
  id: number;
  handleConfirmDeleteData(): void;
}

const ConfirmButton: React.FC<ConfirmButtonProps> = ({ id, handleConfirmDeleteData }) => {
  const { handleDelete } = useError();

  async function handleDeleteData() {
    const resp = await handleDelete({ id });
    if (resp !== undefined) {
    }
  }
  return (
    <Container>
      <FiXCircle onClick={handleConfirmDeleteData} size={23} color='#32264D' />
      <p>
        Tem certeza que deseja excluir permanentemente este log?
      </p>
      <Button onClick={handleDeleteData} style={{ background: 'red' }}>Sim</Button>
    </Container>
  );
}

export default ConfirmButton;