import { createRouter, createWebHashHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";

const router = createRouter({
  history: createWebHashHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/studievejledning/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/studievejledning/components",
      name: "components",
      component: () => import("../views/AboutComponents.vue"),
    },
    {
      path: "/studievejledning/newcase",
      name: "newcase",
      component: () => import("../views/NewcaseView.vue"),
    },
    {
      path: "/studievejledning/oldcases",
      name: "oldcases",
      component: () => import("../views/OldcasesView.vue"),
    },
    {
      path: "/studievejledning/settings",
      name: "settings",
      component: () => import("../views/SettingsView.vue"),
    },
    {
      path: "/studievejledning/login",
      name: "login",
      component: () => import("../views/LoginView.vue"),
    },
  ],
});

router.beforeEach((to, from, next) => {
  const token = localStorage.getItem("user-token");
  // If logged in, or going to the Login page.
  if (token || to.name === "login") {
    // Fortsæt til side
    next();
  } else {
    // Hvis ikke loggede ind, redirect til login
    next({ name: "login" });
  }
});

export default router;