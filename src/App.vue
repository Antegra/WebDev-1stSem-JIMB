<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/header.vue';
</script>

<template>
  <div class="system-container">
    <Header/>
  </div>
</template>

<style lang="scss" scoped>
@import "./assets/colors.scss";

.system-container {
  font-family: 'Proixma Nova Alt', sans-serif;
}
</style>

