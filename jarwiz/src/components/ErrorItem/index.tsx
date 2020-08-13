import React, { useState } from 'react';
import { ItemBox, HeaderBox, Title, MidBox, MidBoxItem, Description, Id } from './styles';
import Button from '../Form/Button';
import { useError } from '../../context/error';

export interface Errors {
  address: string;
  archived: boolean;
  createdAt: string;
  details: string;
  environment: string;
  fullName: string;
  id: number;
  level: string;
  title: string;
  userId: string;
}

interface ErrorsProps {
  errors: Errors;
}

const ErrorItem: React.FC<ErrorsProps> = ({ errors }) => {
  const { handleUpdate, handleDelete } = useError();
  async function handleUpdateData() {
    const { id, archived } = errors;
    const resp = await handleUpdate({ id, archived });
    if (resp !== undefined) {

    }
  }
  async function handleDeleteData() {

    const { id } = errors;
    const resp = await handleDelete({ id });
    if (resp !== undefined) {
    }
  }
  return (
    <ItemBox>
      <HeaderBox>
        <Id>Id.{errors.id}</Id>
        <Title>{errors.title} at {errors.createdAt
          .replace(/T/g, ' ')
          .substring(0, 19)
          .replace(/-/g, '/')}</Title>
        <div className='colectedBy'>
          <p>Coletado por: {errors.fullName}<br />
          Token:<strong> {errors.userId}</strong></p>
        </div>
      </HeaderBox>
      <MidBox>
        <MidBoxItem>
          <p>Level: </p><strong>{errors.level} </strong>
        </MidBoxItem>
        <MidBoxItem>
          <p>Environment: </p> <strong>{errors.environment} </strong>
        </MidBoxItem>
        <MidBoxItem>
          <p>Source:  </p><strong>{errors.address}</strong>
        </MidBoxItem>
      </MidBox>
      <Description>{errors.details}</Description>

      <div className="button-container">

        <Button onClick={handleUpdateData} style={errors.archived ? { background: '#212133aa' } : {}}>
          {
            errors.archived ? 'Desarquivar' : 'Arquivar'
          }
        </Button >

        <Button onClick={handleDeleteData}
          style={{ background: '#ff0000aa', }} >
          Deletar
        </Button >
      </div>
    </ItemBox>);
}

export default ErrorItem;