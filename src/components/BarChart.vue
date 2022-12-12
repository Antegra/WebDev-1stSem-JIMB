<template>
    
    <Bar
      id="my-chart-id"
      :options="chartOptions"
      :data="chartData"
    />
  </template>
  
  <script>
 
  
  import { Bar } from 'vue-chartjs'
  import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'
  import { onBeforeMount } from 'vue'
  import { API_URL } from '../connection'
  
  ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)
  let x = []
  onBeforeMount(async ()=> { 
    const graphVar = await fetch(
      'https://uclssapitest.azurewebsites.net/api/Charts/12'
    ) .then((graphVar) => graphVar.json()) 
    console.log(graphVar)
    x.push(graphVar.chartCasesPerMonth)
  })
console.log(x)

  export default {
    name: "get-month",
 
    name: 'Årlige samtaler i 2022 pr. måned',
    components: { Bar },
    data() {
      return {
        chartData: {
          labels: [ 'Januar', 'Februar', 'Marts', 'April', 'Maj', 'Juni', 'Juli', 'August', 'September', 'Oktober', 'November', 'December'],
          datasets: [ { 
            label: 'Årlige samtaleri 2022 pr. måned',
            backgroundColor: [
      'rgba(255, 99, 132 )',
      'rgba(255, 159, 64, 0.2)',
      'rgba(255, 205, 86, 0.2)',
      'rgba(75, 192, 192, 0.2)',
      'rgba(54, 162, 235, 0.2)',
      'rgba(153, 102, 255, 0.2)',
      'rgba(201, 203, 207, 0.2)',
      'rgba(255, 99, 132, 0.2)',
      'rgba(255, 159, 64, 0.2)',
      'rgba(255, 205, 86, 0.2)',
      'rgba(75, 192, 192, 0.2)',
      'rgba(54, 162, 235, 0.2)'
    ],
    borderColor: [
      'rgb(255, 99, 132)',
      'rgb(255, 159, 64)',
      'rgb(255, 205, 86)',
      'rgb(75, 192, 192)',
      'rgb(54, 162, 235)',
      'rgb(255, 99, 132)',
      'rgb(255, 159, 64)',
      'rgb(255, 205, 86)',
      'rgb(75, 192, 192)',
      'rgb(54, 162, 235)',
      'rgb(153, 102, 255)',
      'rgb(201, 203, 207)'
    ],
            data: [1] } 
          ]
        },
        chartOptions: {
          responsive: true
        }
      }
    }
    
  }
 
  </script>