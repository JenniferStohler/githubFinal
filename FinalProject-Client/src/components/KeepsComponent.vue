<template>
  <div class="row container-fluid d-flex flex-wrap flex-growth justify-center">
    <div class="keeps col-12">
      <div class="card shadow p-3">
        <div class="card-body d-flex text-wrap justify-content-center p-4">
          <div class="text-wrap">
            {{ keepProp.creator.name }}
            {{ keepProp.creator.img }}
            <div class="text-wrap">
              {{ keepProp.createdAt.slice(2,10) }}
            </div>
            <div class="text-wrap">
              <!-- {{ keeps }} -->
              <div class="mr-1 text-left">
                <button type="btn btn-danger" @click="deleteKeep(keepProp.id)">
                  Delete
                </button>
              </div>
            </div>
            <div class="keep m-2 bg-white w-75 shadow">
            </div>

            <!-- <router-link :to="{name: 'Profile', params: {id: keepProp.id}}"> -->
            <button type="button" class="btn btn-primary" data-toggle="modal" :data-target="`#keepView` + keepProp.id">
              <img v-if="keepProp.img != null" :src="keepProp.img">
            </button>
            <!-- <img class="rounded-circle small-img position-absolute" :src="keepProp.creator.img" alt="Creator Photo"> -->
            <div class="text-left">
            </div>
          </div>
        </div>
      </div>
    </div>
    <KeepDetailsModal :keep-prop="keepProp" />
  </div>
</template>

<script>

import Notification from '../utils/Notification'
import { keepsService } from '../services/KeepsService'
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
export default {
  name: 'Keep',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep)
    })
    return {
      state,
      async deleteKeep(id) {
        try {
          if (await Notification.confirmAction('Are You Sure You Want to Delete This?')) {
            await keepsService.deleteKeep(id)
            await keepsService.getAll()
            Notification.toast('Keep Deleted', 'success')
          }
        } catch (error) {
          Notification.toast(error, 'error')
        }
      },
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
          Notification.toast('Successfully Created a new Keep', 'success')
        } catch (error) {
          logger.log(error)
          Notification.toast('Error:' + error, 'error')
        }
      }
    }
  }
}
</script>

<style scoped>
img{
  max-width: 300px;

}
</style>
