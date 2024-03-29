import { InjectionKey } from 'vue'
import { createStore, useStore as baseUseStore, Store } from 'vuex'
import axios from '../requests/axios'
import {User} from "../api/schema";


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
      state.user = data.user
      localStorage.setItem('userData', JSON.stringify(data))
      state.token = data.token
    },

    //TODO: Fjern asynkron kode i mutations
    async CLEAR_USER_DATA(state) {
      state.user = undefined
      await localStorage.removeItem('userData')
    },
  },
  actions: {
    login({ commit }, data) {
      return axios.post('/login', data).then(response => {
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
