import { InjectionKey } from 'vue'
import { createStore, useStore as baseUseStore, Store } from 'vuex'
import axios from 'axios'

export interface User {
  id: number
  firstName: string
  lastName: string
  username: string
  email: string
  address: string
  postalcode: string
  phonenumber: string
  pictureUrl?: string
  verified: boolean
  trusted: boolean
}

export interface State {
  user?: User
  token?: string
}

export const key: InjectionKey<Store<State>> = Symbol()

export const store = createStore<State>({
  state: {
    user: undefined,
    token: undefined,
  },

  getters: {
    loggedIn(state) {
      return !!state.user
    },
  },

  mutations: {
    SET_USER_DATA(state, data) {
      console.log(data)
      state.user = data.userDTO
      localStorage.setItem('userData', JSON.stringify(data))
      axios.defaults.headers.common['authorization'] =
          'Bearer ' + data.token
    },

    //TODO: Fjern asynkron kode i mutations
    async CLEAR_USER_DATA(state) {
      state.user = undefined
      await localStorage.removeItem('userData')
    },
  },
  actions: {
    login({ commit }, data) {
      return axios.post('/user/login', data).then(response => {
        commit('SET_USER_DATA', response.data)
        console.log(response)
      })
    },
    logout({ commit }) {
      commit('CLEAR_USER_DATA')
    },
  },
})

export function useStore() {
  return baseUseStore(key)
}