/* eslint-disable-next-line no-unused-vars */
import { mount, shallowMount, Wrapper, createLocalVue } from '@vue/test-utils';
import ListSnippets from '@/views/ListSnippets.vue';
import fetchMock from 'fetch-mock';
import BModal from 'bootstrap-vue/es/components/modal/modal';
import BootstrapVue from 'bootstrap-vue';

import chai from 'chai';
chai.should();

const localVue = createLocalVue();
localVue.directive('b-modal', BModal);
localVue.use(BootstrapVue);

describe('ListSnippets.vue', () => {
  /** @type Wrapper */
  let wrapper;
  let snippets;

  before(() => {
    fetchMock.config.overwriteRoutes = true;
    snippets = [
      {
        id: 1,
        filename: 'HelloWorld.vue',
        description: 'This is my very first snippet',
        tags: 'vue,javascript',
        sourceCode: 'const msg = "Hello, World!";',
      },
    ];
  });

  beforeEach(() => {
    fetchMock.get('http://localhost:8080/TESnippets/api/snippets/', {});

    wrapper = mount(ListSnippets, {
      localVue,
      stubs: ['router-link', 'router-view'],
      //stubs: ['router-link', 'router-view', 'b-modal', 'b-button', 'b-modal'],
    });
    wrapper.setData({ snippets });
  });

  it('should be a Vue instance', () => {
    wrapper.isVueInstance().should.be.true;
  });

  it('component name should equal ListSnippets', () => {
    wrapper.name().should.equal('ListSnippets');
  });

  it('adding a snippet should display the correct snippet in the list', () => {
    wrapper
      .findAll('table tbody tr td')
      .at(0)
      .text()
      .should.equal('HelloWorld.vue');
    wrapper
      .findAll('table tbody tr td')
      .at(1)
      .text()
      .should.equal('This is my very first snippet');
    wrapper
      .findAll('table tbody tr td')
      .at(2)
      .html()
      .includes(
        '<span class="badge badge-info">vue</span><span class="badge badge-info">javascript</span>'
      );
  });

  it('list of snippets should equal 1', () => {
    wrapper.findAll('table tbody tr').length.should.equal(1);
  });

  it('should delete a snippet when the the delete modal is clicked on.', () => {
    fetchMock.delete('*', 200);
    wrapper.setData({ deleteSnippetId: 1 });
    wrapper.vm.deleteSnippet();
    wrapper.setData({ snippets: [] });
    wrapper.findAll('table tbody tr').length.should.equal(0);
  });
});
