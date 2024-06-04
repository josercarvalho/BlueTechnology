import { NavigationGuard } from "vue-router";

export const authGuard: NavigationGuard = (to, from, next) => {
  const isAuthenticated = Boolean(localStorage.getItem("loggedIn"));

  if (to.name === 'home') {
    // o usuário já está na rota home
    next();
  } else if (isAuthenticated) {
    // o usuário está autenticado e não está na rota home
    next("/home");
  } else {
    // o usuário não está autenticado
    next("/login");
  }
};