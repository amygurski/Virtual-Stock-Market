<template>
  <p>Placeholder</p>
  <!-- <div class="container-chart text-center">
    <h1>Demo examples of vue-chartjs</h1>
    <div class="columns">
      <div class="column">
        <h3>Line Chart</h3>
        <line-chart></line-chart>
      </div>
      <div class="column">
        <h3>Bar Chart</h3>
        <bar-chart></bar-chart>
      </div>
    </div>
    <div class="columns">
      <div class="column">
        <h3>Reactivity - Live update upon change in datasets</h3>
        <reactive :chart-data="datacollection"></reactive>
        <button class="button is-primary" @click="fillData()">Randomize</button>
      </div>
      <div class="spacer"></div>
    </div>
  </div>-->
</template>

<script>
// import LineChart from "@/Components/LineChart";
// import BarChart from "@/Components/BarChart";
// import Reactive from "@/Components/Reactive";

// export default {
//   name: "VueChartJS",
//   components: {
//     LineChart,
//     BarChart,
//     Reactive
//   },
//   data() {
//     return {
//       // instantiating datacollection with null
//       datacollection: null
//     };
//   },
//   created() {
//     //anytime the vue instance is created, call the fillData() function.
//     this.fillData();
//   },
//   methods: {
//     fillData() {
//       this.datacollection = {
//         // Data for the y-axis of the chart
//         labels: [
//           "January",
//           "February",
//           "March",
//           "April",
//           "May",
//           "June",
//           "July",
//           "August",
//           "September",
//           "October",
//           "November",
//           "December"
//         ],
//         datasets: [
//           {
//             label: "Data One",
//             backgroundColor: "#f87979",
//             // Data for the x-axis of the chart
//             data: [
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt(),
//               this.getRandomInt()
//             ]
//           }
//         ]
//       };
//     },
//     getRandomInt() {
//       // JS function to generate numbers to be used for the chart
//       return Math.floor(Math.random() * (50 - 5 + 1)) + 5;
//     }
//   }
// };
</script>

<style scoped>
.container-chart {
  background: linear-gradient(
      rgba(255, 255, 255, 0.25),
      rgba(255, 255, 255, 0.25)
    ),
    url(/images/WallStreet.jfif) no-repeat center center fixed;
  position: fixed;
  overflow: auto;
  height: 100%;
  width: 100%;
  background-size: cover;
  padding-bottom: 10%;
  padding-top: 5%;
  padding-top: 60px;
  padding-bottom: 220px;
}

.columns {
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: #343a40;
  color: white;
  margin: auto;
  padding: 20px;
  width: 65%;
}

.column {
  margin-top: 8%;
}
</style>