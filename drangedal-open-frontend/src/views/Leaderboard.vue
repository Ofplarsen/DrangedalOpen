<script setup lang="ts">
import { ref } from "vue";
import { Player, PlayerDTO } from "../api/schema";
import { getPlayers, getPlayersDTO } from "../requests/api_requests";
import Router from "../router";

const router = ref(Router)
const leaderboard = ref<PlayerDTO[]>()

function redirect(to: string){
  console.log(to)
  router.value.push(to)
}

async function initLeaderboard(){
  try{
    //TODO Make own API point for leaderboard data, since all players too much data!!!
    await getPlayersDTO().then(data => {
      leaderboard.value = data.data.sort(function(a: PlayerDTO, b: PlayerDTO) {
        return a.ranking.rating - b.ranking.rating;
      })

    })
  }catch (err){
    console.log(err)
  }
  return
}
initLeaderboard()

</script>
<template>
  <div>
    <table class="table-auto rounded-lg text-center">
      <thead class="bg-gray-300">
        <tr>
          <th class="px-4 py-2">Username</th>
          <th class="px-4 py-2">Rating</th>
          <th class="px-4 py-2">Games won</th>
          <th class="px-4 py-2">Games lost</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in leaderboard" :key="player.username" class="hover:bg-gray-200" @click="redirect('/player/' + player.username)">
          <td class="px-4 py-2">{{ player.username }}</td>
          <td class="px-4 py-2">{{ player.ranking.rating }}</td>
          <td class="px-4 py-2">{{ player.ranking.gamesWon }}</td>
          <td class="px-4 py-2">{{ player.ranking.gamesLost }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
