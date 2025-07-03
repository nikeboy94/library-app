<template>
  <v-card>
    <v-card-title>
      {{ formTitle }}
    </v-card-title>
    <v-card-text>
      <v-row>
        <v-col cols="8">
          <v-text-field v-model="modelBook.title" label="Title" />
        </v-col>
        <v-col cols="4">
          <v-text-field v-model="modelBook.author" label="Author" />
        </v-col>
        <v-col cols="12">
          <v-textarea v-model="modelBook.description" label="Description" />
        </v-col>
      </v-row>
    </v-card-text>
    <v-card-actions>
      <slot :model-book="modelBook" name="actions" />
    </v-card-actions>
  </v-card>
</template>

<script lang="ts" setup>
  import Book from '@/classes/Book'
  import BookPost from '@/classes/BookPost'

  const props = defineProps({
    formTitle: {
      type: String,
      required: true,
    },
    book: {
      type: Book,
    },
  })

  const modelBook = ref(new BookPost(props.book))
</script>
