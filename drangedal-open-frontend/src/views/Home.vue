<script setup lang="ts">
import { Match, MatchDTO, MatchType, User } from "../api/schema";
import MatchSetup from "../components/MatchSetup.vue";
import {getMatches} from "../requests/api_requests";
import { ref } from "vue";
import { useStore } from "../store";


const store = useStore()
const matches = ref<MatchDTO[]>()

async function initMatches(){
  if(store.state.user == undefined)
    return
  await getMatches(store.state.user.username, false).then(data => {
    console.log(data.data)
    matches.value = data.data
  }).catch(err => {
    console.log(err.message)
  })
}
initMatches()
</script>

<template>
  <div class="grid grid-cols-3">
    <div>

    </div>
    <div>

    </div>
    <div>
      <h2>Upcoming matches</h2>
      <MatchSetup v-if="matches" :matches="matches"></MatchSetup>
    </div>
  </div>
</template>
