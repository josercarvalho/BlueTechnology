<template>
    <div class="header">
      <div class="header-left">
        <Button @click="visibleSidebar = true" icon="pi pi-bars" class="p-button-rounded p-button-text header-menu-button"></Button>
      </div>
      <div class="header-right">
        <Button icon="pi pi-user" class="p-button-rounded p-button-text header-user-button"></Button>
        <Button @click="logout()" icon="pi pi-sign-out" tooltip="Sair" tooltipPosition="bottom" class="p-button-rounded p-button-text header-logout-button"></Button>
      </div>
    </div>
    
    <Sidebar :visible="visibleSidebar" :baseZIndex="10000" :showCloseIcon="true" @onHide="onSidebarHide">
    <h3>Agenda</h3>
    <ul class="list">
      <li><router-link to="/">Home</router-link></li>
      <Divider />
      <li><router-link to="/contato">Contatos</router-link></li>
      <li><router-link to="/user">Usuários</router-link></li>
      <Divider />
      <li><router-link to="/about">About</router-link></li>
      <br />
    </ul>
    <template #closeicon>
      <Button icon="pi pi-times" class="p-sidebar-close-button" @click="onSidebarHide"></Button>
    </template>
  </Sidebar>
  
  </template>
  
  <script lang="ts">
  import { defineComponent, ref } from 'vue';
  import { useRouter } from 'vue-router';
  
  export default defineComponent({
    name: 'HeaderComponent',
    setup() {
      const visibleSidebar = ref(false);
      const router = useRouter();
      
      const logout = async () => {
        localStorage.removeItem('loggedIn');
        localStorage.removeItem('access_token');
        await router.push('/login');
      };
  
      const onSidebarHide = () => {
        visibleSidebar.value = false;
      };
      
      return {
        visibleSidebar,
        logout,
        onSidebarHide,
      };
    },
  });
  </script>
  
  <style scoped lang="scss">
  
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 55px;
    padding: 0 20px;
    background-color: #f5f5f5;
    box-shadow: 0 2px 2px rgba(0, 0, 0, 0.1);
  }
  
  .header-left {
    display: flex;
    align-items: center;
  }
  
  .header-right {
    display: flex;
    align-items: center;
  }
  
  .header-menu-button {
    margin-right: 20px;
  }
  
  .header-user-button {
    margin-right: 10px;
  }
  
  .content {
    padding: 20px;
  }
  
  .links {
    text-decoration: none;
    color: inherit;
    cursor: pointer;
  }
  
  .list {
    list-style: none;
    padding: 0;
  }
  
  .icon {
    padding: 5px;
  }
  </style>