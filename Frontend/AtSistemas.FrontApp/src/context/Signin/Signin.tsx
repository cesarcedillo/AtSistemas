import { createContext, useContext, useState } from 'react'
import { User } from '../../model/User'
import { Credentials } from '../../model/Credentials'
import sendRequest, { SendRequestType } from '../../util/SendRequest'
import {
  ISigninProps,
  ISigninContext,
  IInitialStateSigninContext,
} from './Signin.types'

const SigninContext = createContext<ISigninContext>({
  sendCredentials: (credentials: Credentials) => {},
  LogOut: () => {},
  user: {
    id: 0,
    firstName: '',
    lastName: '',
    userName: '',
    role: '',
    token: '',
  },
})

const initialStateItems: IInitialStateSigninContext = {
  user: {
    id: 0,
    firstName: '',
    lastName: '',
    userName: '',
    role: '',
    token: '',
  },
}

export const Signin = (props: ISigninProps) => {
  const [state, setState] = useState(initialStateItems)

  const setUser = (user: User) => {
    window.localStorage.setItem('AtSistemasUser', JSON.stringify(user))
    setState({ ...state, user: user })
  }

  const LogOut = () => {
    window.localStorage.removeItem('AtSistemasUser')
    setState(initialStateItems)
  }

  const sendCredentials = async (credentials: Credentials) => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Users/Authenticate`,
        method: 'POST',
        body: JSON.stringify(credentials),
      }

      var user = await sendRequest(request)
      setUser(user)
    } catch (error) {
      console.error(`Error login -- error:${error}`)
    }
  }

  return (
    <SigninContext.Provider
      value={{
        sendCredentials,
        LogOut,
        ...state,
      }}
    >
      {props.children}
    </SigninContext.Provider>
  )
}

export const useSignin = () => {
  return useContext(SigninContext)
}
