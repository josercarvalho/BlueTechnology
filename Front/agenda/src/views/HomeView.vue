<template>
  <div>
    <HeaderComponent />
    <h1>
      Olá Seja muito bem vindo!
    </h1>
    
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import HeaderComponent from '@/components/HeaderComponent.vue';

export default defineComponent({
  name: 'HomeView',
  components: {
    HeaderComponent,
  },

});
</script>
