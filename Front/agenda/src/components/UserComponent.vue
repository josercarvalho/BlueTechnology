<template>
  <HeaderComponent />
  <br />
  <div class="container">
    <div style="margin: 0 auto; top: 20%; width: 80%">
      <Panel header="USUÁRIOS">
        <Menubar :model="items" />
        <br />
        <DataTable v-model:editingRows="editingRows" :value="usuarios" editMode="row" dataKey="id" :paginator="true"
          :rows="10" @row-edit-save="onRowEditSave" :pt="{
            table: { style: 'min-width: 50rem' },
            column: {
              bodycell: ({ state }) => ({
                style: state['d_editing'] && 'padding-top: 0.6rem; padding-bottom: 0.6rem'
              })
            }
          }">
          <Column field="id" header="Usuario ID">
            <template #editor="{ data, field }">
              <InputText v-model="data[field]" />
            </template>
          </Column>
          <Column field="name" header="Nome">
            <template #editor="{ data, field }">
              <InputText v-model="data[field]" />
            </template>
          </Column>
          <Column field="email" header="E-mail">
            <template #editor="{ data, field }">
              <InputText v-model="data[field]" />
            </template>
          </Column>
          <Column field="password" header="password">
            <template #editor="{ data, field }">
              <InputText v-model="data[field]" />
            </template>
          </Column>
          <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center"></Column>
        </DataTable>
      </Panel>
      <Dialog header="Cadastro de usuário" :visible.sync="displayModal" :modal="true">
        <span class="p-float-label">
          <InputText id="name" type="text" v-model="usuario.name" style="width: 100%" />
          <label for="name">Nome</label>
        </span>
        <br />
        <span class="p-float-label">
          <InputText id="email" type="text" v-model="usuario.email" style="width: 100%" />
          <label for="email">E-mail</label>
        </span>
        <br />
        <span class="p-float-label">
          <InputText id="password" type="text" v-model="usuario.password" style="width: 100%" />
          <label for="password">password</label>
        </span>
        <template #footer>
          <Button label="Salvar" icon="pi pi-check" @click="save" />
          <Button label="Cancelar" icon="pi pi-times" @click="closeModal" class="p-button-secondary" />
        </template>
      </Dialog>
    </div>
  </div>
</template>

<script>
import { ref } from 'vue';
import UsuarioService from "../services/UserServices.ts";
import HeaderComponent from './HeaderComponent.vue';

export default {
  editingRows: ref([]),
  statuses: ref([
    { label: 'In Stock', value: 'INSTOCK' },
    { label: 'Low Stock', value: 'LOWSTOCK' },
    { label: 'Out of Stock', value: 'OUTOFSTOCK' }
  ]),
  name: "UserComponent",
  components: {
    HeaderComponent,
  },
  data() {
    return {
      usuarios: null,
      editingRows: [],
      statuses: [
        { label: 'In Stock', value: 'INSTOCK' },
        { label: 'Low Stock', value: 'LOWSTOCK' },
        { label: 'Out of Stock', value: 'OUTOFSTOCK' }
      ],
      usuario: {
        id: null,
        name: null,
        email: null,
        password: null
      },
      items: [
        {
          label: "Novo",
          icon: "pi pi-fw pi-plus",
          command: () => {
            this.showSaveModal();
          }
        },
        {
          label: "Refresh",
          icon: "pi pi-fw pi-refresh",
          command: () => {
            this.getAll();
          },
        },
        {
          label: "Voltar",
          icon: 'pi pi-fw pi-arrow-circle-left',
          route: '/home'
        }
      ],
      displayModal: false
    };
  },
  usuarioService: null,
  created() {
    this.usuarioService = new UsuarioService();
  },
  mounted() {
    this.getAll();
  },
  methods: {
    showSaveModal() {
      this.displayModal = true;
    },
    getAll() {
      this.usuarioService.getAll().then(data => {
        this.usuarios = data.data.data;
      });
    },
    onRowEditSave(event) {
      let { newData, index } = event;

      this.usuario[index] = newData;

      this.usuarioService.update(newData).then(data => {
        if (data.status === 500) {
          toast.add({ severity: 'error', summary: 'Erro!', detail: 'Ocorreu um erro durante atualização do registr!', life: 3000 });
        };
        this.getAll();
      })
    },
    getStatusLabel(status) {
      switch (status) {
        case 'INSTOCK':
          return 'success';

        case 'LOWSTOCK':
          return 'warning';

        case 'OUTOFSTOCK':
          return 'danger';

        default:
          return null;
      }
    },
    save() {
      this.usuarioService.save(this.usuario).then(data => {
        if (data.status === 200) {
          this.displayModal = false;
          this.usuario = {
            id: null,
            name: null,
            email: null,
            password: null
          };
          this.getAll();
        }
      });
    },
    closeModal() {
      this.displayModal = false;
    }
  }
};
</script>

<style></style>