<template>
  <v-app-bar color="blue" flat>
    <v-btn prepend-icon="mdi-book" size="x-large" @click="routeTo('/')">Library App</v-btn>
    <v-btn @click="routeTo('books')">Books</v-btn>
  </v-app-bar>
</template>

<script lang="ts" setup>
  import router from '@/router'

  function routeTo (route: string) {
    router.push(route)
  }
</script>
