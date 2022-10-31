<template>
    <div>
        <div class="buttons">
        <MyButton @click="handleBack" :arrowFront="false" buttonText="Tilbage" />
        <MyButton @click="handleNext" :arrowFront="true" buttonText="Næste" />
        </div>
    </div>
  </template>
  
  <script setup>
  import MyButton from "../components/buttons.vue"
  
  
  
  </script>



<script>
export default {
  components: {
    MyButton
  },
  methods: {
        handleNext() {
            console.log("Next");
        },
        handleBack() {
            console.log("Back");
        },
    }
}
</script>
  
  
  <style lang="scss" scoped>
    .buttons {
        display:flex;
    }


  </style>
  