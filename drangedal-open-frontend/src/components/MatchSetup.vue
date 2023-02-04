<script setup lang="ts">
import {Match} from "../api/schema";

interface Props {
  matches: Match[]
}
const { matches } = defineProps<Props>()


</script>

<template>
  <div class="grid grid-cols-7 gap-2 bg-gray-300">
    <div>Home player</div>
    <div>Away player</div>
    <div>Home</div>
    <div>Away</div>
    <div>Type</div>
    <div>Match status</div>
  </div>
  <router-link class="grid grid-cols-7 gap-2 border border-black" v-for="match in matches" :to='"match/" + match.matchGuid'>
    <div>{{ match.homePlayer }}, {{ match.homePlayer }}</div>
    <div>{{ match.awayPlayer }}, {{ match.awayPlayer }}</div>
    <div>{{ match.homeScore }}</div>
    <div>{{ match.awayPlayer }}</div>
    <div>{{ match.matchRules.matchType }}</div>
    <div>Match status</div>
  </router-link>

</template>
