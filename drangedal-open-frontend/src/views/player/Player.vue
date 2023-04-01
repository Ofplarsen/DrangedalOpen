<script setup lang="ts">

import {ref} from "vue";
import {Player} from "../../api/schema";
import {getPlayer, getPlayers} from "../../requests/api_requests";
import router from "../../router";
import {useRoute} from "vue-router";
import Card from "../../components/Card.vue";
import BaseLabel from "../../components/base/BaseLabel.vue";
import Ranking from "../../components/player/Ranking.vue";

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
      console.log(data.data)
    })
  } catch (err) {
    console.log(err)
  }
}

initPlayer()
</script>

<template>
  <div class="bg-white p-8 rounded-lg shadow-lg" v-if="player">
    <div class="flex items-center">
      <img
        v-if="player.user.profilePicture"
        :src="player.user.profilePicture"
        :alt="player.user.username"
        class="w-32 h-32 object-cover rounded-full"
        data-testid="profile-picture"
      />
      <span
        v-else
        class="w-28 h-28 object-cover rounded-full bg-slate-900 text-white grid place-items-center text-4xl"
        data-testid="username"
      >
				{{ player.user.username[0].toUpperCase() }}
				{{ player.user.lastName[0].toUpperCase() }}
			</span>
      <div class="ml-6">
        <h2 class="text-xl font-semibold">
          {{ player.user.firstName }} {{ player.user.lastName }}
        </h2>
        <p class="text-gray-500">{{ player.user.username }}</p>
        <p class="text-gray-500">{{ player.user.email }}</p>
        <p class="text-gray-500">{{ player.user.phoneNumber }}</p>
        <!--<p class="text-gray-500">{{ player.user.userStatus }}</p>-->
      </div>
    </div>
    <div class="mt-6">
      <h3 class="text-lg font-semibold">Ranking</h3>
      <p>Rating: {{ player.ranking.rating }}</p>
      <p>Games Won: {{ player.ranking.gamesWon }}</p>
      <p>Games Lost: {{ player.ranking.gamesLost }}</p>
    </div>
  </div>

  <!--
  <div
    v-if="player"
    class="grid gap-4 text-center sm:w-96 mx-auto"
  >
    <div class="flex gap-4 justify-start w-full">

      <img
        v-if="player.user.profilePicture"
        :src="player.user.profilePicture"
        :alt="player.user.username"
        class="w-32 h-32 object-cover rounded-full"
        data-testid="profile-picture"
      />
      <span
        v-else
        class="w-28 h-28 object-cover rounded-full bg-slate-900 text-white grid place-items-center text-4xl"
        data-testid="username"
      >
				{{ player.user.username[0].toUpperCase() }}
				{{ player.user.lastName[0].toUpperCase() }}
			</span>


      <div class=" flex flex-col gap-1">
        <h3 class="font-bold" data-testid="name">
          {{ player.user.firstName }} {{ player.user.lastName }}
        </h3>
        <div class="flex items-center">
          <h4 class="text-slate-600">@{{ player.user.username }}</h4>
        </div>
        <div class="flex items-center">
          <h4 class="text-slate-600">{{ player.user.email }}</h4>
        </div>
        <div class="flex items-center">
          <h4 class="text-slate-600">{{ player.user.phoneNumber }}</h4>
        </div>
      </div>
    </div>
    <Ranking v-if="player.ranking" v-model="player.ranking"></Ranking>
  </div>
  -->
</template>
