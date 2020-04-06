<!-- 
  The Error component is used to display an error message in a consistent fashion.
  NOTES:
  - The error message is passed in as a prop to the component.
  - The component hides itself if the error message is empty.
  DEPENDENCIES:
    None
-->

<template>
  <div class="error-message" v-if="error">
    <p>{{ error }}</p>
  </div>
</template>

<script>
export default {
  name: "error-message",
  props: {
    error: String
  }
};
</script>

<style scoped>
.error-message {
  margin-bottom: 0.4rem;
  background-color: var(--error);
  color: rgb(169, 68, 66);
  padding: 5px;
  border-radius: 3px;
}

.error-message p {
  margin: 0.5rem 0rem;
}
</style>
