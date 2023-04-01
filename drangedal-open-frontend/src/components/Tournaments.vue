<script setup lang="ts">
import { Match, Tournament } from "../api/schema";

interface Props {
  tournaments: Tournament[]
}
const { tournaments } = defineProps<Props>()


</script>

<template>
  <div class="bg-gray-300 p-6 rounded-lg shadow-lg">
    <div class="grid grid-cols-1 gap-4 font-semibold mb-4">
      <div>Name</div>
    </div>
    <router-link
      class="grid grid-cols-1 gap-4 py-2 border-b border-gray-400 hover:bg-gray-200 transition-colors duration-200"
      v-for="tournament in tournaments"
      :key="tournament.tournamentGuid"
      :to="'/tournament/' + tournament.tournamentGuid"
    >
      <div>{{ tournament.name }}</div>
    </router-link>
  </div>
</template>

