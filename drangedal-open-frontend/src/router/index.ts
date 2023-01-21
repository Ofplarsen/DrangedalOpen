import { createRouter, createWebHistory } from 'vue-router'
//Check out: https://router.vuejs.org/guide/#javascript

import Home from '../views/Home.vue'
import UserLogin from '../views/UserLogin.vue'
import UserRegister from '../views/UserRegister.vue'
import CreateTournament from '../views/CreateTournament.vue'
import Leaderboard from '../views/Leaderboard.vue'
const routes = [
  {
    path: '/',
    component: Home,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: '/login',
    component: UserLogin,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: '/register',
    component: UserRegister,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: '/tournament/new',
    component: CreateTournament,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: '/leaderboard',
    component: Leaderboard,
    meta: {
      requiresAuth: false,
    },
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})


export default router
