import React, { useState, useEffect } from 'react';
import { useAuth } from '../../../context/auth';
import Select from '../../../components/Form/Select';
import PageHeader from '../../../components/PageHeader'
import { Container, FormPageHeader } from './styles';
import ErrorItem, { Errors } from '../../../components/ErrorItem';
import { useError } from '../../../context/error';
const Dashboard: React.FC = () => {
  const [filteredErrors, setFilteredErrors] = useState<Errors[]>([]);
  const [environment, setEnvironment] = useState('All')
  const [source, setSource] = useState('All')
  const [level, setLevel] = useState('All')
  const { user } = useAuth();
  const { errors, loading } = useError();
  useEffect(() => {
    function handleFetchFilter() {
      //#region 
      if (environment !== 'All') {
        const filtered = errors.filter(e => {
          return e.environment === environment
        })
        setFilteredErrors(filtered)
      }
      if (level !== 'All') {
        const filtered = errors.filter(e => {
          return e.level === level
        })
        setFilteredErrors(filtered)
      }
      if (source !== 'All') {
        const filtered = errors.filter(e => {
          return e.address === source
        })
        setFilteredErrors(filtered)
      }
      //#endregion
      //#region 
      if (environment !== 'All' && source !== 'All') {
        const filtered = errors.filter(e => {
          return e.environment === environment && e.address === source
        })
        setFilteredErrors(filtered)
      }
      if (environment !== 'All' && level !== 'All') {
        const filtered = errors.filter(e => {
          return e.environment === environment && e.level === level
        })
        setFilteredErrors(filtered)
      }
      if (source !== 'All' && level !== 'All') {
        const filtered = errors.filter(e => {
          return e.address === source && e.level === level
        })
        setFilteredErrors(filtered)
      }
      //#endregion
      if (source !== 'All' && level !== 'All' && environment !== 'All') {
        const filtered = errors.filter(e => {
          return e.address === source && e.level === level && e.environment === environment
        })
        setFilteredErrors(filtered)
      }
    }
    handleFetchFilter();
  }, [environment, source, level, errors])

  return (
    <Container>
      <PageHeader
        title={`Bem vindo, ${user?.fullName}`}
        description={`Token: ${user?.id}`}
      >
        <FormPageHeader>
          <Select
            label='Environment'
            name='environment'
            value={environment}
            onChange={(e) => { setEnvironment(e.target.value) }}
            options={[
              { value: 'All', label: 'All' },
              { value: 'Development', label: 'Development' },
              { value: 'Homologation', label: 'Homologation' },
              { value: 'Production', label: 'Production' },
            ]}
          />
          <Select
            label='Source'
            name='source'
            value={source}
            onChange={(e) => { setSource(e.target.value) }}
            options={[
              { value: 'All', label: 'All' },
              { value: 'Back-End', label: 'Back-End' },
              { value: 'Front-End', label: 'Front-End' },
            ]}
          />
          <Select
            label='Level'
            name='level'
            value={level}
            onChange={(e) => { setLevel(e.target.value) }}
            options={[
              { value: 'All', label: 'All' },
              { value: 'Debug', label: 'Debug' },
              { value: 'Warning', label: 'Warning' },
              { value: 'Error', label: 'Error' },
            ]}
          />

        </FormPageHeader>
      </PageHeader>

      <main>
        {
          !loading && errors.length === 0 ?
            <h1>Nenhum log de error cadastrado no momento.</h1> : ''
        }
        {
          errors.length !== 0 && filteredErrors.length === 0 && source !== 'All' && environment !== 'All' && level !== 'All' ?
            <h1>Nenhum log de error com as especificações de filtro no momento.</h1> : ''
        }
        {source === 'All' && environment === 'All' && level === 'All'
          ?
          errors.map((error: Errors) => {
            return (
              <ErrorItem key={error.id} errors={error} />
            )
          }) :
          filteredErrors.map((error: Errors) => {
            return (
              <ErrorItem key={error.id} errors={error} />
            )
          })
        }
      </main>

    </Container >
  );
}

export default Dashboard;


