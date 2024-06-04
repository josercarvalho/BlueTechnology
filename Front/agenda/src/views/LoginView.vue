<template>
  <div class="login-container p-d-flex p-jc-center p-ai-center">
    <form @submit.prevent="login" class="p-card padding">
      <img src="../assets/logo.png" class="img-login p-mb-2 p-mt-4" />
      <div class="p-fluid">
        <div class="p-field p-mb-2">
          <InputText v-model="usuario" name="usuario" placeholder="Usuário" />
        </div>
        <div class="p-field p-mb-2">
          <Password v-model="senha" name="senha" :toggle-mask="true" :feedback="false" placeholder="Senha" />
        </div>
        <Button type="submit" class="login-button p-button p-mt-2">LOGIN</Button>
      </div>
    </form>
  </div>
  <Toast :position="'top-right'" />
</template>
<script lang="ts">
import { defineComponent, ref } from 'vue';
import http from '@/services/http';
import { useRouter } from 'vue-router';
import { useToast } from 'primevue/usetoast';

export default defineComponent({
  setup() {
    const usuario = ref('');
    const senha = ref('');
    
    const router = useRouter();
    const toast = useToast();

    async function login() {
      try {
        // Faz a requisição POST para o endpoint de login da sua API
        const response = await http.post('api/auth', {usuario: usuario.value, senha: senha.value});

            // Verifica se a resposta da API indica sucesso
            if (response.status === 200) {
              // Define o estado de login para verdadeiro no armazenamento local.
              // console.log(response);
              localStorage.setItem('loggedIn', 'true');
              localStorage.setItem('access_token', response.data.token);
              
              // Redireciona para a página home.
              router.push('/home');
            } else {
              toast.add({ severity: 'error', summary: 'Erro!', detail: 'Usuário ou senha incorretos', life: 3000 });
            }
      } catch (error) {
        console.error(error);
        toast.add({ severity: 'error', summary: 'Erro!', detail: 'Ocorreu um erro durante o login', life: 3000 });
      }
    }

    return {
      usuario,
      senha,
      login,
    };
  },
});
</script>
<style scoped lang="scss">
.padding {
  margin: 20px;
}

.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  overflow: hidden;
  background-color: #eef2ff;

  .img-login {
    display: block;
    margin-left: auto;
    margin-right: auto;
    width: 50%;
    height: 50%;
  }

  form {
    background-color: #ffffff;
    padding: 2rem;
    border-radius: 5px;
    box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.3);
    width: 445px;

    .login-button {
      display: flex;
      flex-direction: column;
      align-items: center;
      width: 100%;
      color: #ffffff;
      border-radius: 5px;
      border: none;
      font-size: 1.2rem;
      margin-top: 1rem;
    }

    .login-google-button {
      display: flex;
      align-items: center;
      text-align: center;
      width: 100%;
      border-radius: 5px;
      border: none;
      font-size: 1.2rem;
      margin-top: 1rem;
      justify-content: center;
      background-color: #4285F4;
    }

    .p-field {
      margin-bottom: 0;
      margin-top: 1rem;
    }
  }
}
</style>