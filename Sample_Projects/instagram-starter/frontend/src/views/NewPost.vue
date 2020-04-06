<!-- 
  The New Post Page should allow the user to post a new photo.
  NOTES:
  - Images actually need to be hosted on an image hosting service (e.g. Cloudinary).
  - The component posts the image to Cloudinary using a 3rd party called dropzone.
  - The sharePhoto method POSTS a new Post with the hosted imageUrl
    and the caption that the user provides.
  DEPENDENCIES:
    Vue-DropZone
      Look for v-on:vdropzone-sending and v-on:vdropzone-success in the documentation
    Cloudinary These values need to be added as headers somehoe to the image upload
      (API Key: 714725446462368, Upload Preset: vg8sew4g)

-->

<template>
  <div id="new-post" class="container">
    <h2>Upload a photo to share</h2>
    <form id="post-form">
      <vue-dropzone id="dropzone" v-bind:options="dropzoneOptions"></vue-dropzone>
      <input
        type="text"
        name="caption"
        id="caption"
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
// Uncomment me for API Calls
//import auth from "@/shared/auth.js";

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
        // Destination
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
    canPost() {}
  },
  methods: {}
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
