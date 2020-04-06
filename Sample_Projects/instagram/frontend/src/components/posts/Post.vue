<!-- 
  The Post component renders all of the contents of a post in a vertical manner.
  NOTES:
  - The post prop holds the actual object getting rendered.
  - The component heavily relies on other components to perform the more specific details.
  DEPENDENCIES:
    PostAuthor (passes username and userimage)
    PostMeta (passes the post object)
-->

<template>
  <div class="post">
    <post-author v-bind:userName="post.userName" v-bind:userImage="post.userImage" />
    <router-link :to="{ name: 'view-post', params: { id: post.id } }">
      <img v-bind:src="post.image" v-bind:alt="post.caption" class="post-photo" />
    </router-link>
    <post-meta v-bind:post="post" />
    <p class="caption">
      <span class="author">{{ post.userName }}</span> {{ post.caption }}
    </p>
    <router-link class="view-comments" :to="{ name: 'view-post', params: { id: post.id } }">
      View all comments
    </router-link>
  </div>
</template>

<script>
import PostAuthor from "@/components/posts/PostAuthor.vue";
import PostMeta from "@/components/posts/PostMeta.vue";

export default {
  name: "post",
  components: {
    PostAuthor,
    PostMeta
  },
  props: {
    post: Object
  }
};
</script>

<style scoped>
.post {
  display: flex;
  flex-direction: column;
}

.post > * {
  margin-bottom: 0.5rem;
  margin-left: 0;
}

.post-photo {
  width: 100%;
  height: auto;
}

.poster,
.caption .author {
  font-weight: bold;
}

.view-comments {
  color: #bbb;
}
</style>
