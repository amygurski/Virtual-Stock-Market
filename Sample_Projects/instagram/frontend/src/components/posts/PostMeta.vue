<!-- 
  The Post Meta component is used provide additional UI detail and behavior about a post.
  This includes the number of likes, whether is liked or not, and whether it is favored or not
  NOTES:
  - The post that the component is for is passed in as a prop.
  - Upon clicking a heart or a bookmark icon an API call is made to 
    POST or DELETE a like OR
    POST or DELETE a favorite
  - Both heart/bookmark icons are in the component but only one is visible
  DEPENDENCIES:
    Font Awesome
-->

<template>
  <div class="post-meta">
    <div class="actions">
      <div class="like">
        <font-awesome-icon
          v-if="post.isLiked"
          v-bind:icon="['fas', 'heart']"
          v-on:click="updateLike(false)"
          size="lg"
          class="liked"
        />
        <font-awesome-icon
          v-else
          v-bind:icon="['far', 'heart']"
          v-on:click="updateLike(true)"
          size="lg"
          class="unliked"
        />
      </div>
      <div class="favor">
        <font-awesome-icon
          v-if="post.isFavored"
          v-bind:icon="['fas', 'bookmark']"
          v-on:click="updateFavor(false)"
          size="lg"
          class="favored"
        />
        <font-awesome-icon
          v-else
          v-bind:icon="['far', 'bookmark']"
          v-on:click="updateFavor(true)"
          size="lg"
          class="unfavored"
        />
      </div>
    </div>
    <p class="likes">{{ post.numberOfLikes }} likes</p>
  </div>
</template>

<script>
import auth from "@/shared/auth.js";

export default {
  name: "post-meta",
  props: {
    post: Object
  },
  methods: {
    /**
     * If TRUE, then "likes" the photo, FALSE then "unlikes" the photo
     * @function
     */
    updateLike(status) {
      const url = `${process.env.VUE_APP_REMOTE_API}/posts/${this.post.id}/likes`;
      const method = status ? "POST" : "DELETE";

      // Send the request as either POST or DELETE
      fetch(url, {
        method: method,
        headers: {
          Authorization: "Bearer " + auth.getToken()
        }
      })
        .then(response => response.json())
        .then(json => {
          // Update the number of likes depending on the response
          // Others may have liked this while the page was displayed
          this.post.numberOfLikes = json;
          this.post.isLiked = status;
        });
    },
    /**
     * If TRUE, then "favors" the photo, FALSE then "unfavors" the photo
     * @function
     */
    updateFavor(status) {
      const url = `${process.env.VUE_APP_REMOTE_API}/posts/${this.post.id}/favorites`;
      const method = status ? "POST" : "DELETE";

      // Send either POST or DELETE depending on status to update
      fetch(url, {
        method: method,
        headers: {
          Authorization: "Bearer " + auth.getToken()
        }
      }).then(response => {
        if (response.ok) {
          this.post.isFavored = status;
        }
      });
    }
  }
};
</script>

<style scoped>
.liked,
.unliked,
.favored,
.unfavored {
  cursor: pointer;
}

.liked {
  color: #ed4956;
}

.actions {
  display: flex;
  flex-direction: row;
  font-size: 16px;
}

.likes {
  margin-left: 0;
  font-size: 1rem;
}

.actions > * {
  flex: 1;
}

.like {
  text-align: left;
}

.favor {
  text-align: right;
}
</style>
