import { Item } from '../../model/Item'

export interface IApiProps {
  children: any
}

export interface IApiContext {
  loadData: () => void
  addItem: (item: Item) => void
  deleteItem: (itemId: string) => void
  updateItem: (item: Item) => void
  items: Item[]
}

export interface IInitialStateApiContext {
  items: Item[]
}

export type ApiActionType =
  | { type: 'addItem'; payload: Item }
  | { type: 'deleteItem'; payload: string }
  | { type: 'updateItem'; payload: Item }
  | { type: 'loadItems'; payload: Item[] }
