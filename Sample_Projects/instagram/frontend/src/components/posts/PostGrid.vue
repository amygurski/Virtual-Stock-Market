<!-- 
  The Post Grid component is used to display an array of posts in a 3-column grid.
  NOTES:
  - The posts (Array) as passed into the component as a prop.  
  DEPENDENCIES:
    None
-->

<template>
  <div class="grid">
    <router-link
      v-bind:to="{ name: 'view-post', params: { id: post.id } }"
      v-for="post in posts"
      v-bind:key="post.id"
    >
      <img v-bind:key="post.id" v-bind:src="post.image" v-bind:alt="post.caption" class="photo" />
    </router-link>
  </div>
</template>

<script>
export default {
  name: "post-grid",
  props: {
    posts: Array
  }
};
</script>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-auto-rows: 100px;
  grid-gap: 3px;
}

.photo {
  width: 100%;
  min-height: 100px;
  max-height: 100px;
  object-fit: cover;
}

@media screen and (min-width: 768px) {
  .grid {
    grid-gap: 6px;
    grid-auto-rows: 150px;
  }

  .photo {
    min-height: 150px;
    max-height: 150px;
  }
}

@media screen and (min-width: 992px) {
  .grid {
    grid-gap: 10px;
    grid-auto-rows: 175px;
  }

  .photo {
    min-height: 175px;
    max-height: 175px;
  }
}
</style>
