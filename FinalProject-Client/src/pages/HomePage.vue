<template>
  <div class="row d-flex justify-content-center">
    <div class="card-columns m-5">
      <div class="card">
        <img src="https://images.unsplash.com/photo-1490709501740-c7ac36b7d587?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title">
            Card title that wraps to a new line
          </h5>
          <p class="card-text">
            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
          </p>
        </div>
      </div>
      <div class="card p-3">
        <blockquote class="blockquote mb-0 card-body">
          <p>A well-known quote, contained in a blockquote element.</p>
          <footer class="blockquote-footer">
            <small class="text-muted">
              Someone famous in <cite title="Source Title">Source Title</cite>
            </small>
          </footer>
        </blockquote>
      </div>
      <div class="card">
        <img src="https://images.unsplash.com/photo-1490709501740-c7ac36b7d587?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title">
            Card title
          </h5>
          <p class="card-text">
            This card has supporting text below as a natural lead-in to additional content.
          </p>
          <p class="card-text">
            <small class="text-muted">Last updated 3 mins ago</small>
          </p>
        </div>
      </div>
      <div class="card bg-primary text-white text-center p-3">
        <blockquote class="blockquote mb-0">
          <p>A well-known quote, contained in a blockquote element.</p>
          <footer class="blockquote-footer text-white">
            <small>
              Someone famous in <cite title="Source Title">Source Title</cite>
            </small>
          </footer>
        </blockquote>
      </div>
      <div class="card text-center">
        <div class="card-body">
          <h5 class="card-title">
            Card title
          </h5>
          <p class="card-text">
            This card has a regular title and short paragraphy of text below it.
          </p>
          <p class="card-text">
            <small class="text-muted">Last updated 3 mins ago</small>
          </p>
        </div>
      </div>
      <div class="card">
        <img src="https://images.unsplash.com/photo-1490709501740-c7ac36b7d587?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80" class="card-img" alt="...">
      </div>
      <div class="card p-3 text-right">
        <blockquote class="blockquote mb-0">
          <p>A well-known quote, contained in a blockquote element.</p>
          <footer class="blockquote-footer">
            <small class="text-muted">
              Someone famous in <cite title="Source Title">Source Title</cite>
            </small>
          </footer>
        </blockquote>
      </div>
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">
            Card title
          </h5>
          <p class="card-text">
            This is another card with title and supporting text below. This card has some additional content to make it slightly taller overall.
          </p>
          <p class="card-text">
            <small class="text-muted">Last updated 3 mins ago</small>
          </p>
        </div>
      </div>
    </div>
  </div>
  <Keep v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
</template>

<script>

import { onMounted, reactive, computed } from 'vue'
import Notification from '../utils/Notification'
// import { vaultDetailsService } from '../services/VaultDetailsService'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'

export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps)
      // vaults: computed(() => AppState.vaults)
    })
    onMounted(async() => {
      try {
        await keepsService.getAll()
        // await vaultDetailsService.getVaults()
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state
    }
  }
}

</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
