<template>
  <v-data-table :headers="headers" height="calc(100vh - 191px)" :items="books" :search="search">
    <template #top>
      <v-toolbar flat>
        <v-toolbar-title>
          <v-icon
            color="medium-emphasis"
            icon="mdi-book-multiple"
            size="x-small"
            start
          />

          Popular books
        </v-toolbar-title>

        <add-dialog @refetch-books="getBooks()" />

        <v-text-field
          v-model="search"
          class="mr-2"
          density="compact"
          flat
          hide-details
          label="Search"
          prepend-inner-icon="mdi-magnify"
          single-line
          variant="solo-filled"
        />

      </v-toolbar>
    </template>

    <template #item.actions="{ item }">
      <edit-dialog :book="item" @refetch-books="getBooks()" />
      <v-btn flat icon="mdi-delete-outline" @click="deleteBook(item.id)" />
    </template>
  </v-data-table>
</template>

<script lang="ts" setup>
  import axios from 'axios'
  import Book from '@/classes/Book'

  const books = ref(new Array<Book>())
  const search = ref('')
  const headers = [
    { title: 'Id', value: 'id' },
    { title: 'Title', value: 'title' },
    { title: 'Description', value: 'description' },
    { title: 'Author', value: 'author' },
    { title: 'Actions', value: 'actions' },
  ]

  function getBooks () {
    axios
      .get('https://localhost:7124/books')
      .then(response => {
        books.value = response.data.map((b: any) => new Book(b))
      })
      .catch(error => {
        console.error(error)
      })
  }

  function deleteBook (id: number) {
    axios
      .delete(`https://localhost:7124/books/${id}`)
      .then(() => {
        getBooks()
      })
      .catch(error => {
        console.error(error)
      })
  }

  onMounted(() => {
    getBooks()
  })
</script>
