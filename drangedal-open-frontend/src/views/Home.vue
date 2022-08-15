<script setup lang="ts">
import {Match, MatchType, User} from "../api/schema";
import MatchSetup from "../components/MatchSetup.vue";

const users: User[] = [

]

const matches: Match[] = [
    /*
  {
    matchId: 1,
    date: "date",
    home: [users[0]],
    away: [users[1]],
    scoreHome: 0,
    scoreAway: 0,
    type: MatchType.SemiFinal
  },
  {
    matchId: 0,
    date: "date",
    home: [users[0]],
    away: [users[0]],
    scoreHome: 0,
    scoreAway: 0,
    type: MatchType.SemiFinal
  },
  {
    matchId: 2,
    date: "date",
    home: [users[1]],
    away: [users[0]],
    scoreHome: 0,
    scoreAway: 0,
    type: MatchType.Final
  }

     */
]
</script>

<template>
  <div class="grid grid-cols-3">
    <div>

    </div>
    <div>

    </div>
    <div>
      <h2>Upcoming matches</h2>
      <MatchSetup :matches="matches"></MatchSetup>
    </div>
  </div>
</template>
