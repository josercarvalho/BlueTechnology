
# Modelo de sistema em PrimeVue

## 💻 Pré-requisitos

Antes de começar, os requisitos são:
* Versão mais recente do Vue.
* Versão mais recente do Node.

## 🚀 Como criar um projeto do 0 em Vue?

Instalação global do vue:
```
npm install -g @vue/cli
```
Criação do projeto:
```
vue create <nome-do-projeto>
```
Selecionar a opção de configurar manualmente:
```
Vue CLI vX.x.x
?Please pick a preset:
  Default ([Vue 3] babel, eslint)
  Default ([Vue 2] babel, eslint)
> Manually select features
```
Escolher as opções (para um app PWA):
```
? Check the features needed for your project: (Press <space> to select, <a> to toggle all, <i> to invert selection, and <enter>
 to proceed)
 ( ) Babel
 (*) TypeScript
 (*) Progressive Web App (PWA) Support
 (*) Router
 (*) Vuex
 (*) CSS Pre-processors
 ( ) Linter / Formatter
 ( ) Unit Testing
 ( ) E2E Testing
 ```
 
 Escolher a versão 3.x:
 ```
 ? Choose a version of Vue.js that you want to start the project with (Use arrow keys)
> 3.x
  2.x
```

Marcar *N* para essas opções:

```
Use class-style component syntax? (y/N)
Use Babel alongside TypeScript (required for modern mode, auto-detected polyfills, transpiling JSX)? (y/N)
Use history mode for router? (Requires proper server setup for index fallback in production) (Y/n)
```

Escolher o SCSS por padrão:
```
? Pick a CSS pre-processor (PostCSS, Autoprefixer and CSS Modules are supported by default): (Use arrow keys)
> Sass/SCSS (with dart-sass)
  Less
  Stylus
```

Adicionar os pacotes no package.json:
```
? Where do you prefer placing config for Babel, ESLint, etc.? (Use arrow keys)
  In dedicated config files
> In package.json
```

## ☕ Setup do projeto utilizando a lib PrimeVue

Instale as dependências do primevue:
```
npm install primevue
```
```
npm install primeflex
```
```
npm install primeicons
```
Após isso, adicione as dependências do prime no arquivo src/main.ts:

```
import  './registerServiceWorker';
import  'primeflex/primeflex.css'; -- primeflex
import  'primeicons/primeicons.css'; -- primeicons
import  'primevue/resources/primevue.min.css'; -- primevue
import  'primevue/resources/themes/lara-light-teal/theme.css'; -- tema
```

Adicione os componentes do prime conforme necessário, no arquivo src/main.ts:
```
import { createApp } from 'vue';
import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import InputText from 'primevue/inputtext';
import Card from 'primevue/card';
import App from './App.vue';

const app = createApp(App);

app.use(PrimeVue, { ripple: true });
app.component('Button', Button);
app.component('InputText', InputText);
app.component('Card', Card);

app.mount('#app');
```

## 🤝 Modelo desenvolvido por:
Rodolfo Correia