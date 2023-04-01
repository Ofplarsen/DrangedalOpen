<script setup lang="ts">
import { Match, MatchDTO, MatchType } from "../api/schema";

interface Props {
  matches: MatchDTO[]
}
const { matches } = defineProps<Props>()

function isUpcomingMatch(match: any) {
  return match.homePlayer !== null && match.awayPlayer !== null
}

function isCompletedMatch(match: any) {
  return match.winner !== null && match.winner !== ''
}

</script>
<template>
  <div class="bg-gray-300 p-6 rounded-lg shadow-lg">
    <div class="grid grid-cols-7 gap-4 font-semibold mb-4">
      <div>Home player</div>
      <div>Away player</div>
      <div>Home</div>
      <div>Away</div>
      <div>Type</div>
      <div>Score to win</div>
      <div>Winner</div>
    </div>
    <router-link
      class="grid grid-cols-7 gap-4 py-2 border-b border-gray-400 transition-colors duration-200"
      :class="{
        'hover:bg-gray-200': !isUpcomingMatch(match) && !isCompletedMatch(match),
        'bg-green-200 hover:bg-green-300': isUpcomingMatch(match),
        'bg-blue-200 hover:bg-blue-300': isCompletedMatch(match),
      }"
      v-for="match in matches"
      :key="match.matchGuid"
      :to="'/match/' + match.matchGuid"
    >
      <div>{{ match.homePlayer === null ? "TBA" : match.homePlayer }}</div>
      <div>{{ match.awayPlayer === null ? "TBA" : match.awayPlayer }}</div>
      <div>{{ match.homeScore }}</div>
      <div>{{ match.awayScore }}</div>
      <div>{{ MatchType[match.matchRules.matchType] }}</div>
      <div>{{ match.matchRules.scoreToWin }}</div>
      <div>{{ match.winner }}</div>
    </router-link>
  </div>
</template>

