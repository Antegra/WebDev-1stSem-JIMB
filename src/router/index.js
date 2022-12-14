import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/components",
      name: "components",
      component: () => import("../views/AboutComponents.vue"),
    },
    {
      path: "/newcase",
      name: "newcase",
      component: () => import("../views/NewcaseView.vue"),
    },
    {
      path: "/oldcases",
      name: "oldcases",
      component: () => import("../views/OldcasesView.vue"),
    },
    {
      path: "/settings",
      name: "settings",
      component: () => import("../views/SettingsView.vue"),
    },
    {
      path: "/login",
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