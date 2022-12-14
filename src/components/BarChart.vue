

<script setup>
import { Bar } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'
import { ref, onBeforeMount } from 'vue'
import { API_URL } from '../connection'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)

let allCases = ref([]);

onBeforeMount(async () => {
  let allCases = await fetch(API_URL + '/case')
    .then((test) => test.json())
  
console.log(allCases)



});
download(JSON.stringify(allCases), "apidata.json", "text/plain");
let myArray = [1];
console.log("1. ", myArray)

onBeforeMount(async () => {
  const test = await fetch(API_URL + '/Charts/' + 12)
    .then((test) => test.json())
  myArray.push(test.chartCasesPerMonth);
  //testing.push(test.chartCasesPerMonth);

});

console.log("2. ", myArray);

const data = {
  labels: ['Januar', 'Februar', 'Marts', 'April', 'Maj', 'Juni', 'Juli'],
  datasets: [{
    label: 'Antal sager opretter',
    data: myArray,
    backgroundColor: [
      'rgba(255, 99, 132, 0.2)',
      'rgba(255, 159, 64, 0.2)',
      'rgba(255, 205, 86, 0.2)',
      'rgba(75, 192, 192, 0.2)',
      'rgba(54, 162, 235, 0.2)',
      'rgba(153, 102, 255, 0.2)',
      'rgba(201, 203, 207, 0.2)'
    ],
    borderColor: [
      'rgb(255, 99, 132)',
      'rgb(255, 159, 64)',
      'rgb(255, 205, 86)',
      'rgb(75, 192, 192)',
      'rgb(54, 162, 235)',
      'rgb(153, 102, 255)',
      'rgb(201, 203, 207)'
    ],
    borderWidth: 1
  }]
};

const config = {
  type: 'bar',
  data: data,
  options: {
    scales: {
      y: {
        beginAtZero: true
      }
    }
  },
};














</script>

<template>
  <button type="button" v-on:click="saveFile()">saveFile</button>
  <button @click="allCases(JSON.stringify(allCases), 'allCases.json', 'text/plain')">Add 1</button>
  <Bar id="my-chart-id" :options="chartOptions" :data="data" />
</template>
  
