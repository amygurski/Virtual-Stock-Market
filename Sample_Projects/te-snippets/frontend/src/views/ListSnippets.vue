<template>
  <default-layout>
    <div id="snippets">
      <h1>List Snippets</h1>
      <p>This page will list all of your snippets.</p>
      <table class="table table-striped">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Filename</th>
            <th scope="col">Description</th>
            <th scope="col">Tags</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="snippet in snippets" :key="snippet.id">
            <td>{{ snippet.filename }}</td>
            <td>{{ snippet.description }}</td>
            <td class="align-middle">
              <span class="badge badge-info" v-for="tag in getTagsList(snippet.tags)" :key="tag">{{
                tag
              }}</span>
            </td>
            <td class="align-middle actions">
              <router-link
                :to="{ name: 'snippet', params: { id: snippet.id } }"
                tag="button"
                class="btn btn-outline-primary btn-sm"
                >View</router-link
              >
              <router-link
                :to="{ name: 'save', params: { id: snippet.id } }"
                tag="button"
                class="btn btn-outline-primary btn-sm"
                >Edit</router-link
              >
              <b-button
                variant="outline-danger"
                size="sm"
                @click="deleteSnippetId = snippet.id"
                v-b-modal.confirmDelete
                >Delete</b-button
              >
            </td>
          </tr>
        </tbody>
      </table>

      <!-- Modal Component -->
      <b-modal
        id="confirmDelete"
        title="Delete Snippet"
        ok-title="Delete Snippet"
        @ok="deleteSnippet"
      >
        <p class="my-4">Are you sure you want to delete this snippet?</p>
      </b-modal>
    </div>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';

export default {
  name: 'ListSnippets',
  components: {
    DefaultLayout,
  },
  data() {
    return {
      snippets: [],
      deleteSnippetId: null,
    };
  },
  methods: {
    deleteSnippet() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/api/snippets/${this.deleteSnippetId}`, {
        method: 'DELETE',
        headers: {
          Authorization: 'Bearer ' + auth.getToken(),
        },
        credentials: 'same-origin',
      })
        .then((response) => {
          if (response.ok) {
            const index = this.snippets.map((snippet) => snippet.id).indexOf(this.deleteSnippetId);
            this.snippets.splice(index, 1);
          }
          this.deleteSnippetId = null;
        })
        .catch((err) => console.error(err));
    },
    getTagsList(tags) {
      if (tags != undefined) {
        return tags.split(',');
      }
    },
  },
  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/api/snippets/`, {
      method: 'GET',
      headers: {
        Authorization: 'Bearer ' + auth.getToken(),
      },
      credentials: 'same-origin',
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.snippets = data;
      })
      .catch((err) => console.error(err));
  },
};
</script>

<style>
button {
  margin-right: 5px !important;
}
span.badge {
  margin-right: 5px;
}
.actions .btn {
  margin-top: 0px;
}
</style>
