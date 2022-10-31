<script setup>
import { RouterLink, RouterView } from 'vue-router'
import MyButton from "./components/buttons.vue"





</script>

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
        <RouterLink to="/components">Components</RouterLink>
        

      </nav>
    </div>
  </header>
  <RouterView />
</template>





<style lang="scss" scoped>
@import "./assets/colors.scss";

.wrapper {
  nav {
    background-color: $Midnight-Green;
    display: flex;
    
    
    a {
      color: white;
      margin: 0 20px;
      padding: 5px 0; 

      text-decoration: none;
    }
  }
}


</style>
