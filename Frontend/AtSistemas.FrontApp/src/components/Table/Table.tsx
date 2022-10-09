import React, { useEffect } from 'react'
import { Item } from '../../model/Item'
import { useApi } from '../../context/Api/Api'
import { useGlobal } from '../../context/Global/Global'
import {
  MdModeEditOutline as Edit,
  MdDeleteOutline as Delete,
} from 'react-icons/md'
import './Table.css'
import { formatDate } from '../../util/Miscellaneous'
import { useSignin } from '../../context/Signin/Signin'

export const Table = () => {
  const { deleteItem, loadData, items } = useApi()
  const { editItem, setEditItem } = useGlobal()
  const { user } = useSignin()

  useEffect(() => {
    loadData()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  if (editItem.id !== '') {
    return (
      <div className='Editing_message'>
        <strong>EDITING...</strong>
      </div>
    )
  }

  return (
    <div className='table_container'>
      <div className='table_main'>
        <div className='table_title'>name</div>
        <div className='table_title'>Expiration Date</div>
        <div className='table_title'>Type</div>
        <div className='table_title'></div>

        {items.map((item: Item, index: number) => {
          return (
            <React.Fragment key={`row_${index}`}>
              <div className='table_item'>{item.name}</div>
              <div className='table_item'>
                {formatDate(item.expirationDate)}
              </div>
              <div className='table_item'>{item.type}</div>
              <div className='table_item'>
                {user.role === 'Admin' ? (
                  <div className='buttons-container'>
                    <button
                      className='button'
                      onClick={() => {
                        setEditItem(item)
                      }}
                    >
                      <Edit></Edit> Edit
                    </button>
                    <button
                      className='button'
                      onClick={() => {
                        deleteItem(item.id)
                      }}
                    >
                      <Delete></Delete> Delete
                    </button>
                  </div>
                ) : (
                  <div></div>
                )}
              </div>
            </React.Fragment>
          )
        })}
      </div>
    </div>
  )
}
