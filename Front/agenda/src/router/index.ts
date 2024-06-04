import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import { authGuard } from "@/services/authGuard";
import UserComponent from '@/components/UserComponent.vue';
import AboutView from '../views/AboutView.vue';
import ContatoComponent from '@/components/ContatoComponent.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: "/home",
    name: "home",
    component: HomeView,
    // Usa o guard para verificar se o usuário está autenticado
    // beforeEnter: [authGuard],
  },
  {
    path: '/',
    name: 'home',
    component: HomeView,
    // beforeEnter: [authGuard],
  },
  {
    path: '/about',
    name: 'about',
    component: AboutView, 
  },
  {
    path: "/user",
    name: "user",
    component: UserComponent,
    // beforeEnter: [authGuard],
  },
  {
    path: "/contato",
    name: "contato",
    component: ContatoComponent,
    // beforeEnter: [authGuard],
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
  },
  {
    path: "/:pathMatch(.*)*",
    redirect: "/login",
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
