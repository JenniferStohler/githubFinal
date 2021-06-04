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

            <router-link :to="{name: 'KeepDetailsModal', params: {id: keepProp.id}}">
              <!-- <router-link :to="{name: 'Profile', params: {id: keepProp.id}}"> -->
              <img v-if="keepProp.img != null" :src="keepProp.img">
              <!-- <img class="rounded-circle small-img position-absolute" :src="keepProp.creator.img" alt="Creator Photo"> -->
              <div class="text-left">
              </div>
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Notification from '../utils/Notification'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Keep',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {

      async deleteKeep() {
        try {
          await keepsService.deleteKeep(props.keep.id)
          await keepsService.getAll()
        } catch (error) {
          Notification.toast(error, 'error')
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
