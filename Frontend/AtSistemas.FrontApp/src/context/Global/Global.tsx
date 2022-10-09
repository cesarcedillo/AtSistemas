import React, { createContext, useContext, useReducer } from 'react'
import { Item } from '../../model/Item'
import { globalReducer } from './Global.reducer'
import {
  IGlobalProps,
  IGlobalContext,
  IInitialStateGlobalContext,
} from './Global.types'

const GlobalContext = createContext<IGlobalContext>({
  setEditItem: (item: Item) => {},
  editItem: {
    id: '',
    name: '',
    expirationDate: new Date(2000, 1, 1),
    type: '',
  },
})

const initialStateItems: IInitialStateGlobalContext = {
  editItem: {
    id: '',
    name: '',
    expirationDate: new Date(2000, 1, 1),
    type: '',
  },
}

export const Global = (props: IGlobalProps) => {
  const [globalState, dispatch] = useReducer(globalReducer, initialStateItems)

  const setEditItem = (item: Item) => {
    dispatch({ type: 'setEditItem', payload: item })
  }

  return (
    <GlobalContext.Provider
      value={{
        setEditItem,
        ...globalState,
      }}
    >
      {props.children}
    </GlobalContext.Provider>
  )
}

export const useGlobal = () => {
  return useContext(GlobalContext)
}
