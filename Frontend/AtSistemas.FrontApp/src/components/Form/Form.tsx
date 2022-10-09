import { Item } from '../../model/Item'
import { useApi } from '../../context/Api/Api'
import { useGlobal } from '../../context/Global/Global'
import { createGuid } from '../../util/Miscellaneous'
import './Form.css'
import { useEffect, useState, ChangeEvent } from 'react'
import { formatDate } from '../../util/Miscellaneous'

const emptyValue: Item = {
  id: '',
  name: '',
  expirationDate: new Date(2000, 1, 1),
  type: '',
}

export const Form = () => {
  const [form, setForm] = useState(emptyValue)
  const { addItem, updateItem } = useApi()
  const { editItem, setEditItem } = useGlobal()

  useEffect(() => {
    setForm(editItem)
  }, [editItem])

  const handleChange = ({ target }: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = target
    setForm({ ...form, [name]: value })
  }

  const { name, expirationDate, type } = form

  const onClick = (): void => {
    if (editItem.id !== '') {
      updateItem(form)
      setEditItem(emptyValue)
    } else {
      const item: Item = {
        id: createGuid(),
        name: name,
        expirationDate: expirationDate,
        type: type,
      }
      addItem(item)
    }
    setForm(emptyValue)
  }

  return (
    <>
      <div className='form-container'>
        <div className='form-input'>
          <label className='form-label'>Name:</label>
          <input
            type='text'
            className='form-text'
            name='name'
            value={name}
            onChange={handleChange}
          ></input>
        </div>
        <div className='form-input'>
          <label className='form-label'>Expiration:</label>
          <input
            type='date'
            className='form-text'
            name='expirationDate'
            value={formatDate(expirationDate)}
            onChange={handleChange}
          ></input>
        </div>
        <div className='form-input'>
          <label className='form-label'>Type:</label>
          <input
            type='text'
            className='form-text'
            name='type'
            value={type}
            onChange={handleChange}
          ></input>
        </div>
      </div>
      <div className='form-buttons-container'>
        <button className='form-button' onClick={onClick}>
          {editItem.id !== '' ? 'Edit Item' : 'Add Item'}
        </button>
      </div>
    </>
  )
}
