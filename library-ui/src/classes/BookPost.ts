export default class BookPost {
  title = ''
  description = ''
  author = ''

  constructor (build: any | undefined | null = undefined) {
    if (build != null && build != undefined) {
      this.title = build.title
      this.description = build.description
      this.author = build.author
    }
  }
}
