<!-- 
  The New Post Page should allow the user to post a new photo.
  NOTES:
  - Images actually need to be hosted on an image hosting service (e.g. Cloudinary).
  - The component posts the image to Cloudinary using a 3rd party called dropzone.
  - The sharePhoto method POSTS a new Post with the hosted imageUrl
    and the caption that the user provides.
  DEPENDENCIES:
    Vue-DropZone
    Cloudinary    
-->

<template>
  <div id="new-post" class="container">
    <h2>Upload a photo to share</h2>
    <form id="post-form" v-on:submit.prevent="sharePhoto">
      <vue-dropzone
        id="dropzone"
        v-bind:options="dropzoneOptions"
        v-on:vdropzone-sending="addFormData"
        v-on:vdropzone-success="getSuccess"
      ></vue-dropzone>
      <input
        type="text"
        name="caption"
        id="caption"
        v-model="post.caption"
        autocomplete="off"
        placeholder="Add a caption..."
      />
      <div class="form-actions">
        <button v-bind:disabled="!canPost" id="share">Share</button>
        <router-link to="/" tag="button">Cancel</router-link>
      </div>
    </form>
  </div>
</template>

<script>
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";
import auth from "@/shared/auth.js";

export default {
  name: "new-post",
  components: {
    vueDropzone: vue2Dropzone
  },
  data() {
    return {
      dropzoneOptions: {
        // https://danhough.com/blog/dropzone-cloudinary/
        // https://alligator.io/vuejs/vue-dropzone/
        url: "https://api.cloudinary.com/v1_1/tech-elevator/image/upload",
        thumbnailWidth: 250,
        maxFilesize: 2.0,
        acceptedFiles: ".jpg, .jpeg, .png, .gif",
        uploadMultipe: false
      },
      post: {
        image: "",
        caption: ""
      }
    };
  },
  computed: {
    canPost() {
      return this.post.caption && this.post.image;
    }
  },
  methods: {
    /**
     * Called before sending the request to add additional headers.
     * @function
     */
    addFormData(file, xhr, formData) {
      formData.append("api_key", "714725446462368");
      formData.append("upload_preset", "vg8sew4g");
      formData.append("timestamp", (Date.now() / 1000) | 0);
      formData.append("tags", "vue-app");
    },
    /**
     * Called after an upload success to get the image url.
     * @function
     */
    getSuccess(file, response) {
      this.post.image = response.secure_url;
    },
    /**
     * POSTs a new Post
     * @function
     */
    sharePhoto() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/posts`, {
        method: "POST",
        headers: {
          Authorization: "Bearer " + auth.getToken(),
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.post)
      })
        .then(response => {
          if (response.ok) {
            this.$router.push("/");
          }
        })
        .catch(err => {
          console.log(err);
        });
    }
  }
};
</script>

<style scoped>
h2 {
  text-align: center;
}
input[type="text"] {
  width: 100%;
  margin-top: 0.5rem;
  padding: 0.2rem 0;
}

button {
  background-color: transparent;
  color: #00adee;
  text-transform: uppercase;

  width: auto;
  min-width: auto;
  max-width: auto;
  padding-right: 0px;
}

#share {
  margin-right: 1rem;
  font-weight: bold;
}

#share:disabled {
  color: rgba(0, 173, 238, 0.5);
  font-weight: normal;
}

div.form-actions {
  display: flex;
  justify-content: flex-end;
  margin-top: 0.5rem;
}
</style>
