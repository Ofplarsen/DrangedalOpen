import { createApp } from 'vue'
import App from './App.vue'
import './index.css'
import router from './router'
import { store, key } from './store'
import './requests/axios'

createApp(App).use(store, key).use(router).mount('#app')

