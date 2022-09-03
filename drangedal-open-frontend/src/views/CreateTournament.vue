<script setup lang="ts">
import { Match, MatchType, Player, User } from "../api/schema";
import MatchSetup from "../components/MatchSetup.vue";
import Card from "../components/Card.vue"
import { ref } from "vue";
import { getPlayers } from "../requests/api_requests";
import UserCard from "../components/UserCard.vue";
import PlayerCard from "../components/PlayerCard.vue";
const players = ref<Player[]>()

async function initPlayers(){
  try{
    await getPlayers().then(data => {
      players.value = data.data
    })
  }catch (err){
    console.log(err)
  }

  return
}

initPlayers()

</script>

<template>
  <h2>Create Tournament</h2>
  <div v-for="player in players" class="p-2.5">
    <PlayerCard :player="player" :showRating="true">
    </PlayerCard>
  </div>

</template>
