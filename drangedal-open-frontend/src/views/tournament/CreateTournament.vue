<script setup lang="ts">
import {Match, MatchType, Player, Tournament, User} from "../../api/schema";
import MatchSetup from "../../components/MatchSetup.vue";
import Card from "../../components/Card.vue"
import { ref } from "vue";
import { getPlayers } from "../../requests/api_requests";
import UserCard from "../../components/UserCard.vue";
import PlayerCard from "../../components/PlayerCard.vue";
import BaseInput from "../../components/base/BaseInput.vue";
import {PostTournament} from "../../api/tournament/tournament";

const tournament: PostTournament = {
  name: "",
  players: []
}


async function initPlayers(){
  try{
    await getPlayers().then(data => {
      tournament.players = data.data
    })
  }catch (err){
    //console.log(err)
  }

  return
}


initPlayers()

</script>

<template>
  <base-input v-model="tournament.name" label="Tournament name" placeholder="Tournament1"></base-input>
  <div v-for="player in tournament.players" class="p-2.5">
    <PlayerCard :player="player" :showRating="true">
    </PlayerCard>

  </div>
  <h2>{{tournament}}</h2>

</template>
