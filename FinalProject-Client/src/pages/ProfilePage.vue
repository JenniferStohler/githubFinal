<template>
  <div class="text-center" v-if="state.activeProfile">
    <div class="row">
      <div class="col-12">
        <h1 class="text-dark">
          {{ state.activeProfile.name }}
        </h1>
        <div class="col">
          <h3 class="m-0">
            Vaults: {{ state.activeVaults.length }}
            Keeps: {{ state.activeKeeps.length }}
          </h3>
          <div class="modal" tabindex="-1">
            <div class="modal-dialog">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title">
                    Modal title
                  </h5>
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                  <p>Modal body text goes here.</p>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                    Close
                  </button>
                  <button type="button" class="btn btn-primary">
                    Save changes
                  </button>
                </div>
              </div>
            </div>
          </div>
          <div class="about text-center" v-if="state.activeProfile">
            <div class="col-12">
              <div class="d-flex">
                <img class="rounded-circle" :src="state.activeProfile.picture" alt="Profile Image">
                <div class="d-flex flex-column justify-content-centerr">
                  <h4 class="text-dark">
                    {{ state.activeProfile.name }}
                  </h4>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { accountService } from '../services/AccountService'
import Notification from '../utils/Notification'
import { logger } from '../utils/Logger'
import { useRoute } from 'vue-router'

export default {
  name: 'Account',
  setup() {
    const route = useRoute()
    const state = reactive({
      newKeep: {},
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      activeKeep: computed(() => AppState.activeKeep),
      activeProfile: computed(() => AppState.activeProfile)
    })

    onMounted(async() => {
      await keepsService.getByProfileId(route.params.id)
      await accountService.getProfile(route.params.id)
    })

    return {
      state,
      route,
      async Create() {
        try {
          await keepsService.Create(state.newKeep)
          state.newKeep = {}
          Notification.toast('Successfully Created a new Keep', 'success')
        } catch (error) {
          logger.log(error)
          Notification.toast('Error:' + error, 'error')
        }
      }
    }
  }
}
</script>
  <style scoped>
  </style>
