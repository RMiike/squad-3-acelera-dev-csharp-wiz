import React, {
  createContext,
  useState,
  useEffect,
  useContext,
  useCallback,
} from 'react';
import AsyncStorage from '@react-native-community/async-storage';
import api from '../services/api';

interface User {
  email: string;
}
interface SignInCredentials {
  email: string;
  password: string;
}
interface AuthContextData {
  signed: boolean;
  user: User | null;
  signIn(credential: SignInCredentials): Promise<void>;
  signOut(): Promise<void>;
  loading: boolean;
}
const AuthContext = createContext<AuthContextData>({} as AuthContextData);

export const AuthProvider: React.FC = ({children}) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadStorageData() {
      const storagedUser = await AsyncStorage.getItem('@JarWiz:User');
      const storagedToken = await AsyncStorage.getItem('@JarWiz:Token');
      if (storagedUser && storagedToken) {
        api.defaults.headers.Authorization = `Bearer ${storagedToken}`;
        setUser(JSON.parse(storagedUser));
      }
      setLoading(false);
    }
    loadStorageData();
  }, []);

  const signIn = useCallback(async ({email, password}) => {
    const response = await api.post('signin', {
      email,
      password,
    });
    console.log(response);
    setUser(response.data.data.email);

    api.defaults.headers.Authorization = `Bearer ${response.data.data.token}`;

    await AsyncStorage.setItem(
      '@JarWiz:User',
      JSON.stringify(response.data.data.email),
    );
    await AsyncStorage.setItem('@JarWiz:Token', response.data.data.token);
  }, []);

  async function signOut() {
    AsyncStorage.clear().then(() => {
      setUser(null);
    });
  }

  return (
    <AuthContext.Provider
      value={{signed: !!user, user, signIn, signOut, loading}}>
      {children}
    </AuthContext.Provider>
  );
};

export function useAuth() {
  return useContext(AuthContext);
}
