import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfilesService {
  async getActiveProfile(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.activeProfile = res.data
  }

  async getProfileKeeps(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.profileKeeps = res.data
  }

  async getProfileVaults(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.profileVaults = res.data
    console.log(res.data)
  }

  async getUserVaults() {
    const res = await api.get('account/vaults')
    AppState.userVaults = res.data
  }
}
export const profilesService = new ProfilesService()
