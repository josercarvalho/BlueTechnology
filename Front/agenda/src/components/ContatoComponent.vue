<template>
    <HeaderComponent />
    <br />
    <div class="container">
        <div style="margin: 0 auto; top: 20%; width: 80%">
            <Panel header="USUÁRIOS">
                <Menubar :model="items" />
                <br />
                <DataTable v-model:editingRows="editingRows" :value="contatos" editMode="row" dataKey="id"
                    :paginator="true" :rows="10" @row-edit-save="onRowEditSave" :pt="{
                        table: { style: 'min-width: 50rem' },
                        column: {
                            bodycell: ({ state }) => ({
                                style: state['d_editing'] && 'padding-top: 0.6rem; padding-bottom: 0.6rem'
                            })
                        }
                    }">
                    <Column field="id" header="Contto ID">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="nome" header="Nome">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="email" header="E-mail">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="dataNascimento" dataType="date" header="Data Nascimento">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" dateFormat="dd/mm/yy" placeholder="dd/mm/yyyy" mask="99/99/9999" />
                        </template>
                    </Column>
                    <Column field="cep" header="CEP">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="logradouro" header="Endereço">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="complemento" header="Complemento">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="bairro" header="Bairro">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="localidade" header="Cidade">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column field="uf" header="Estado">
                        <template #editor="{ data, field }">
                            <InputText v-model="data[field]" />
                        </template>
                    </Column>
                    <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center">
                    </Column>
                </DataTable>
            </Panel>
            <Dialog header="Cadastro de contatos" :visible.sync="displayModal" :modal="true">
                <span class="p-float-label">
                    <InputText id="name" type="text" v-model="contato.name" style="width: 100%" />
                    <label for="name">Nome</label>
                </span>
                <br />
                <span class="p-float-label">
                    <InputText id="email" type="text" v-model="contato.email" style="width: 100%" />
                    <label for="email">E-mail</label>
                </span>
                <br />
                <span class="p-float-label">
                    <InputText id="dataNascimento" type="text" v-model="contato.dataNascimento" style="width: 100%" />
                    <label for="dataNascimento">Data Nascimento</label>
                </span>
                <br />
                <span class="p-float-label">
                    <InputText id="cep" type="text" v-model="contato.cep" style="width: 100%" />
                    <label for="cep">CEP</label>
                </span>
                <span class="p-float-label">
                    <InputText id="logradouro" type="text" v-model="contato.logradouro" style="width: 100%" />
                    <label for="logradouro">Endereço</label>
                </span>
                <span class="p-float-label">
                    <InputText id="complemento" type="text" v-model="contato.complemento" style="width: 100%" />
                    <label for="complemento">Complemento</label>
                </span>
                <span class="p-float-label">
                    <InputText id="bairro" type="text" v-model="contato.bairro" style="width: 100%" />
                    <label for="bairro">Bairro</label>
                </span>
                <span class="p-float-label">
                    <InputText id="localidade" type="text" v-model="contato.localidade" style="width: 100%" />
                    <label for="localidade">Cidade</label>
                </span>
                <span class="p-float-label">
                    <InputText id="uf" type="text" v-model="contato.uf" style="width: 100%" />
                    <label for="uf">Estado</label>
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
import ContatoService from "@/services/ContatoServices";
import HeaderComponent from './HeaderComponent.vue';

export default {
    editingRows: ref([]),
    statuses: ref([
        { label: 'In Stock', value: 'INSTOCK' },
        { label: 'Low Stock', value: 'LOWSTOCK' },
        { label: 'Out of Stock', value: 'OUTOFSTOCK' }
    ]),
    name: "ContatoComponent",
    components: {
        HeaderComponent,
    },
    data() {
        return {
            contatos: null,
            editingRows: [],
            statuses: [
                { label: 'In Stock', value: 'INSTOCK' },
                { label: 'Low Stock', value: 'LOWSTOCK' },
                { label: 'Out of Stock', value: 'OUTOFSTOCK' }
            ],
            contato: {
                id: null,
                nome: null,
                email: null,
                dataNascimento: null,
                cep: null,
                logradouro: null,
                complemento: null,
                bairro: null,
                localidade: null,
                uf: null
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
    contatoService: null,
    created() {
        this.contatoService = new ContatoService();
    },
    mounted() {
        this.getAll();
    },
    methods: {
        formatDate(value) {
            return value.toLocaleDateString('pt-BR', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric'
            });
        },
        showSaveModal() {
            this.displayModal = true;
        },
        getAll() {
            this.contatoService.getAll().then(data => {
                this.contatos = data.data;
            });
        },
        onRowEditSave(event) {
            let { newData, index } = event;

            this.contato[index] = newData;

            this.contatoService.update(newData).then(data => {
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
            this.contatoService.save(this.contato).then(data => {
                if (data.status === 200) {
                    this.displayModal = false;
                    this.contato = {
                        id: null,
                        nome: null,
                        email: null,
                        dataNascimento: null,
                        cep: null,
                        logradouro: null,
                        complemento: null,
                        bairro: null,
                        localidade: null,
                        uf: null
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