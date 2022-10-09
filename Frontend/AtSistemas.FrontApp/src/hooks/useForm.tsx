import { ChangeEvent, useState } from 'react'

export const useForm = <T extends Object>(initState: T) => {
  const [form, setForm] = useState(initState)

  const handleChange = ({ target }: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = target
    setValue([name], value)
  }

  const setValue = (names: string[], value: string) => {
    let temp = { ...form }
    for (let i = 0; i < names.length; i++) {
      temp = { ...temp, [names[i]]: value }
    }

    names.map((name) => setForm(temp))
  }

  return {
    form,
    handleChange,
    setValue,
  }
}
