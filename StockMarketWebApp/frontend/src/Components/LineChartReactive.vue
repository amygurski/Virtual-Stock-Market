<script>
// Importing Bar and mixins class from the vue-chartjs wrapper
import { Line, mixins } from "vue-chartjs";

// Getting the reactiveProp mixin from the mixins module.
const { reactiveProp } = mixins;

export default {
  // Extend the line chart and add the reactiveProp mixin from vue-chartjs
  extends: Line,
  mixins: [reactiveProp],
  // Store chartdata and options in props these will be passed in from the caller
  props: {
    chartData: {
      type: Object,
      default: null
    },
    options: {
      type: Object,
      default: null
    }
  },
  mounted() {
    // this.chartdata is created in the mixin and contains all the data needed to build the chart.
    this.renderChart(this.chartData, this.options);
  }
};
</script>