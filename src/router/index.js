import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/components',
      name: 'components',
      component: () => import('../views/AboutComponents.vue')
    },
    {
      path: '/newcase',
      name: 'newcase',
      component: () => import('../views/NewcaseView.vue')
    },
    {
      path: '/oldcases',
      name: 'oldcases',
      component: () => import('../views/OldcasesView.vue')
    },
    {
      path: '/data',
      name: 'data',
      component: () => import('../views/DataView.vue')
    },
    {
      path: '/settings',
      name: 'settings',
      component: () => import('../views/SettingsView.vue')
    }
  ]
})

export default router
