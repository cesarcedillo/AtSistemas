import { Api } from '../context/Api/Api'
import { Global } from '../context/Global/Global'
import { Form } from '../components/Form'
import { Table } from '../components/Table/Table'
import './Item.css'
import { useSignin } from '../context/Signin/Signin'

export const Items = () => {
  const { LogOut, user } = useSignin()

  const close = () => {
    LogOut()
  }

  return (
    <Global>
      <Api>
        <div className='view-items-header'>
          <h1> Items </h1>
          <button className='button' onClick={close}>
            Exit
          </button>
        </div>
        <hr></hr>
        <div className='view-items-container'>
          <div className='view-items-form'>
            {user.role === 'Admin' ? <Form /> : <div></div>}
          </div>
          <hr></hr>
          <div className='view-items-lists'>
            <Table></Table>
          </div>
        </div>
      </Api>
    </Global>
  )
}
