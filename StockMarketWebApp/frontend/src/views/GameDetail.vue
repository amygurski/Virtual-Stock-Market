<template>
  <h1>ID: {{id}} </h1>
</template>

<script>
export default {
    props: {
        id: Number
    },
    created() {
        this.id = this.$route.params.id
    }

}
</script>

<style>

</style>