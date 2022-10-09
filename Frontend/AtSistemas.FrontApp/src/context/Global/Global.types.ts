import { Item } from '../../model/Item'

export interface IGlobalProps {
  children: any
}

export interface IGlobalContext {
  setEditItem: (item: Item) => void
  editItem: Item
}

export interface IInitialStateGlobalContext {
  editItem: Item
}

export type GlobalActionType = { type: 'setEditItem'; payload: Item }
