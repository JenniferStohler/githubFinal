<template>
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
</template>

<script>
import { computed, reactive, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService.js'

// Gets the Profile
export default {
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await profilesService.getProfile(route.params.id)
    })
    return reactive({
      profile: computed(() => AppState.activeProfile)
    })
  }
}
</script>
  <style scoped>
  </style>
