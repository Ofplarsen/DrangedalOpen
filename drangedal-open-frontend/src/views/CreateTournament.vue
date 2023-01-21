<script setup lang="ts">
import { Match, MatchType, Player, User } from "../api/schema";
import MatchSetup from "../components/MatchSetup.vue";
import Card from "../components/Card.vue"
import { ref } from "vue";
import { getPlayers } from "../requests/api_requests";
import UserCard from "../components/UserCard.vue";
import PlayerCard from "../components/PlayerCard.vue";
import BaseInput from "../components/base/BaseInput.vue";
const players = ref<Player[]>()
const name = ref<String>()
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
  <base-input :model-value="name" label="Tournament Name" placeholder="My Tournament"></base-input>
  <br>
  <div class="border border-solid border-black overflow-auto">
    <div v-for="player in players" class="p-2.5 overflow-auto">
      <PlayerCard :player="player" :showRating="true">
      </PlayerCard>
    </div>
  </div>
</template>
