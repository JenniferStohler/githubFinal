
<script>

import { computed, onMounted, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'

export default {
  name: 'Vaults',
  setup() {
    const route = useRoute()
    const state = reactive({
      vaults: computed(() => AppState.vaults),
      activeVault: computed(() => AppState.activeVault),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)

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
      async addVault() {
        try {
          await vaultsService.addVault(route.params.id, state.vault)
          state.vault = []
          Notification.toast('Vault Added!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  }
}

</script>
