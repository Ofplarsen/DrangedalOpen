<script setup lang="ts">
import { ref } from "vue";
import { getPlayers } from "../../requests/api_requests";
import PlayerCard from "../../components/PlayerCard.vue";
import BaseInput from "../../components/base/BaseInput.vue";
import { ChosenPlayer, PostTournament } from "../../api/tournament/tournament";

const players_picked = ref<ChosenPlayer[]>([])
const tournament = ref<PostTournament>()
tournament.value = {
  name: "",
  players: []
}

async function initPlayers(){
  if (tournament.value == undefined)
    return
  try{

    await getPlayers().then(data => {
      if (tournament.value == undefined)
        return
      console.log(data)
      tournament.value.players = data.data

    })

  }catch (err){
    console.log(err)
  }
  tournament.value.players.forEach(p => players_picked.value?.push({chosen: false, player: p}))
  console.log(players_picked.value)
  return
}

async function postTournament(){
  const filteredPlayers = players_picked.value?.filter(player => player.chosen);
  if(filteredPlayers == undefined || tournament.value == undefined){
    console.log(tournament.value, filteredPlayers)
    return
  }
  tournament.value.players = filteredPlayers.map(p => p.player);
  console.log(tournament.value)
}

initPlayers()

</script>

<template>
  <base-input v-model="tournament.name" label="Tournament name" placeholder="Tournament1"></base-input>

  <div v-for="player in players_picked" class="p-2.5">
    <PlayerCard :player="player.player" :showRating="true" v-model="player.chosen">
    </PlayerCard>
  </div>
  <button @click="postTournament">Generate</button>
</template>
