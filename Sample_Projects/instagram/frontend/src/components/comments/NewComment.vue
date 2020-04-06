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
  <form class="new-comment" v-on:submit.prevent="postComment" autocomplete="off">
    <input
      type="text"
      name="comment"
      id="comment"
      placeholder="Add a comment..."
      v-model="comment"
    />
    <button v-bind:disabled="!comment">Post</button>
  </form>
</template>

<script>
import auth from "@/shared/auth.js";

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
  methods: {
    /**
     * POSTs a comment to the provided post.
     */
    postComment() {
      // Build the body
      const comment = {
        message: this.comment
      };

      // Send the request
      const url = `${process.env.VUE_APP_REMOTE_API}/posts/${this.post.id}/comments`;
      fetch(url, {
        method: "POST",
        headers: {
          Authorization: "Bearer " + auth.getToken(),
          "Content-Type": "application/json"
        },
        body: JSON.stringify(comment)
      })
        .then(response => {
          return response.json();
        })
        .then(json => {
          // Get the new post object from the response
          this.handleCommentSuccess(json);
        });
    },
    /**
     * Handles the clean up after the comment was successfully saved.
     */
    handleCommentSuccess(commentObject) {
      this.comment = "";
      this.$emit("newComment", commentObject);
    }
  }
};
</script>

<style scoped>
form {
  display: flex;
  flex-direction: row;
  align-items: baseline;
}

input {
  flex: 1;
  background: transparent;
  border: none;
  outline: none;
}

button {
  background-color: transparent;
  color: #00adee;

  width: auto;
  min-width: auto;
  max-width: auto;
  padding-right: 0px;
}

button:disabled {
  color: rgba(0, 173, 238, 0.5);
}
</style>
