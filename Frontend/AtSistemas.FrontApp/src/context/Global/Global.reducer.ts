import { GlobalActionType, IInitialStateGlobalContext } from './Global.types'

export const globalReducer = (
  state: IInitialStateGlobalContext,
  action: GlobalActionType
) => {
  switch (action.type) {
    case 'setEditItem':
      return { ...state, editItem: action.payload }
    default:
      return state
  }
}
