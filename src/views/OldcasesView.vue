<script setup>
import { ref, computed, onBeforeMount } from 'vue';

let cases = ref([]);

onBeforeMount(async () => {

  const fetchedCases = await fetch('https://uclssapitest.azurewebsites.net/api/Case/')
    .then((fetchedCases) => fetchedCases.json())
  for (let i = 0; i < fetchedCases.length; i++) {
    cases.value.push(fetchedCases[i])
  }
  console.log(cases.value)
})
</script>

<template>
  <div>
    <h1>
      Gamle sager
    </h1>
  </div>

  <div v-for="test in cases">
    <ul>
      <h2> Case id: {{ test.case_id }} </h2>

      <li>Tidspunkt: {{ test.month }}</li>
      <li>Type: {{ test.name }}</li>
      <li>Vejleder: {{ test.supervisor }}</li>
      <li>Køn: {{ test.sex }}</li>
      <li>Længe af mødet: {{ test.length }}</li>
      <li>Uddannelse(r): {{ test.education }} </li>
      <li>Emner: {{ test.subject }}</li>
    </ul>
  </div>
</template>

<style lang="scss" scoped>

</style>
  