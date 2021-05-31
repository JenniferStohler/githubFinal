<template>
</template>

<script>
import { vaultDetailsService } from '../services/VaultsService'
import Notification from '../utils/Notification'

export default {
  name: 'Vault',
  props: {
    vault: {
      type: Array,
      required: true
    }
  },
  setup(props) {
    return {
      async deleteVault(id) {
        try {
          vaultDetailsService.deleteVault(props.vault.id)
        } catch (error) {
          Notification.toast(error, 'error')
        }
      }
    }
  }
}

</script>
