export default class Book {
  id = 0
  title = ''
  description = ''
  author = ''

  constructor (build: any | undefined | null = undefined) {
    if (build != null && build != undefined) {
      this.id = build.id
      this.title = build.title
      this.description = build.description
      this.author = build.author
    }
  }
}
