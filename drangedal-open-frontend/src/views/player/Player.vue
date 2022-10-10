<script setup lang="ts">

import {ref} from "vue";
import {Player} from "../../api/schema";
import {getPlayer, getPlayers} from "../../requests/api_requests";
import router from "../../router";
import {useRoute} from "vue-router";
import Card from "../../components/Card.vue";

const player = ref<Player>()
const route = useRoute()
const username = route.params.id

async function initPlayer() {
  try {
    console.log(username)
    if(typeof username != "string")
      return

    await getPlayer(username).then(data => {
      player.value = data.data
    })
  } catch (err) {
    console.log(err)
  }
}

await initPlayer()
</script>

<template>
  <div class="grid grid-cols-3">
    <Card>
      {{ player.ranking.rating }}
      {{ player.ranking.gamesWon - player.ranking.gamesLost }}
    </Card>
  </div>
</template>
