<template>
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
