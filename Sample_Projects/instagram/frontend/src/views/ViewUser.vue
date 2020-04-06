<!-- 
  The View User Page allows one to view all of the images a user has uploaded.
  NOTES:
    - Upon creating this page, a GET request is made to /users/:id to get all posts related to a user.    
    - The posts are passed into the PostGrid component to render.    
  DEPENDENCIES:
    PostGrid   
-->

<template>
  <div id="view-user" class="container">
    <div id="user-profile">
      <div id="profile-image">
        <img v-bind:src="image" v-bind:alt="`${username}'s Profile Image`" class="profile-photo" />
      </div>
      <div id="profile-data">
        <p class="username">{{ username }}</p>
        <p>
          <span class="posts">{{ posts.length }}</span> posts
        </p>
      </div>
    </div>
    <post-grid v-bind:posts="posts" />
  </div>
</template>

<script>
import PostGrid from "@/components/posts/PostGrid.vue";
import auth from "../shared/auth.js";

export default {
  name: "view-user",
  data() {
    return {
      username: "",
      image: "",
      posts: []
    };
  },
  components: {
    PostGrid
  },
  /**
   * Fetches the user and all of the posts for a given username.
   */
  created() {
    // Get the username from the url
    const user = this.$route.params.id;
    const url = `${process.env.VUE_APP_REMOTE_API}/users/${user}`;

    fetch(url, {
      method: "GET",
      headers: {
        Authorization: "Bearer " + auth.getToken()
      }
    })
      .then(response => response.json())
      .then(json => {
        // Pull each of the fields out of the JSON
        this.username = json.username;
        this.image = json.image;
        this.posts = json.userPosts;
      });
  }
};
</script>

<style scoped>
#view-user {
  margin-top: 1rem;
}

#user-profile {
  display: flex;
  flex-direction: row;
  margin-bottom: 1rem;
}

div#profile-image {
  flex-basis: 1.1rem;
  flex-grow: 1;

  margin-right: 1rem;

  display: flex;
  justify-content: center;
}

div#profile-data {
  flex-basis: 2rem;
  flex-grow: 2;

  display: flex;
  flex-direction: column;
  justify-content: center;
}

img.profile-photo {
  height: 120px;
}

p.username {
  font-size: 1.5rem;
}

.posts {
  font-weight: bold;
}

@media screen and (min-width: 768px) {
  img.profile-photo {
    height: 145px;
  }
}

@media screen and (min-width: 992px) {
  img.profile-photo {
    height: 160px;
  }
  div#profile-image {
    margin-right: 1.1rem;
  }
}
</style>
