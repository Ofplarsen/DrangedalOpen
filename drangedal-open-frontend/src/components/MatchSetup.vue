<script setup lang="ts">
import { Match, MatchDTO, MatchType } from "../api/schema";

interface Props {
  matches: MatchDTO[]
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
    <div>Score to win</div>
    <div>Winner</div>
  </div>
  <router-link class="grid grid-cols-7 gap-2 border border-black" v-for="match in matches" :to='"/match/" + match.matchGuid'>
    <div>{{ (match.homePlayer === null ? "TBA" : match.homePlayer) }}</div>
    <div>{{ (match.awayPlayer === null ? "TBA" : match.awayPlayer) }}</div>
    <div>{{ match.homeScore }}</div>
    <div>{{ match.awayScore }}</div>
    <div>{{ MatchType[match.matchRules.matchType] }}</div>
    <div>{{ match.matchRules.scoreToWin }}</div>
    <div>{{ match.winner }}</div>
  </router-link>

</template>
