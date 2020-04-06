<template>
  <default-layout>
    <h1>{{ getPageTitle }}</h1>
    <p>{{ getPageDescription }}</p>
    <form class="needs-validation" @submit.prevent="onSubmit" novalidate>
      <div class="form-group">
        <input
          type="description"
          class="form-control"
          :class="{ 'is-invalid': errors.includes('description') }"
          id="description"
          placeholder="Snippet Description..."
          v-model="snippet.description"
        />
        <div class="invalid-feedback">Please provide a valid description.</div>
      </div>
      <div class="card">
        <div class="card-header">
          <div class="form-row">
            <div class="col-4">
              <input
                type="text"
                class="form-control"
                :class="{ 'is-invalid': errors.includes('filename') }"
                id="filename"
                placeholder="Filename including extension..."
                v-model="snippet.filename"
              />
              <div class="invalid-feedback">
                Please provide a valid filename with an extension.
              </div>
            </div>
            <div class="col-4">&nbsp;</div>
            <div class="col-4">
              <input
                type="text"
                class="form-control"
                :class="{ 'is-invalid': errors.includes('tags') }"
                id="tags"
                placeholder="Tags (Comma Seperated)"
                v-model="snippet.tags"
              />
              <div class="invalid-feedback">Please enter at least one tag.</div>
            </div>
          </div>
        </div>
        <textarea
          class="form-control"
          :class="{ 'is-invalid': errors.includes('sourceCode') }"
          id="sourceCode"
          rows="20"
          v-model="snippet.sourceCode"
        ></textarea>
        <div class="invalid-feedback">
          Please provide the snippet source code.
        </div>
      </div>
      <div class="float-right">
        <button type="submit" class="btn btn-primary mb-2">Save Snippet</button>
      </div>
    </form>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '@/auth';

export default {
  name: 'AddSnippet',
  components: {
    DefaultLayout,
  },
  data() {
    return {
      snippet: {
        description: '',
        filename: '',
        tags: '',
        sourceCode: '',
      },
      errors: [],
      formSubmitted: false,
    };
  },
  methods: {
    onSubmit() {
      this.formSubmitted = true;
      this.validateForm();
      // if all fields are valid submit the form
      if (!this.errors.length) {
        const snippetId = this.$route.params.id;
        const apiEndpoint = this.isEditForm ? `api/snippets/${snippetId}` : 'api/snippets/';
        fetch(`${process.env.VUE_APP_REMOTE_API}/${apiEndpoint}`, {
          method: this.isEditForm ? 'PUT' : 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: 'Bearer ' + auth.getToken(),
          },
          body: JSON.stringify(this.snippet),
        })
          .then((response) => {
            if (response.ok) {
              this.$router.push({ path: '/' });
            }
          })
          .catch((err) => console.error(err));
      }
    },
    validateForm() {
      this.errors = [];
      Object.entries(this.snippet).forEach((field) => {
        if (field[1] === '') {
          this.errors.push(field[0]);
        }
      });
      // the filename must include an extension
      console.log(this.snippet.filename.includes('.'));
      if (!this.snippet.filename.includes('.')) {
        this.errors.push('filename');
      }
    },
  },
  created() {
    if (this.isEditForm) {
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
    }
  },
  computed: {
    isEditForm() {
      return this.$route.params.id === undefined ? false : true;
    },
    getPageTitle() {
      return this.isEditForm ? 'Edit Snippet' : 'Add New Snippet';
    },
    getPageDescription() {
      return this.editForm
        ? 'Use this form to edit a snippet in your collection.'
        : 'Use this form to add a snippet to your collection.';
    },
  },
};
</script>

<style>
.btn {
  margin-top: 20px;
}
::placeholder {
  color: rgb(187, 187, 187) !important;
}
textarea {
  border: none !important;
}
#sourceCode {
  font-family: SFMono-Regular, Consolas, Liberation Mono, Menlo, Courier, monospace;
  font-size: 12px;
  line-height: 1.5;
}
.invalid-feedback {
  text-align: left;
}
</style>
