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
          <i class="fas fa-plus">+</i>
        </button>
      </div>
      <!-- <Vault v-for="vault in state.vaults" :key="vault.id" :vault="vault" /> -->
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
          <i class="fas fa-plus">+</i>
        </button>
      </div>
    </div>
    <!-- <Keep v-for="keep in state.keeps" :key="keep.id" :keep="keep" /> -->
    <CreateKeepModal />
    <CreateVaultsModal />
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
      // keepProp: computed(() => AppState.keepProp),
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
