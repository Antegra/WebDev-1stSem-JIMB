<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">
          <img class="logo" src="../assets/img/ucl-logo.png" alt="UCLs logo" />
        </RouterLink>
        <div class="main-navigation">
          <RouterLink to="/">Home</RouterLink>
          <RouterLink to="/newcase">Ny case</RouterLink>
          <RouterLink to="/oldcases">Gamle cases</RouterLink>
          <RouterLink to="/data">Data</RouterLink>
          <RouterLink to="/settings">
            <font-awesome-icon icon="fa-solid fa-gear" />
          </RouterLink>
        </div>
      </nav>
    </div>
  </header>
  <RouterView />
</template>

<style lang="scss" scoped>
@import "../assets/colors.scss";

.wrapper {
  nav {
    display: flex;
    align-items: baseline;
    justify-content: space-between;

    .logo {
      max-width: 143px;
    }
    .main-navigation {
      a {
        color: $Midnight-Green;
        margin: 0 20px;
        padding: 5px 0;
        text-decoration: none;

      }
    }
  }
}
</style>
