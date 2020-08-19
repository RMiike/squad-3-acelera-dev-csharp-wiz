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
  id: string;
  email: string;
  fullName: string;
}
interface SignInCredentials {
  email: string;
  password: string;
}
interface SignUpFormData {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

interface ForgotPasswordData {
  email: string;
}

interface AuthContextData {
  signed: boolean;
  user: User | null;
  signIn(credential: SignInCredentials): Promise<void>;
  signUp(credential: SignUpFormData): Promise<{}>;
  forgotPassword(credential: ForgotPasswordData): Promise<{}>;
  signOut(): Promise<void>;
  loading: boolean;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

export const AuthProvider: React.FC = ({children}) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadStorageData() {
      const storagedId = await AsyncStorage.getItem('@JarWiz:Id');
      const storagedEmail = await AsyncStorage.getItem('@JarWiz:Email');
      const storagedFullName = await AsyncStorage.getItem('@JarWiz:FullName');
      const storagedToken = await AsyncStorage.getItem('@JarWiz:Token');

      if (storagedEmail && storagedToken) {
        api.defaults.headers.Authorization = `Bearer ${storagedToken}`;
        setUser({
          id: JSON.parse(storagedId),
          fullName: JSON.parse(storagedFullName),
          email: JSON.parse(storagedEmail),
        });
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

    const {token, fullName, id} = response.data.data;

    api.defaults.headers.Authorization = `Bearer ${token}`;

    await AsyncStorage.setItem(
      '@JarWiz:Email',
      JSON.stringify(response.data.data.email),
    );
    await AsyncStorage.setItem('@JarWiz:FullName', JSON.stringify(fullName));
    await AsyncStorage.setItem('@JarWiz:Id', JSON.stringify(id));
    await AsyncStorage.setItem('@JarWiz:Token', response.data.data.token);
    setUser({id, email, fullName});
  }, []);

  async function signOut() {
    AsyncStorage.clear().then(() => {
      setUser(null);
    });
  }

  const signUp = useCallback(
    async ({email, fullName, password, confirmPassword}) => {
      const response = await api.post('register', {
        fullName,
        email,
        password,
        confirmPassword,
      });
      return response;
    },
    [],
  );

  const forgotPassword = useCallback(async ({email}) => {
    const resp = await api.post('forgotpassword', {email});
    return resp.data;
  }, []);

  return (
    <AuthContext.Provider
      value={{
        signed: !!user,
        user,
        signIn,
        signOut,
        loading,
        signUp,
        forgotPassword,
      }}>
      {children}
    </AuthContext.Provider>
  );
};

export function useAuth() {
  return useContext(AuthContext);
}
