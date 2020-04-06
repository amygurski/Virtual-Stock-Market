<!-- 
  The View Post Page should allow the user to view a post in more detail.
  NOTES:
    - Upon creating this page, a GET request is made to retrieve a single post by id.
    - The post is fed into child components to display author, comments, actions, etc.
    - 
  DEPENDENCIES:
    PostAuthor
    CommentFeed
    PostMeta
    NewComment
-->

<template>
  <div id="post" class="container">
    <img v-bind:src="post.image" v-bind:alt="post.caption" class="post-photo" />
    <div class="post-details">
      <post-author v-bind:userName="post.userName" v-bind:userImage="post.userImage" />
      <comment-feed v-bind:post="post" />
      <post-meta v-bind:post="post" />
      <new-comment v-bind:post="post" v-on:newComment="handleNewComment" />
    </div>
  </div>
</template>

<script>
import PostAuthor from "@/components/posts/PostAuthor.vue";
import PostMeta from "@/components/posts/PostMeta.vue";
import NewComment from "@/components/comments/NewComment.vue";
import CommentFeed from "@/components/comments/CommentFeed.vue";
import auth from "@/shared/auth.js";

export default {
  name: "view-post",
  components: {
    PostAuthor,
    PostMeta,
    NewComment,
    CommentFeed
  },
  data() {
    return {
      post: {}
    };
  },
  methods: {
    /**
     * When the new comment component successfully saves the comment
     * the ViewPost adds the comment to the post to update the UI.
     */
    handleNewComment(commentObject) {
      this.post.comments.push(commentObject);
    }
  },
  /**
   * Fetches the post using the id passed in the route.
   */
  created() {
    // Get the post id out of the url
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/posts/${id}`, {
      method: "GET",
      headers: {
        Authorization: "Bearer " + auth.getToken()
      }
    })
      .then(response => response.json())
      .then(json => {
        this.post = json;
      });
  }
};
</script>

<style scoped>
#post {
  display: flex;
  flex-direction: column;
  margin-top: 1rem;
}

.post-details {
  margin-top: 0.5rem;
}

.post-author,
.comments,
.post-meta,
.new-comment {
  padding-left: 0.5rem;
  padding-right: 0.5rem;
}

.poster,
.comments,
.post-meta {
  border-bottom: 1px solid #eee;
  padding-top: 0.5rem;
  padding-bottom: 0.5rem;
}

.new-comment {
  padding-top: 0.5rem;
  padding-bottom: 2rem;
}

.author {
  font-weight: bold;
}

.post-photo {
  width: 100%;
  height: auto;
}

p {
  font-size: 0.9rem;
}

@media screen and (min-width: 768px) {
  #post {
    flex-direction: row;
  }

  .post-photo {
    max-width: 60%;
    align-self: flex-start;
  }

  .post-details {
    margin-top: initial;
    margin-left: 0.5rem;
  }
}
</style>
