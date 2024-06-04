<template>
  <HeaderComponent />
    <div class="container">
    <header>
      <h1 class="mb-0">About</h1>
    </header>
    <br/>
    <div class="card flex justify-content-center gap-3">
      <router-link to="/" rel="noopener">
        <Button label="Home" icon="pi pi-check" />
      </router-link>
      <NuxtLink  to="https://github.com/josercarvalho" target="_blank" rel="noopener">
        <Button label="Meu Github" icon="pi pi-check" iconPos="right"/>
      </NuxtLink>
    </div>
  </div>
  </template>

<script lang="ts">
import { defineComponent } from 'vue';
import HeaderComponent from '@/components/HeaderComponent.vue';

export default defineComponent({
  name: 'AboutView',
  components: {
    HeaderComponent,
  },
});
</script>
