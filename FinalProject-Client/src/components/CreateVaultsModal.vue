<template>
  <div class="modal" id="new-vault-form" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Vault
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form>
            <div class="form-group">
              <label for="recipient-name" class="col-form-label">Title:</label>
              <input type="text" class="form-control" id="title">
            </div>
            <div class="form-group">
              <label for="message-text" class="col-form-label">Image URL:</label>
              <textarea class="form-control" id="image"></textarea>
            </div>
            <input type="checkbox"> Make this vault private.
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="submit" class="btn btn-success" @click="createVault">
            Submit
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import $ from 'jquery'
export default {
  setup() {
    const state = reactive({
      newVault: {}
    })
    return {
      state,
      async createVault() {
        try {
          debugger
          await vaultsService.createVault(state.newVault)
          // For some reason, it skips over state.newVault and throws an error.
          state.newVault = {}
          $('#new-vault-form').modal('hide')
        } catch (error) {
          console.error(error)
        }
      }
    }
  },
  components: {}
}
</script>
