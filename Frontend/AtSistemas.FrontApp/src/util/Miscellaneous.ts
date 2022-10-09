export function createGuid(): string {
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
    let r = (Math.random() * 16) | 0,
      v = c === 'x' ? r : (r & 0x3) | 0x8
    return v.toString(16)
  })
}

export function formatDate(date: Date): string {
  date = new Date(date)

  var day = ('0' + date.getDate()).slice(-2)
  var month = ('0' + (date.getMonth() + 1)).slice(-2)
  var year = date.getFullYear()

  return year + '-' + month + '-' + day
}
