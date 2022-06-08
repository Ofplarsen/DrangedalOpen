<script setup lang="ts">
import NavBar from './components/NavBar.vue'
import BaseBanner from './components/base/BaseBanner.vue'
import { store } from './store'
import TopNavBar from './components/TopNavBar.vue'
const { dispatch } = store
</script>

<template>
  <div>
    <TopNavBar class="hidden md:block" />
    <div class="h-16 hidden md:block"></div>
    <div class="container mx-auto p-4">
      <router-view></router-view>
    </div>
    <div class="h-20 md:hidden"></div>
    <NavBar class="md:hidden" />
  </div>
</template>
