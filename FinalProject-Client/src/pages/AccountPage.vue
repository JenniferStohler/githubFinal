<template>
  <div class="row d-flex justify-content-center">
    <img class="rounded" :src="account.picture" alt="" />
    <div class="col">
      <h1>Welcome {{ account.name }}</h1>
      <p>{{ account.email }}</p>
      <h1>
        Vaults:
      </h1>
      <div class="row">
        <h1>
          Keeps:
        </h1>
      </div>
    </div>
    <div class="row">
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
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
