import React, {
  createContext,
  useState,
  useEffect,
  useContext,
  useCallback,
} from 'react';
import api from '../services/api';
import { ConfirmEmailData } from '../pages/Authentication/SuccessConfirmEmail';

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
interface ChangePasswordData {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
}

interface AuthContextData {
  signed: boolean;
  user: User | null;
  signIn(credential: SignInCredentials): Promise<void>;
  signUp(credential: SignUpFormData): Promise<{}>;
  forgotPassword(credential: ForgotPasswordData): Promise<{}>;
  signOut(): Promise<void>;
  loading: boolean;
  rememberMe(credential: RememberData): Promise<void>;
  rememberData: RememberData | null;
  notRememberMe(): Promise<void>;
  changePassword(credential: ChangePasswordData): Promise<void>;
  confirmEmail(credential: ConfirmEmailData): Promise<string>;
}

interface RememberData {
  rememberEmail: string;
  rememberPassword: string;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

export const AuthProvider: React.FC = ({ children }) => {
  const [user, setUser] = useState<User | null>(null);
  const [rememberData, setRememberData] = useState<RememberData | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadStorageData() {
      const storagedId = localStorage.getItem('@JarWiz:Id');
      const storagedEmail = localStorage.getItem('@JarWiz:Email');
      const storagedFullName = localStorage.getItem('@JarWiz:FullName');
      const storagedToken = localStorage.getItem('@JarWiz:Token');
      const storagedRememberEmail = localStorage.getItem('@JarWiz:rememberEmail');
      const storagedRememberPassword = localStorage.getItem('@JarWiz:rememberPassword');

      if (storagedEmail && storagedToken) {
        api.defaults.headers.Authorization = `Bearer ${storagedToken}`;
        setUser({
          id: JSON.parse(storagedId ? storagedId : ''),
          fullName: JSON.parse(storagedFullName ? storagedFullName : ''),
          email: JSON.parse(storagedEmail),
        });
      }
      if (storagedRememberEmail && storagedRememberPassword) {
        setRememberData({
          rememberEmail: JSON.parse(storagedRememberEmail),
          rememberPassword: JSON.parse(storagedRememberPassword),
        });
      }
      setLoading(false);
    }
    loadStorageData();
  }, []);

  const signIn = useCallback(async ({ email, password }) => {
    const response = await api.post('signin', {
      email,
      password,
    });

    const { token, fullName, id } = response.data.data;

    api.defaults.headers.Authorization = `Bearer ${token}`;

    localStorage.setItem(
      '@JarWiz:Email',
      JSON.stringify(response.data.data.email),
    );
    localStorage.setItem('@JarWiz:FullName', JSON.stringify(fullName));
    localStorage.setItem('@JarWiz:Id', JSON.stringify(id));
    localStorage.setItem('@JarWiz:Token', response.data.data.token);
    setUser({ id, email, fullName });
  }, []);

  async function signOut() {
    localStorage.removeItem('@JarWiz:Id');
    localStorage.removeItem('@JarWiz:Email');
    localStorage.removeItem('@JarWiz:FullName');
    localStorage.removeItem('@JarWiz:Token');

    setUser(null);

  }

  async function notRememberMe() {
    localStorage.removeItem('@JarWiz:rememberEmail');
    localStorage.removeItem('@JarWiz:rememberPassword');
    setRememberData(null);
  }
  async function rememberMe({ rememberEmail, rememberPassword }: RememberData) {
    localStorage.setItem('@JarWiz:rememberEmail', JSON.stringify(rememberEmail));
    localStorage.setItem('@JarWiz:rememberPassword', JSON.stringify(rememberPassword));
    setRememberData({
      rememberEmail: rememberEmail,
      rememberPassword: rememberPassword,
    });
  }
  const signUp = useCallback(
    async ({ email, fullName, password, confirmPassword }) => {
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

  const forgotPassword = useCallback(async ({ email }) => {
    const resp = await api.post('forgotpassword', { email });
    return resp.data;
  }, []);

  const changePassword = useCallback(async ({ oldPassword,
    newPassword,
    confirmPassword }: ChangePasswordData) => {
    await api.post('changepassword', {
      oldPassword,
      newPassword,
      confirmPassword,
    });
  }, []);

  const confirmEmail = useCallback(async ({
    userEmail, token
  }: ConfirmEmailData) => {
    try {

      const resp = await api.get(`confirmemail?userEmail=${userEmail}&token=${token}`);

      return resp.data.message;
    } catch (e) {
      return 'Invalid token or wrong email';
    }
  }, [])
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
        rememberMe,
        rememberData,
        notRememberMe,
        changePassword,
        confirmEmail
      }}>
      {children}
    </AuthContext.Provider>
  );
};

export function useAuth() {
  return useContext(AuthContext);
}
