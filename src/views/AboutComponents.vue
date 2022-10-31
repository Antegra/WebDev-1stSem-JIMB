<template>
    <div>
        <div class="buttons">
        <MyButton @click="handleBack" :arrowFront="false" buttonText="Tilbage" />
        <MyButton @click="handleNext" :arrowFront="true" buttonText="Næste" />
        </div>

        <div>
        <Searchbar style="margin:500px" />
        </div>

    </div>

  </template>



  
  <script setup>

    

import Searchbar from "../components/searchbar.vue";
import MyButton from "../components/buttons.vue";
  
    function handleNext() {
            console.log("Next");
        }

    function handleBack() {
            console.log("Back");
        }
  
     

  </script>




  
  
  <style lang="scss" scoped>
    .buttons {
        display:flex;
    }


  </style>
  