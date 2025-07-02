export default class Book {
  id: number = 0
  title: string = ""
  description: string = ""
  author: string = ""

  constructor(build: any) {
    this.id = build.id
    this.title = build.title
    this.description = build.description
    this.author = build.author
  }
}