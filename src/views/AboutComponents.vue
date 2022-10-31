<template>
    <div class="componentswrapper">
        <div class="buttons">
        <MyButton @click="handleBack" :arrowFront="false" buttonText="Tilbage" />
        <MyButton @click="handleNext" :arrowFront="true" buttonText="Næste" />
        </div>

        <div>
        <Searchbar style="margin:auto" />
        </div>

        <div>
         
        </div>

    </div>

  </template>



  
  <script setup>


import Searchbar from "../components/c-searchbar.vue";
import MyButton from "../components/c-buttons.vue";

  
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
        justify-content: center;
    }


    .componentswrapper {
        display:flex;
        flex-direction: column;
        justify-content: center;
        width: 100vw;
        height: 100vh;
    }


  </style>
  