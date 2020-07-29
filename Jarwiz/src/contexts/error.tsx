import React, {
  useState,
  createContext,
  useContext,
  useEffect,
  useCallback,
} from 'react';
import api from '../services/api';
import {Alert} from 'react-native';

interface Errors {
  id: string;
  userId: string;
  fullName: string;
  title: string;
  details: string;
  createdAt: string;
  level: string;
  environment: string;
  address: string;
  archived: string;
}

interface UpdateData {
  archived: boolean;
  id: number;
}
interface DeleteData {
  id: number;
}
interface ErrorContextData {
  handleUpdate(update: UpdateData): Promise<void>;
  handleDelete(del: DeleteData): Promise<void>;
  errors: Errors;
  loading: boolean;
}

const ErrorContext = createContext<ErrorContextData>({} as ErrorContextData);

export const ErrorProvider: React.FC = ({children}) => {
  const [errors, setErrors] = useState<Errors>({} as Errors);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    handleFilterError();
  }, []);

  async function handleFilterError() {
    setLoading(true);
    const resp = await api.get('errors');
    setErrors(resp.data);
    setLoading(false);
  }
  const handleUpdate = useCallback(async ({id, archived}: UpdateData) => {
    try {
      setLoading(true);
      let resp = !archived
        ? await api.put(`error/archive/${id}`)
        : await api.put(`error/unarchive/${id}`);
      const {message} = resp.data;

      Alert.alert(`Error id:${id}`, message);
      await handleFilterError();
      setLoading(false);
      return resp.data;
    } catch (e) {
      Alert.alert('Invalid operation' + e);
      setLoading(false);

      return;
    }
  }, []);

  const handleDelete = useCallback(async ({id}: DeleteData) => {
    try {
      setLoading(true);
      const resp = await api.delete(`error/${id}`);
      const {message} = resp.data;
      Alert.alert(`Error id:${id}`, message);
      await handleFilterError();
      setLoading(false);
      return resp.data;
    } catch (e) {
      setLoading(false);
      Alert.alert('Invalid operation' + e);
      return;
    }
  }, []);

  return (
    <ErrorContext.Provider
      value={{loading, errors, handleUpdate, handleDelete}}>
      {children}
    </ErrorContext.Provider>
  );
};

export function useError() {
  return useContext(ErrorContext);
}
