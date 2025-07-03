<template>
  <v-dialog max-width="1200">
    <template #activator="{ props: activatorProps }">
      <v-btn
        v-bind="activatorProps"
        :border="true"
        class="me-2"
        prepend-icon="mdi-plus"
        rounded="lg"
        text="Add a Book"
      />
    </template>

    <template #default="{ isActive }">
      <book-form form-title="Add a book">
        <template #actions="{ modelBook }">
          <v-btn @click="isActive.value = false">Close</v-btn>
          <v-btn @click="submitBook(modelBook, isActive)">Submit</v-btn>
        </template>
      </book-form>
    </template>
  </v-dialog>
</template>

<script lang="ts" setup>
  import type BookPost from '@/classes/BookPost'
  import axios from 'axios'

  const emit = defineEmits(['refetch-books'])

  function submitBook (book: BookPost, isActive: Ref<boolean>) {
    console.log(book)
    axios.post('https://localhost:7124/books', book)
      .then(() => {
        emit('refetch-books')
        isActive.value = false
      })
      .catch(error => {
        console.error(error)
      })
  }
</script>
