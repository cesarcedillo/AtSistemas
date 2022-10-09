import { User } from '../../model/User'
import { Credentials } from '../../model/Credentials'

export interface ISigninProps {
  children: any
}

export interface ISigninContext {
  sendCredentials: (credentials: Credentials) => void
  LogOut: () => void
  user: User
}

export interface IInitialStateSigninContext {
  user: User
}
