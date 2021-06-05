
<template>
  <div class="vaults container">
    <div class="row">
      <div class="col">
        <h1>Vaults</h1>
        <button title="Create New Vault"
                type="button"
                class="btn btn-dark"
                data-toggle="modal"
                data-target="#new-vault-form"
                @click="createVault"
        >
          <i class="fas fa-plus text-success" aria-hidden="true" v-if="state.activeProfile.id == state.account.id"></i>
        </button>
      </div>
      <Vault v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
    </div>
    <div class="col-12 vaults float-container" v-if="state.account.id != $route.params.id">
      <VaultsComponent v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
    </div>
    <div class="row">
      <div class="col">
        <h1>Keeps</h1>
        <button title="Create New Keep"
                type="button"
                class="btn btn-dark"
                data-toggle="modal"
                data-target="#new-keep-form"
        >
          <i class="fas fa-plus text-success" aria-hidden="true" v-if="state.activeProfile.id == state.account.id"></i>
        </button>
      </div>
      <div class="row">
        <div class="col">
          <div class="card-columns">
            <KeepsComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
          </div>
          <CreateKeepModal />
          <CreateVaultsModal />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService'
import Notification from '../utils/Notification'
// import { logger } from '../utils/Logger'
import { useRoute } from 'vue-router'

export default {
  name: 'Account',
  setup() {
    const route = useRoute()
    const state = reactive({
      newKeep: {},
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      userVaults: computed(() => AppState.userVaults),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      activeProfile: computed(() => AppState.activeProfile)
    })

    onMounted(async() => {
      try {
        await profilesService.getActiveProfile(route.params.id)
        await profilesService.getProfileKeeps(route.params.id)
        await profilesService.getProfileVaults(route.params.id)
      } catch (error) {
        Notification.toast('Error:' + error, 'error')
      }
    })

    return {
      state,
      route
      // async createKeep() {
      //   try {
      //     await keepsService.createKeep(state.newKeep)
      //     state.newKeep = {}
      //     Notification.toast('Successfully Created a new Keep', 'success')
      //   } catch (error) {
      //     logger.log(error)
      //     Notification.toast('Error:' + error, 'error')
      //   }
      // }
    }
  }
}
</script>
  <style scoped>
  </style>
