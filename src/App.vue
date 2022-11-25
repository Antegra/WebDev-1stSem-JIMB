<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/header.vue';
import Modal from './components/modal.vue';


</script>




<template>
  <div class="system-container">
    <Header/>
    <Modal/>
  </div>


</template>

<style lang="scss" scoped>
@import "./assets/scss/colors.scss";

.system-container {
  font-family: 'Proixma Nova Alt', sans-serif;
}
</style>

