import { AppState } from '../AppState.js'
import router from 'vue-router'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    const res = await api.get('vaults')
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get('vaults/' + id)
    AppState.activeVault = res.data
  }

  async createVault(newVault) {
    const res = await api.post('vaults', newVault)
    router.push({ name: 'Vaults', params: { id: res.data.id } })
    console.log(res.data.id)
  }
  // createVault function pushes to Axios instead of Vaults for some reason
  // async editVault(id) {
  //   const res = await api.put('vaults' + vault.id, vault)
  //   AppState
  // }

  async deleteVault(id) {
    await api.delete('vaults/' + id)
    AppState.vaults = AppState.vaults.filter(vault => vault.id !== id)
  }
}
export const vaultsService = new VaultsService()
