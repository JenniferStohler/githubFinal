<template>
  <div class="row container-fluid d-flex flex-wrap flex-growth justify-center">
    <div class="vaults col-12">
      <div class="card shadow p-3">
        <div class="card-body d-flex text-wrap justify-content-center p-4">
          <div class="text-wrap">
            <div class="text-wrap">
            </div>
            <div class="text-wrap">
              <!-- {{ keeps }} -->
              <div class="mr-1 text-left">
                <button type="btn btn-danger" @click="deleteVault(vaultProp.id)">
                  Delete
                </button>
              </div>
            </div>
            <div class="keep m-2 bg-white w-75 shadow">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { vaultsService } from '../services/VaultsService'
import Notification from '../utils/Notification'

export default {
  name: 'Vault',
  props: {
    vaultProp: {
      type: Array,
      required: true
    }
  },
  setup(props) {
    return {
      async deleteVault() {
        try {
          vaultsService.deleteVault(props.vault.id)
        } catch (error) {
          Notification.toast(error, 'error')
        }
      }
    }
  }
}

</script>
