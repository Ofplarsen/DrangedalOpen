<script setup lang="ts">
import { Match, Tournament } from "../../api/schema";
import { getTournament, getTournaments } from "../../requests/api_requests";
import { ref } from "vue";
import { useRoute } from "vue-router";
import MatchSetup from "../../components/MatchSetup.vue";

const tournament = ref<Tournament>()
const route = useRoute()
const guid = route.params.id

async function initTournaments(){
  console.log(guid)
  if(typeof guid != "string")
    return
  await getTournament(guid).then(data => {
    console.log(data.data)
    tournament.value = data.data
  }).catch(err => {
    console.log(err.message)
  })
}

initTournaments()
</script>

<template>
  <div v-if="tournament">
    <h1>{{tournament.name}}</h1>
    <MatchSetup v-if="tournament.matches" :matches="tournament.matches"></MatchSetup>
  </div>


</template>
