<script setup lang="ts">
import { ref } from "vue";
import { getPlayers, getPlayersDTO, postTournament } from "../../requests/api_requests";
import PlayerDTOCard from "../../components/PlayerDTOCard.vue";
import BaseInput from "../../components/base/BaseInput.vue";
import { ChosenPlayer, PostTournament } from "../../api/tournament/tournament";
import { PlayerDTO } from "../../api/schema";

const players_picked = ref<ChosenPlayer[]>([])
const tournament = ref<PostTournament>()
tournament.value = {
  name: "",
  players: []
}

const players = ref<PlayerDTO[]>([])

async function initPlayers(){
  if (players.value == undefined)
    return
  try{

    await getPlayersDTO().then(data => {
      if (players.value == undefined)
        return
      console.log(data)
      players.value = data.data

    })

  }catch (err){
    console.log(err)
  }
  players.value.forEach(p => players_picked.value?.push({chosen: false, player: p}))
  console.log(players_picked.value)
  return
}

async function createTournament(){
  const filteredPlayers = players_picked.value?.filter(player => player.chosen);
  if(filteredPlayers == undefined || tournament.value == undefined){
    console.log(tournament.value, filteredPlayers)
    return
  }
  tournament.value.players = filteredPlayers.map(p => p.player.username);
  console.log(tournament.value)
  await postTournament(tournament.value).then((data) => {
    console.log(data.data)
  }).catch((err) => {
    console.log(err.message)
  })
}

initPlayers()

</script>

<template>
  <base-input v-model="tournament.name" label="Tournament name" placeholder="Tournament1"></base-input>

  <div v-for="player in players_picked" class="p-2.5">
    <PlayerDTOCard :modelValue="player" :showRating="true">
    </PlayerDTOCard>
  </div>
  <button @click="createTournament">Generate</button>
</template>
