import React, { createContext, useContext, useReducer } from 'react'
import { Item } from '../../model/Item'
import sendRequest, { SendRequestType } from '../../util/SendRequest'
import { apiReducer } from './Api.reducer'
import { IApiProps, IApiContext, IInitialStateApiContext } from './Api.types'

const ApiContext = createContext<IApiContext>({
  loadData: () => {},
  addItem: (item: Item) => {},
  deleteItem: (itemId: string) => {},
  updateItem: (item: Item) => {},
  items: [],
})

const initialStateItems: IInitialStateApiContext = {
  items: [],
}

export const Api = (props: IApiProps) => {
  const [apiState, dispatch] = useReducer(apiReducer, initialStateItems)

  const { items } = apiState

  const loadData = async () => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Item`,
        method: 'GET',
        body: undefined,
      }

      const data = await sendRequest(request)

      const dataFormated = data.map((item: Item) => ({
        ...item,
        expirationDate: new Date(item.expirationDate),
      }))

      dispatch({ type: 'loadItems', payload: dataFormated })
    } catch (error) {
      console.error(`Error getting items -- error:${error}`)
    }
  }

  const addItem = async (item: Item) => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Item`,
        method: 'POST',
        body: JSON.stringify(item),
      }

      await sendRequest(request)
      await loadData()
    } catch (error) {
      console.error(`Error adding a item -- error:${error}`)
    }
  }

  const deleteItem = async (itemId: string) => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Item/${itemId}`,
        method: 'DELETE',
        body: undefined,
      }

      await sendRequest(request)
      await loadData()
    } catch (error) {
      console.error(`Error deleting a item -- error:${error}`)
    }
  }

  const updateItem = async (item: Item) => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}item`,
        method: 'PUT',
        body: JSON.stringify(item),
      }

      await sendRequest(request)
      await loadData()
    } catch (error) {
      console.error(`Error updating a item -- error:${error}`)
    }
  }

  return (
    <ApiContext.Provider
      value={{
        loadData,
        addItem,
        deleteItem,
        updateItem,
        items,
      }}
    >
      {props.children}
    </ApiContext.Provider>
  )
}

export const useApi = () => {
  return useContext(ApiContext)
}
