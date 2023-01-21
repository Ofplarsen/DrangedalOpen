<script setup lang="ts">
import { ref } from "vue";
import { Player } from "../api/schema";
import { getPlayers } from "../requests/api_requests";

const leaderboard = ref<Player[]>()

async function initLeaderboard(){
  try{
    await getPlayers().then(data => {
      leaderboard.value = data.data
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
          <th class="px-4 py-2">Lastname</th>
          <th class="px-4 py-2">First name</th>
          <th class="px-4 py-2">Rating</th>
          <th class="px-4 py-2">Games won</th>
          <th class="px-4 py-2">Games lost</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in leaderboard" :key="player.user.username" class="hover:bg-gray-200">
          <td class="px-4 py-2">{{ player.user.username }}</td>
          <td class="px-4 py-2">{{ player.user.lastName }}</td>
          <td class="px-4 py-2">{{ player.user.firstName }}</td>
          <td class="px-4 py-2">{{ player.ranking.rating }}</td>
          <td class="px-4 py-2">{{ player.ranking.gamesWon }}</td>
          <td class="px-4 py-2">{{ player.ranking.gamesLost }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
