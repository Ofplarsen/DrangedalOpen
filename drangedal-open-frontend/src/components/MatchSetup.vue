<script setup lang="ts">
import {Match} from "../api/schema";

interface Props {
  matches: Match[]
}
const { matches } = defineProps<Props>()


</script>

<template>
  <div class="grid grid-cols-7 gap-2 bg-gray-300">
    <div>Date</div>
    <div>Home player</div>
    <div>Away player</div>
    <div>Home</div>
    <div>Away</div>
    <div>Type</div>
    <div>Match status</div>
  </div>
  <router-link class="grid grid-cols-7 gap-2 border border-black" v-for="match in matches" :to='"match/" + match.matchId'>
    <div>{{ match.date }}</div>
    <div>{{ match.home[0].lastName }}, {{ match.home[0].firstName }}</div>
    <div>{{ match.away[0].lastName }}, {{ match.away[0].firstName }}</div>
    <div>{{ match.scoreHome }}</div>
    <div>{{ match.scoreAway }}</div>
    <div>{{ match.type }}</div>
    <div>Match status</div>
  </router-link>

</template>
