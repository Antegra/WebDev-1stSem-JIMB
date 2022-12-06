<script setup>
import { ref, computed, onBeforeMount } from 'vue';

let cases = ref([]);

onBeforeMount(async () => {

  const fetchedCases = await fetch('https://uclssapitest.azurewebsites.net/api/Case/' + 1)
    .then((fetchedCases) => fetchedCases.json())
  for (let i = 0; i < fetchedCases.length; i++) {
    cases.value.push(fetchedCases[i])
  }
})
</script>

<template>
  <div class="cases">
    <h1>
      Gamle sager
    </h1>


    <div v-for="test in cases">
      <ul>
        <li>Case id: {{ test.case_id }} </li>
        <li>Tidspunkt: {{ test.month }}</li>
        <li>Vejleder: {{ test.supervisor }}</li>
        <!--         
        <li>Type: {{ test.name }}</li>
        <li>Køn: {{ test.sex }}</li>
        <li>Længe af mødet: {{ test.length }}</li>
        <li>Sted: {{ test.location }}</li>
        <li>Uddannelse(r): {{ test.education }} </li>
        <li>Emner: {{ test.subject }}</li> -->
      </ul>
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



.cases {
  padding: 60px 0px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  max-width: 1080px;
  width: 100%;
  margin: auto;
  align-items: center;
  background: #00454e;
  border-radius: 13px;
  color: #fff;
  box-shadow: rgb(0 0 0 / 24%) 0px 3px 8px;
  position: relative;
  background-color: $Midnight-Green;


  ul {
    display: flex;
    justify-items: center;

    li {
      padding-right: 5vw;
    }
  }
}
</style>
  