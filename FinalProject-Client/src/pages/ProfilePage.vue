<template>
  <div class="row">
    {{ profile }}
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
      profile: computed(() => AppState.profile)
    })
  }
}
</script>
<style scoped>
</style>
