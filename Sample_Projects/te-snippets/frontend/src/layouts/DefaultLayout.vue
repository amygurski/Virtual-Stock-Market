<template>
  <div class="container-fluid">
    <snippet-navigation></snippet-navigation>
    <div class="page-view">
      <slot />
    </div>
  </div>
</template>

<script>
import SnippetNavigation from '@/components/SnippetNavigation';

export default {
  name: 'DefaultLayout',
  components: {
    SnippetNavigation,
  },
};
</script>

<style>
.container-fluid {
  margin: 0px;
  padding: 0px !important;
}
.page-view {
  padding: 0px 20px !important;
}
</style>
