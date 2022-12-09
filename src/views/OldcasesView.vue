<script setup>
import { ref, computed, onBeforeMount } from 'vue';
import { API_URL } from '../connection';

let user = JSON.parse(localStorage.getItem('user-token'));



let caseNumber = ref([0]);

let cases = ref([]);


onBeforeMount(async () => {

  const fetchedCases = await fetch(API_URL + "case/" + user[0].user_id)
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

    <div class="cases" v-for="case1 in cases.slice().reverse() ">
      <div class="case_top" v-on:click="showCase(case1)">

        <p>Sags: nr. {{ case1.case_id }} </p>
        <p>Oprettelse: {{ case1.month }} </p>
        <p>Køn: {{ case1.sex }} </p>
        <img :class="case1.case_id"
          src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADwAAAA8CAYAAAA6/NlyAAAABmJLR0QA/wD/AP+gvaeTAAABq0lEQVRoge3YoU5cQRQG4CUIqGiCReBqkBWUN0DQgC4YXF+hFtu6vkBThcbxCKhKTBWEpUWRVDQ0gfRDdJvQze7eubMzezflfHoz5z97986cnV4vhBBCCCGEEEIITwt2cY3v2O86TxPsDbJeYydngW/+9QGLFbJOBYt4P5T1KmehUU6wUiF3FjzH8aigOYuN8xXrFfK3zfcCZ+NC5iw4yQ8570kh2MLNpIA5iza5x7sK/TTleou7pnA5C18kNA2fsVyht+E8S4NaKc5zCrzGbWKBU6xW6PNvltVBjRS32M4t9FL6k77Cq8K95mTYnLZgm2/3Fw4K9drDG/xMrP0Fa6UKL+FTYmH4aIohBQs4xO/Eekd4VqTZoSBJO+RA1pBiwjAxQv2TQsIZ+EirIUXDMDFkdrNAjWA1v8giFPzpmcGrUoQpNxcz3gyLkXF86PC4KwIb6Cc20G/52Y2u+xup5VNLUW6YqEX793KcOsNELdrtvI918rezCO3OVjq+WChC+pAyF1dHRWgeUubqcrAI44eU+RgmavHnwryPS+x1nSeEEEIIIYQQQgj/uQcuDJYDq5O5IgAAAABJRU5ErkJggg==">
      </div>
      <div class=" case_bottom" v-show="(caseNumber == case1.case_id)">
        <p> <span>Sags: nr.</span> {{ case1.case_id }} </p>
        <p><span>Oprettelse:</span> {{ case1.month }} </p>
        <p><span>Køn:</span> {{ case1.sex }} </p>
        <p><span>Type henvendelse:</span> {{ case1.name }} </p>
        <p><span>Samtalens Længde:</span> {{ case1.length }} </p>
        <p><span>Sted:</span> {{ case1.location }} </p>
        <p><span>Uddannelser:</span> {{ case1.education }} </p>
        <p><span>Emner:</span> {{ case1.subject }} </p>
        <p><span>Nuværende studerende:</span> {{ case1.niveau }} </p>
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

  h1 {
    margin-bottom: 40px;
  }

  padding: 60px 0px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin: auto;
  max-width: 861px;
  width: 100%;
  margin-top: 170px;
  align-items: center;
  background: $Midnight-Green;
  border-radius: 13px;
  color: #fff;
  box-shadow: $stdDropshadow;
  position: relative;
  background-color: $Midnight-Green;



  .cases {
    width: 100%;
    margin-bottom: 14px;


    &:nth-child(even) {
      .case_top {
        background-color: #f2f2f2;

        &:hover {
          background-color: $Maize;
        }
      }
    }




  }

  .case_top {
    display: flex;
    margin-left: 40px;
    margin-right: 40px;
    flex-direction: row;
    justify-content: space-around;
    align-content: center;
    flex-wrap: wrap;
    padding: 20px 0 12px;
    position: relative;
    z-index: 999;
    border-radius: 5px;
    box-shadow: $stdDropshadow;
    transition: .5s;
    background-color: #ffffff;
    color: $Midnight-Green;
    cursor: pointer;
    user-select: none;
    img {
      filter: invert(48%) sepia(13%) saturate(3207%) hue-rotate(130deg) brightness(95%) contrast(80%);

    }

    &:hover {
      background-color: $Maize;
    }

    img {
      transform: scale(50%) rotate(0deg);
    }

    p {
      margin-top: 16px;
    }

  }



  .case_bottom {
    margin: 0 40px;
    display: flex;
    flex-direction: column;
    justify-content: flex-end;
    background-color: #ffffff;
    color: $Midnight-Green;
    padding: 50px 12px 12px 12px;
    border-radius: 12px;

    transform: translatey(-20px);


    span {
      font-weight: bold;
      padding-right: 5px;
    }
  }


}
</style>
  