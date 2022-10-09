import { Item } from '../../model/Item'
import { ApiActionType, IInitialStateApiContext } from './Api.types'

export const apiReducer = (
  state: IInitialStateApiContext,
  action: ApiActionType
) => {
  let { items } = state

  switch (action.type) {
    case 'addItem':
      return { ...state, items: items.concat([action.payload]) }
    case 'updateItem':
      return {
        ...state,
        items: items.map((t: Item) =>
          t.id === action.payload.id ? action.payload : t
        ),
      }
    case 'loadItems':
      return { ...state, items: action.payload }
    default:
      return state
  }
}
