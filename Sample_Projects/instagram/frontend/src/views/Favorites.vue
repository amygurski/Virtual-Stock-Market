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
    <div class="favorite-user" v-for="user in users" v-bind:key="user.userName">
      <post-author v-bind:userName="user.userName" v-bind:userImage="user.userImage" />
      <post-grid v-bind:posts="getPostsForUser(user.userName)" />
    </div>
  </div>
</template>

<script>
import PostAuthor from "@/components/posts/PostAuthor.vue";
import PostGrid from "@/components/posts/PostGrid.vue";
import auth from "@/shared/auth.js";

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
    const url = `${process.env.VUE_APP_REMOTE_API}/favorites`;
    fetch(url, {
      method: "GET",
      headers: {
        Authorization: "Bearer " + auth.getToken(),
        Accept: "application/json",
        "Content-Type": "application/json"
      }
    })
      .then(response => response.json())
      .then(json => {
        //this.mapJsonToDataObject(json);
        this.users = this.getUsersFromJson(json);
        this.posts = json;
      });
  },
  methods: {
    /**
     * Filters the posts published by user
     */
    getPostsForUser(userName) {
      return this.posts.filter(post => {
        return post.userName === userName;
      });
    },

    /**
     * Goes through a JSON array of posts and extracts out the unique users.
     */
    getUsersFromJson(json) {
      // Create an empty object where the key will be the username, the value the user data
      const deduplicatedUsers = {};

      // Loop through each post and extract the userNames and userImages
      json.forEach(post => {
        // If object does not contain key
        if (!deduplicatedUsers[post.userName]) {
          deduplicatedUsers[post.userName] = {
            userName: post.userName,
            userImage: post.userImage
          };
        }
      });

      // Rip out all of the values from the object representing our usernames and images
      // and sort the array by user name
      const users = Object.values(deduplicatedUsers).sort((a, b) => {
        return a.userName.localeCompare(b.userName);
      });

      return users;
    }
  }
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
