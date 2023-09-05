<template>
  <h1>TEST??</h1>
  <div>
    <canvas id="myChart"></canvas>
  </div>
</template>

<script>
import { onMounted } from 'vue'
import { Chart } from 'chart.js/auto';


const labels = [
  'Jan',
  'Feb',
  'March',
  'April',
  'May',
  'June'
];

const data = {
  labels: labels,
  datasets: [{
    label: 'My first dataset',
    backgroundColor: 'rgb(255, 99, 132)',
    borderColor: 'rgb(255, 99, 132)',
    data: [0, 10, 5, 2, 20, 30, 45]
  }]
};

const config = {
  type: 'line',
  data: data,
  options: {}
};

export default {
  mounted() {
    console.log('onMounted');
    const myChart = new Chart(
      document.getElementById('myChart'),
      config
    );
  }
}

</script>

<style>
div #myChart {
  max-width: 800px;
  max-height: 500px;
  margin: 50px 50px 50px;
}
</style>