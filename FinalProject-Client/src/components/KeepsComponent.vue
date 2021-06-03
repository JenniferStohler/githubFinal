<template>
  <div class="row container-fluid d-flex flex-wrap flex-growth justify-center">
    <div class="keeps col-4"></div>
    <div class="col-4 position-center">
      <div class="card d-flex flex-grow p-2">
        <div class="card-body d-flex flex-wrap flex-growth text-wrap justify-content-center p-4">
          <div class="text-wrap">
            {{ keep.creator.name }}
            <div class="text-wrap">
              {{ keep.createdAt }}
            </div>
            <div class="text-wrap">
              {{ keeps }}
              <div class="mr-1 text-left">
                <button type="btn btn-danger" @click="deleteKeep(keep.id)">
                  Delete
                </button>
              </div>
            </div>
            <div class="keep m-2 bg-white w-75 shadow">
            </div>

            <router-link :to="{name: 'Profile', params: {id: keep.creator.id}}">
              <img v-if="keep.imgUrl != null" :src="keep.imgUrl">
              <img class="rounded-circle small-img position-absolute" :src="keep.creator.picture" alt="Creator Photo">
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
    keepsProp: {
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
