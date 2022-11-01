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
          <RouterLink to="/">Hjem</RouterLink>
          <RouterLink to="/newcase">Ny sag</RouterLink>
          <RouterLink to="/oldcases">Gamle sager</RouterLink>
          <RouterLink to="/data">Data</RouterLink>
          <RouterLink to="/settings">
            <span class="material-symbols-outlined">
              settings
            </span>
          </RouterLink>
        </div>  
      </nav>
    </div>
  </header>
  <RouterView />
</template>

<style lang="scss" scoped>
@import "../assets/colors.scss";

header {
  display: flex;
  flex: row;
  justify-content: center;
  .wrapper {
    nav {
      display: flex;
      align-items: baseline;
      justify-content: space-between;
      padding-top: 30px;
  
      .logo {
        max-width: 143px;
      }
      .main-navigation {
        padding-left: 5rem;
        a {
          color: $Midnight-Green;
          margin: 0 20px;
          text-decoration: none;
  
          &:hover, &:active {
            text-decoration: underline;
          }
  
          .material-symbols-outlined {
            position: relative;
            top: 7px;
            font-variation-settings:
            'FILL' 1,
            'wght' 400,
            'GRAD' 0,
            'opsz' 100
          }
        }
      }
    }
  }
}
</style>
