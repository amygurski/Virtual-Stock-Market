<!-- 
  The Post Author component is used display a poster's image and username side by side.
  NOTES:
  - The author's username and userimage are passed in as separate props.
  DEPENDENCIES:
    None
-->

<template>
  <!-- Renders the link as a div around the image and paragraph -->
  <router-link
    class="post-author"
    tag="div"
    v-bind:to="{ name: 'view-user', params: { id: userName } }"
  >
    <img v-bind:src="userImage" v-bind:alt="userName" class="profile-photo small" />
    <p>{{ userName }}</p>
  </router-link>
</template>

<script>
export default {
  name: "post-author",
  props: {
    userImage: String,
    userName: String
  }
};
</script>

<style scoped>
.post-author {
  display: flex;
  flex-direction: row;
  cursor: pointer;
}

.profile-photo {
  margin-right: 1rem;
}

p {
  font-weight: bold;
}
</style>
