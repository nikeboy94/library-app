<template>
  <v-dialog max-width="1200">
    <template #activator="{ props: activatorProps }">
      <v-btn v-bind="activatorProps" flat icon="mdi-pencil" />
    </template>

    <template #default="{ isActive }">
      <book-form :book="book" form-title="Edit book">
        <template #actions="{ modelBook }">
          <v-btn @click="isActive.value = false">Close</v-btn>
          <v-btn @click="updateBook(modelBook, isActive)">Submit</v-btn>
        </template>
      </book-form>
    </template>
  </v-dialog>
</template>

<script lang="ts" setup>
  import type Book from '@/classes/Book'
  import type BookPost from '@/classes/BookPost'
  import axios from 'axios'

  const emit = defineEmits(['refetch-books'])

  const props = defineProps<{
    book: Book
  }>()

  function updateBook (updatedBook: BookPost, isActive: Ref<boolean>) {
    console.log(updatedBook)
    axios.patch(`https://localhost:7124/books/${props.book.id}`, updatedBook)
      .then(() => {
        emit('refetch-books')
        isActive.value = false
      })
      .catch(error => {
        console.error(error)
      })
  }
</script>
