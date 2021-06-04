<template>
  <div class="keeps-details container flex-grow text-wrap" v-if="state.keep">
    <router-link :to="{name:'Profile', params: {id: state.keep.creator.id}}">
      <img class="rounded-circle" :src="state.keep.creator.img" alt="Creator image">
    </router-link>
    {{ state.keep.creator }}
  </div>
</template>
<script>

import { computed, onMounted, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'

export default {
  name: 'KeepsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: [],
      project: computed(() => AppState.activeKeep),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)
    })

    onMounted(async() => {
      try {
        await keepsService.getAll()
        state.loading = false
      } catch (error) {
        console.log(error)
      }
    })

    onMounted(async() => {
      try {
        await keepsService.getActive(route.params.id)
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state,
      route,
      async addKeep() {
        try {
          await keepsService.addKeep(route.params.id, state.keep)
          state.keep = []
          Notification.toast('Keep Added!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  },
  components: {}
}

</script>
