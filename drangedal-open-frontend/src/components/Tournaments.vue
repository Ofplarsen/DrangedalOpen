<script setup lang="ts">
import { Match, Tournament } from "../api/schema";

interface Props {
  tournaments: Tournament[]
}
const { tournaments } = defineProps<Props>()


</script>

<template>
  <div class="grid grid-cols-7 gap-2 bg-gray-300">
    <div>Name</div>
  </div>
  <router-link class="grid grid-cols-7 gap-2 border border-black" v-for="tournament in tournaments" :to='"/tournament/" + tournament.tournamentGuid'>
    <div>{{tournament.name}}</div>
  </router-link>

</template>
