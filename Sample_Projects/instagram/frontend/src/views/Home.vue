<!-- 
  The Home Page should display a feed of all posts from most recent.
  NOTES:
  - Upon creation, it calls api/posts and sorts the response.
  DEPENDENCIES: 
    Post.vue 
-->
<template>
  <div id="home" class="container">
    <post v-for="post in posts" v-bind:key="post.id" v-bind:post="post"></post>
  </div>
</template>

<script>
import Post from "@/components/posts/Post.vue";
import auth from "@/shared/auth.js";

export default {
  name: "home",
  components: {
    Post
  },
  data() {
    return {
      posts: []
    };
  },
  methods: {
    /**
     * Returns the array of posts sorted by id desc.
     * @param {Array} posts The array of posts.
     * @function
     */
    sortPosts(posts) {
      return posts.sort((a, b) => {
        return b.id - a.id;
      });
    }
  },
  /**
   * Invokes the API endpoint to retrieve all posts.
   */
  created() {
    // Call the Api to get the posts
    fetch(`${process.env.VUE_APP_REMOTE_API}/posts`, {
      method: "GET",
      headers: {
        // A Header with our authentication token.
        Authorization: "Bearer " + auth.getToken()
      }
    })
      .then(response => response.json())
      .then(json => {
        this.posts = this.sortPosts(json);
      });
  }
};
</script>

<style scoped>
#home {
  margin-top: 0.5rem;
}

.post {
  border-bottom: 1px solid #eee;
  margin-bottom: 0.5rem;
}
</style>
