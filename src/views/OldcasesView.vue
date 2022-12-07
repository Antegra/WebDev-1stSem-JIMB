<script setup>
import { ref, computed, onBeforeMount } from 'vue';

let caseNumber = ref([0]);

let cases = ref([]);


onBeforeMount(async () => {

  const fetchedCases = await fetch('https://uclssapitest.azurewebsites.net/api/Case/' + 1)
    .then((fetchedCases) => fetchedCases.json())
  for (let i = 0; i < fetchedCases.length; i++) {
    cases.value.push(fetchedCases[i])
  }
})


function showCase(e) {
  if (caseNumber.value != e.case_id) {
    caseNumber.value = e.case_id;
  } else {
    caseNumber.value = 0;
  }

}
</script>

<template>

  <div class="box">
    <h1>
      Gamle sager
    </h1>

    <div class="cases" v-for="case1 in cases">
      <div class="case_top" v-on:click="showCase(case1)">

        <p>sags: nr. {{ case1.case_id }} </p>
        <p>Oprettelse: {{ case1.month }} </p>
        <p>Køn: {{ case1.sex }} </p>

      </div>
      <div class=" case_bottom" v-show="(caseNumber == case1.case_id)">
        <p> <span>sags: nr.</span> {{ case1.case_id }} </p>
        <p><span>Oprettelse:</span> {{ case1.month }} </p>
        <p><span>Køn:</span> {{ case1.sex }} </p>
        <p><span>Type henvendelse:</span> {{ case1.name }} </p>
        <p><span>Samtalens Længde:</span> {{ case1.length }} </p>
        <p><span>Sted:</span> {{ case1.location }} </p>
        <p><span>Uddannelser:</span> nr. {{ case1.education }} </p>
        <p><span>Emner:</span> {{ case1.subject }} </p>

      </div>
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



.box {
  padding: 60px 0px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  max-width: 1080px;
  width: 100%;
  margin: auto;
  align-items: center;
  background: $Midnight-Green;
  border-radius: 13px;
  color: #fff;
  box-shadow: rgb(0 0 0 / 24%) 0px 3px 8px;
  position: relative;
  background-color: $Midnight-Green;



  .cases {
    width: 70%;
  }

  .case_top {
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    align-content: center;
    flex-wrap: wrap;
    padding: 20px 0 12px;

    border-radius: 12px;
    box-shadow: $stdDropshadow;
    transition: .5s;


  }

  .case_top:hover {
    background-color: $Verdigris;
  }

  .case_bottom {
    display: flex;
    flex-direction: column;
    justify-content: flex-end;
    background-color: $Columbia-blue;
    color: $Midnight-Green;
    padding: 12px;
    border-radius: 12px;

    span {
      font-weight: bold;
      padding-right: 5px;
    }
  }


}
</style>
  