<template>
  <div class="modal" id="new-keep-form" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Keep
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form>
            <div class="form-group">
              <label for="recipient-name" class="col-form-label">Title:</label>

              <input type="text"
                     class="form-control"
                     id="title"
                     title="Keep Title..."
                     placeholder="Keep Title"
                     v-model="state.newKeep.title"
                     required
              >
            </div>
            <div class="form-group">
              <label for="message-text" class="col-form-label">Image URL:</label>

              <input type="text"
                     class="form-control"
                     id="image"
                     title="Keep Image URL..."
                     placeholder="Keep Image"
                     v-model="state.newKeep.image"
                     required
              >
            </div>
            <div class="form-group">
              <label for="message-text" class="col-form-label">Description:</label>

              <input type="text"
                     class="form-control"
                     id="description"
                     title="Keep Description..."
                     placeholder="Keep Description"
                     v-model="state.newKeep.description"
                     required
              >
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal" title="Close Modal">
                Close
              </button>
              <button type="submit" class="btn btn-success" title="Add New Keep">
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import $ from 'jquery'
export default {
  setup() {
    const state = reactive({
      newKeep: {}
    })
    return {
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
          $('#new-keep-form').modal('hide')
        } catch (error) {
          console.error(error)
        }
      }
    }
  },
  components: {}
}
</script>
