<template>
  <v-container class="fill-height" max-width="900">
    <div>
      <v-img
        class="mb-4"
        height="150"
        src="@/assets/logo.png"
      />

      <div class="mb-8 text-center">
        <div class="text-body-2 font-weight-light mb-n1">Welcome to</div>
        <h1 class="text-h2 font-weight-bold">The Library</h1>
      </div>

      <v-row>
        <v-col cols="12">
          <v-card
            class="py-4"
            color="surface-variant"
            prepend-icon="mdi-book"
            rounded="lg"
            variant="tonal"
          >
            <template #image>
              <v-img position="top right" />
            </template>

            <template #title>
              <h2 class="text-h5 font-weight-bold">
                Use this website to explore books
              </h2>
            </template>

          </v-card>
        </v-col>

        <v-col v-for="link in links" :key="link.href" cols="6">
          <v-card
            append-icon="mdi-open-in-new"
            class="py-4"
            color="surface-variant"
            @click="routeTo(link.href)"
            :prepend-icon="link.icon"
            rel="noopener noreferrer"
            rounded="lg"
            :subtitle="link.subtitle"
            :title="link.title"
            variant="tonal"
          />
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script setup lang="ts">
  import router from '@/router'

  const links = [
    {
      href: 'books',
      icon: 'mdi-book-multiple',
      subtitle: 'See what the library has on offer',
      title: 'View books in the Library',
    },
    {
      href: 'books',
      icon: 'mdi-book-plus',
      subtitle: 'Add and edit books',
      title: 'Modify data',
    },
  ]

  function routeTo(route: string) {
    router.push(route)
  }
</script>
