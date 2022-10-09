import { Items } from '../views/Items'
import { Login } from '../views/Login'
import { useSignin } from '../context/Signin/Signin'

function Main() {
  const { user } = useSignin()

  if (user.token) {
    return <Items />
  }

  return <Login />
}

export default Main
