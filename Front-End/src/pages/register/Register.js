import React from 'react'

import { ErrorMessage, Formik, Form, Field } from 'formik'
import * as yup from 'yup'
import axios from 'axios'
import { history } from '../../history'

import './Register.css'

const Register = () => {
    const handleSubmit = values => {
        axios.post('https://centraldeerrowebapi20200718183730.azurewebsites.net/v1/register', values)
            .then(resp => {
                const { data } = resp
                if (data) {
                    history.push('/login')
                }
            })
    }

    const validations = yup.object().shape({
        email: yup.string().email().required(),
        password: yup.string().min(8).required()
    })
    return (
        <>
            <h1>Cadastro</h1>
            <Formik
                initialValues={{}}
                onSubmit={handleSubmit}
                validationSchema={validations}
            >
                <Form className="Login">
                    
                    <div className="Login-Group">
                        <Field
                            placeholder="e-mail"
                            name="email"
                            className="Login-Field"
                        />
                        <ErrorMessage
                            component="span"
                            name="email"
                            className="Login-Error"
                        />
                    </div>
                    <div className="Login-Group">
                        <Field
                            placeholder="password"
                            name="password"
                            className="Login-Field"
                        />
                        <ErrorMessage
                            component="span"
                            name="password"
                            className="Login-Error"
                        />
                    </div>
                    
                    <button className="Register-Btn" type="submit">Cadastrar</button>
                </Form>
            </Formik>
        </>
    )
}

export default Register
