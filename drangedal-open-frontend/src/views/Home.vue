<script setup lang="ts">
import { Match, MatchDTO, Tournament, MatchType, User } from "../api/schema";
import MatchSetup from "../components/MatchSetup.vue";
import { getMatches, getTournaments } from "../requests/api_requests";
import { ref } from "vue";
import { useStore } from "../store";
import Tournaments from "../components/Tournaments.vue";


const store = useStore()
const matches = ref<MatchDTO[]>()
const tournaments = ref<Tournament>()

async function initMatches(){
  if(store.state.user == undefined)
    return
  await getMatches(store.state.user.username, false).then(data => {
    console.log(data.data)
    matches.value = data.data
  }).catch(err => {
    console.log(err.message)
  })
}

async function initTournaments(){

  await getTournaments(false).then(data => {
    console.log(data.data)
    tournaments.value = data.data
  }).catch(err => {
    console.log(err.message)
  })
}

initMatches()
initTournaments()
</script>

<template>
  <div class="grid grid-cols-3">
    <div>
      <h2>  Tournaments</h2>
      <Tournaments v-if="tournaments" :tournaments="tournaments"></Tournaments>
    </div>
    <div>
      <h2>Tournaments</h2>
      <Tournaments v-if="tournaments" :tournaments="tournaments"></Tournaments>
    </div>
    <div>
      <h2>Upcoming matches</h2>
      <MatchSetup v-if="matches" :matches="matches"></MatchSetup>
    </div>
  </div>
</template>
