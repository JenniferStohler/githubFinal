
<script>

import { computed, onMounted, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'

export default {
  name: 'VaultsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      vault: [],
      project: computed(() => AppState.activeVault),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults)
    })

    onMounted(async() => {
      try {
        await vaultsService.getAll()
        state.loading = false
      } catch (error) {
        console.log(error)
      }
    })

    onMounted(async() => {
      try {
        await vaultsService.getActive(route.params.id)
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state,
      route,
      async createVault() {
        try {
          await vaultsService.createVault(route.params.id, state.vault)
          state.vault = []
          Notification.toast('Keep Added!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  }
}

</script>
