<script setup>
 import tabVue from '../components/tab.vue';
import tabsVue from '../components/tabs.vue';
</script>

<template>
  <div class="settings">
    <div class="settings-container">
      <tabsVue>
        <tabVue name="Brugere">
          <h1>
            Brugere
          </h1>
          <button> Tilføj ny bruger</button>
          <div class="table">
            table
          </div>
        </tabVue>
  
        <tabVue name="Emner">
          <h1>
            Emner
          </h1>
          <button> Tilføj nyt emne</button>
          <div class="table">
            table
          </div>
        </tabVue>
  
        <tabVue name="Lokationer">
          <h1>
            Lokationer
          </h1>
          <button> Tilføj ny lokation</button>
          <div class="table">
            table
          </div>
        </tabVue>
  
        <tabVue name="Uddannelser">
          <h1>
            Uddannelser
          </h1>
          <button> Tilføj ny uddannelse</button>
          <div class="table">
            table
          </div>
        </tabVue>
        
        <tabVue name="Profil">
          <h1>
            Profil
          </h1>
          
        </tabVue>
      </tabsVue>
    </div>
  </div>
  </template>
  
  <style lang="scss" scoped>
    @import "../assets/scss/colors.scss";
    @import "../assets/scss/typography.scss";

    @import "../assets/scss/variabler.scss";
    @import "../assets/scss/button.scss";
    @import "../assets/scss/mixins.scss";
    @import "../assets/scss/layout.scss";

    .settings {
      @include mainWrap;
      height: 100vh;
      margin-top:unset;
    .settings-container {
      @include flowDesign;
      
    }
    }
    
  </style>
  