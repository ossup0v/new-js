<template>
  <h1>TEST??</h1>
  <div>
    <canvas id="myChart"></canvas>
  </div>
</template>

<script>
import { onMounted } from 'vue'
import { Chart } from 'chart.js/auto';
import ServerApi from '@/network/ServerApi';

export default {
  mounted() {
    console.log('onMounted');
    ServerApi.getInstance().getSpendings().then((spendings) => {
      const groupedSpendingsByCategory = []
      const groupedSpendingsByDay = []
      const datasetsLabels = []

      const dict = {};

      Array.from(spendings).forEach(spending => {
        const categoryKey = spending.category;

        if (!groupedSpendingsByCategory[categoryKey]) {
          groupedSpendingsByCategory[categoryKey] = [];
          datasetsLabels.push(categoryKey);
        }

        groupedSpendingsByCategory[categoryKey].push(spending);

        const dayKey = getDayOfMonth(spending.creationTime);

        if (!groupedSpendingsByDay[dayKey]) {
          groupedSpendingsByDay[dayKey] = [];
        }

        groupedSpendingsByDay[dayKey].push(spending);

        if (dict[categoryKey] === undefined) {
          dict[categoryKey] = {}
        }

        if (dict[categoryKey][dayKey] === undefined) {
          dict[categoryKey][dayKey] = spending.spendAmount.amount;
        } else {
          dict[categoryKey][dayKey] += spending.spendAmount.amount;
        }
      });

      function getDayOfMonth(dateString) {
        const date = new Date(dateString);
        return date.getUTCDate(); // Get the day of the month (1-31)
      }

      // Get the list of days of the month
      const globalLabels = [...new Set(spendings.map((x) => getDayOfMonth(x.creationTime)))];
      const dataConfig = {
        labels: globalLabels,
        datasets: []
      };
      function randomIntFromInterval(min, max) { // min and max included 
        return Math.floor(Math.random() * (max - min + 1) + min)
      }
      for (const [categoryKey, arr] of Object.entries(dict)) {
        const data = {
          label: categoryKey,
          backgroundColor: `rgb(${randomIntFromInterval(1, 255)}, ${randomIntFromInterval(1, 255)}, ${randomIntFromInterval(1, 255)})`,
          borderColor: `rgb(${randomIntFromInterval(1, 255)}, ${randomIntFromInterval(1, 255)}, ${randomIntFromInterval(1, 255)})`,
          data: []
        }

        for (const [dayKey, amount] of Object.entries(arr)) {
          data.data.push(amount)
        }
        dataConfig.datasets.push(data)
      }
      const config = {
        type: 'line',
        data: dataConfig,
        options: {}
      };

      const myChart = new Chart(
        document.getElementById('myChart'),
        config
      );
      console.log(groupedSpendingsByCategory);
      console.log(globalLabels);
    })

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