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
@import "../assets/colors.scss";

.hub {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  max-width: 1080;
  height: 90vh;
  
.hub-container {
  padding: 5rem;
  background-color: $Columbia-blue;
  display: flex;
  flex-direction: column;
  align-items: center;
  color: $Midnight-Green;
  border-radius: 2px;

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
  