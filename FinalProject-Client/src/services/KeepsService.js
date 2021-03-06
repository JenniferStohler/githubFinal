import { AppState } from '../AppState'
import router from '../router'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
    console.log(res.data)
  }

  async getByProfileId(id) {
    const res = await api.get(`api/keeps?creatorId=${id}`)
    AppState.activeKeeps = res.data
  }

  async getActive(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    router.push({ name: 'Account', params: { id: res.data.id } })
    console.log(res.data.id)
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
  }
}
export const keepsService = new KeepsService()
