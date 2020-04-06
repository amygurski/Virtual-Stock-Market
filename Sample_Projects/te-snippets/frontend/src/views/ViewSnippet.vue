<template>
  <default-layout>
    <div id="snippet">
      <h1>{{ snippet.filename }}</h1>
      <p>{{ snippet.description }}</p>

      <div class="row align-items-center">
        <div class="col">
          <span class="badge badge-info" v-for="tag in snippet.tags.split(',')" :key="tag">{{
            tag
          }}</span>
        </div>
        <div class="col">
          <router-link
            :to="{ name: 'save', params: { id: snippet.id } }"
            tag="button"
            class="btn btn-outline-primary btn-sm float-right"
          >
            Edit Snippet
          </router-link>
        </div>
      </div>
      <pre v-highlightjs="snippet.sourceCode"><code :class="getCodeLanguage"></code></pre>
      <router-link to="/" tag="button" class="btn btn-primary">Go Back</router-link>
      <br /><br />
    </div>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '@/auth';

export default {
  name: 'ViewSnippet',
  components: {
    DefaultLayout,
  },
  data() {
    return {
      sourcecode: '',
      snippet: {
        description: '',
        filename: '',
        sourceCode: '',
        tags: '',
      },
    };
  },
  created() {
    const snippetId = this.$route.params.id;
    fetch(`${process.env.VUE_APP_REMOTE_API}/api/snippets/${snippetId}`, {
      method: 'GET',
      headers: new Headers({
        Authorization: 'Bearer ' + auth.getToken(),
      }),
      credentials: 'same-origin',
    })
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          // no reason to be here send them back to the list view
          this.$router.push({ path: '/' });
        }
      })
      .then((data) => {
        this.snippet = data;
      })
      .catch((err) => console.error(err));
  },
  computed: {
    getCodeLanguage() {
      return this.snippet.filename.split('.')[1];
    },
  },
};
</script>

<style>
.lead {
  margin-bottom: 0px;
}
pre {
  margin-top: 20px !important;
}
</style>
