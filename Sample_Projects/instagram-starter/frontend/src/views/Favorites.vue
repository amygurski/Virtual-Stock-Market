<!-- 
  The Favorites Page should display a list of all a given user's favorite posts by username of poster.
  NOTES:
  - Upon creation, it calls api/favorites and uses the response to extract out all unique usernames of posters.
  - The component loops through the users (ascending order) and renders a post-author and post-grid 
    for each post favorited for that user.
  DEPENDENCIES:
    PostAuthor.vue
    PostGrid.vue 
-->

<template>
  <div id="favorites" class="container">
    <div class="favorite-user" v-for="user in users" v-bind:key="user.id">
      <post-author />
      <post-grid />
    </div>
  </div>
</template>

<script>
import PostAuthor from "@/components/posts/PostAuthor.vue";
import PostGrid from "@/components/posts/PostGrid.vue";
//import auth from "@/shared/auth.js";

export default {
  name: "favorites",
  components: {
    PostAuthor,
    PostGrid
  },
  data() {
    return {
      users: Array,
      posts: Array
    };
  },
  created() {
    // Call the API to get the user's favorites
  },
  methods: {}
};
</script>

<style scoped>
.favorite-user {
  margin-top: 0.5rem;
}

.post-author {
  margin-bottom: 0.5rem;
}
</style>
