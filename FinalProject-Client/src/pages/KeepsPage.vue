<template>
</template>

<script>

import { computed, onMounted, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
import { AppState } from '..AppState'

export default {
  name: 'KeepsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      keep: [],
      project: computed(() => AppState.activeKeep),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps)
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
  }
}

</script>
