import { useState, ChangeEvent } from 'react'
import { Credentials } from '../model/Credentials'
import { useSignin } from '../context/Signin/Signin'
import './Login.css'

const emptyValue: Credentials = {
  username: '',
  password: '',
}

export const Login = () => {
  const [form, setForm] = useState(emptyValue)
  const { sendCredentials } = useSignin()

  const handleChange = ({ target }: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = target
    setForm({ ...form, [name]: value })
  }

  const onClick = async () => {
    sendCredentials(form)
  }

  return (
    <div className='container'>
      <div>
        <label>User Name : </label>
        <input
          type='text'
          placeholder='Enter Email'
          name='username'
          onChange={handleChange}
        />
        <label>Password : </label>
        <input
          type='password'
          placeholder='Enter Password'
          name='password'
          onChange={handleChange}
        />
        <button className='login-button' type='submit' onClick={onClick}>
          Login
        </button>
      </div>
    </div>
  )
}
