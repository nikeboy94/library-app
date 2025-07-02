<template>
  <v-app-bar :elevation="2" color="blue">
    <v-btn prepend-icon="mdi-book" size="x-large" @click="routeTo('/')">Library App</v-btn>
  </v-app-bar>
</template>

<script lang="ts" setup>
  import router from '@/router'

  function routeTo(route: string) {
    router.push(route)
  }
</script>