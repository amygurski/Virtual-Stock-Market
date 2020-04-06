<!-- 
  The New Comment component is used to house the UI and logic to capture a new comment for a post.
  NOTES:
  - The post the comment will be for is passed in as a prop.
  - The component emits a 'newComment' event upon successfully POSTing the comment to a post.
  - All comments require some text, therefore the button is disabled if the textbox is empty.
  DEPENDENCIES:
    None
-->

<template>
  <form class="new-comment">
    <input type="text" name="comment" id="comment" placeholder="Add a comment..." />
    <button>Post</button>
  </form>
</template>

<script>
//Uncomment me to make API call
//import auth from "@/shared/auth.js";

export default {
  name: "new-comment",
  props: {
    post: Object
  },
  data() {
    return {
      comment: ""
    };
  },
  methods: {}
};
</script>

<style scoped>
</style>
