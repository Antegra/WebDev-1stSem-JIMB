<script>
import buttons from "../components/buttons.vue"

export default {
  data() {
    return {
      SVName: 'Hanne'
    }
  }
}
</script>

<template>
  <div class="hub">
    <div class="hub-container">
      <h2>Velkommen {{ SVName }}</h2>
      <div class="button-container">
        <RouterLink to="/newcase">Opret en ny sag</RouterLink>
        <RouterLink to="/oldcases">Se gamle sager</RouterLink>
      </div>
    </div>

  </div>
</template>

<style lang="scss" scoped>
@import "../assets/scss/colors.scss";
@import "../assets/scss/typography.scss";
@import "../assets/scss/button.scss";
@import "../assets/scss/variabler.scss";
@import "../assets/scss/mixins.scss";

.hub {

  @include mainWrap;
  
.hub-container {


  @include flowDesign; 

  .button-container {
    min-width: 600px;
    min-height: 300px;
    display: flex;
    justify-content: space-around;
    align-items: center;

    a {
      text-decoration: none;
      padding: 2rem 4rem;
      background-color: white;
      color: $Midnight-Green;
      border-radius: 2px;
    }
  }
}
}

</style>
  