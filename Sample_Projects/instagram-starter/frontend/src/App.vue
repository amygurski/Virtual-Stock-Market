<template>
  <div id="app">
    <the-header v-if="showHeader"></the-header>
    <router-view />
  </div>
</template>

<script>
import TheHeader from "@/components/layout/TheHeader.vue";

export default {
  name: "App",
  components: {
    TheHeader
  },
  computed: {
    /**
     * Indicates if the header should be visible.
     */
    showHeader() {
      const noHeaderPages = ["login"];
      return noHeaderPages.indexOf(this.$route.name) === -1;
    }
  }
};
</script>

<style>
#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
