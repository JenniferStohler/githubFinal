import { AppState } from '../AppState'
import router from '../router'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.keeps
  },
  async getActiveKeep(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data.keeps
  },

  async getByProfileId(id) {
    const res = await api.get(`api.keeps?creatorId=${id}`)
    AppState.activeKeeps = res.data.keeps
  }

}
export const keepsService = new KeepsService()