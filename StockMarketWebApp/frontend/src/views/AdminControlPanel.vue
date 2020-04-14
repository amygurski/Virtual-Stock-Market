<template>
  <div>
      <modal name="hello-world">
  hello, world!
  <button class="btn btn-primary" @click="hide" />
</modal>
  <button class="btn btn-primary" @click="show" />
  </div>

</template>

<script>
export default {
  name: 'ExampleModal',
  data () {
    return {
      time: 0,
      duration: 5000
    }
  },
  methods: {
    show() {
      this.$modal.show('hello-world')
    },
    hide() {
      this.$modal.hide('hello-world')
    }
  }
}
</script>

<style>

</style>