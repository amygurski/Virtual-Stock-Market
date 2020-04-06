<!-- 
  The Comment Feed component is used to the caption and a list of comments associated with a post.
  NOTES:
  - The post is passed in as a prop.
  - The timestamp for each post is in the format of "2019-03-29T12:44:34.907", so something called
    a FILTER is used to transform that value to a human readable format (e.g. 20 min ago)
  DEPENDENCIES:
    None 
-->

<template>
  <div class="comments">
    <div class="comment">
      <img v-bind:src="post.userImage" v-bind:alt="post.userName" class="profile-photo small" />
      <div>
        <p class="caption">
          <span class="author">{{ post.userName }}</span> {{ post.caption }}
        </p>
        <p class="timestamp">
          {{ post.dateTimeStamp | formatDate }}
        </p>
      </div>
    </div>
    <div class="comment" v-for="comment in post.comments" v-bind:key="comment.id">
      <img
        v-bind:src="comment.userImage"
        v-bind:alt="comment.userName"
        class="profile-photo small"
      />
      <div>
        <p class="caption">
          <span class="author">{{ comment.userName }}</span>
          {{ comment.message }}
        </p>
        <p class="timestamp">
          {{ comment.dateTimeStamp | formatDate }}
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "comment-feed",
  props: {
    post: Object
  },
  filters: {
    /**
     * Accepts a timestamp and formats it to a user-friendly value based on the delta between now
     * and the time of the comment.
     * @function
     */
    formatDate(value) {
      const seconds = Math.floor((new Date() - new Date(value)) / 1000);

      let interval = Math.floor(seconds / 31536000);

      if (interval > 1) {
        return interval + " year(s) ago";
      }

      interval = Math.floor(seconds / 2592000);
      if (interval >= 1) {
        return interval + " month(s) ago";
      }
      interval = Math.floor(seconds / 86400);
      if (interval >= 1) {
        return interval + " day(s) ago";
      }
      interval = Math.floor(seconds / 3600);
      if (interval >= 1) {
        return interval + " hour(s) ago";
      }
      interval = Math.floor(seconds / 60);
      if (interval >= 1) {
        return interval + " minute(s) ago";
      }
      return Math.floor(seconds) + " seconds ago";
    }
  }
};
</script>

<style scoped>
.comment {
  display: flex;
  flex-direction: row;
  align-items: center;
}
.profile-photo {
  margin-right: 1rem;
}

.timestamp {
  color: #bbb;
  font-size: 0.9rem;
}
</style>
