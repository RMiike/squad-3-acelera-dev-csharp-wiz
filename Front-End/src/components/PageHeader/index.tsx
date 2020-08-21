import React from 'react';
import { Header, Content, TopBar } from './styles';
import { Link } from 'react-router-dom'
import { FiUser } from 'react-icons/fi'
interface PageHeaderProps {
  title: string;
  description?: string;
}

const PageHeader: React.FC<PageHeaderProps> = ({ title, description, children }) => {
  return (
    <Header>
      <Content>
        <strong> {title}</strong>
        {description && <p> {description}</p>}
        {children}

      </Content>
      <TopBar >
        <Link to='/profile'>
          <FiUser size={40} />
          Perfil
        </Link>
      </TopBar>

    </Header>
  );
}

export default PageHeader;