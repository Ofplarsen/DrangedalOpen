<script setup lang="ts">
import { Match, MatchDTO, MatchType, Tournament } from "../api/schema";
import { getMatch, getTournament, getTournaments, putMatch } from "../requests/api_requests";
import { ref } from "vue";
import { useRoute } from "vue-router";
import MatchSetup from "../components/MatchSetup.vue";
import { MenuButton } from "@headlessui/vue";
import BaseBtn from "../components/base/BaseBtn.vue";
import Card from "../components/Card.vue"
const match = ref<MatchDTO>()
const route = useRoute()
const guid = route.params.id
const done = ref<boolean>()


function addToHome(){
  if (!match.value)
    return
  if(done.value)
    return;
  match.value.homeScore += 1
  if(match.value.homeScore >= match.value?.matchRules.scoreToWin  && match.value.homeScore
    > match.value?.awayScore && Math.abs(match.value.homeScore - match.value?.awayScore) >= 2)
  {
    done.value = true
    match.value.winner = match.value?.homePlayer
  }

}

function removeFromHome(){
  if (!match.value)
    return
  if(done.value)
    return;
  if(match.value.homeScore === 0)
    return;
  match.value.homeScore -= 1
}

function addToAway(){
  if (!match.value)
    return
  if(done.value)
    return;
  match.value.awayScore += 1
  if(match.value.awayScore >= match.value?.matchRules.scoreToWin && match.value.homeScore
    < match.value?.awayScore && Math.abs(match.value.homeScore - match.value?.awayScore) >= 2){
    done.value = true
    match.value.winner = match.value?.awayPlayer
  }


}

function removeFromAway(){
  if (!match.value)
    return
  if(done.value)
    return;
  if(match.value.awayScore === 0)
    return;
  match.value.awayScore -= 1
}

async function updateMatch(){
  if(!match.value)
    return
  await putMatch(match.value).then(data => {
    console.log(data.data)
    match.value = data.data
    done.value = (data.data.winner !== null)
  }).catch(err => {
    console.log(err.message)
  })
}

async function initTournaments(){
  console.log(guid)
  if(typeof guid != "string")
    return
  await getMatch(guid).then(data => {
    console.log(data.data)
    match.value = data.data
    done.value = (data.data.winner !== null)
  }).catch(err => {
    console.log(err.message)
  })
}

initTournaments()
</script>

<template>
  <div class="space-y-7">
    <div class="grid grid-cols-3 text-center gap-8" v-if="match">
      <h1 v-if="done">Winner!</h1>
      <h1 v-if="done">{{match.winner}}</h1>
      <h1 v-if="done">Winner!</h1>
    </div>

    <div class="text-center space-y-7" v-if="match.matchRules">
      <h1> {{ MatchType[match.matchRules.matchType] }} </h1>
      <h1> Score to Win: {{ match.matchRules.scoreToWin }} </h1>
    </div>


    <div class="grid grid-cols-3 text-center gap-8" v-if="match">
      <h1>{{ (match.homePlayer === null ? "TBA" : match.homePlayer) }}</h1>
      <h1>  </h1>
      <h1>{{ (match.awayPlayer === null ? "TBA" : match.awayPlayer) }}</h1>

      <h1>{{ match.homeScore }}</h1>
      <h1> - </h1>
      <h1>{{ match.awayScore }}</h1>

      <div class="grid grid-cols-2 text-center gap-8" v-if="match">
        <BaseBtn :disabled="done ||
        (match.homePlayer === null || match.awayPlayer === null)" @click="removeFromHome">-</BaseBtn>
        <BaseBtn :disabled="done ||
        (match.homePlayer === null || match.awayPlayer === null)" @click="addToHome">+</BaseBtn>
      </div>
      <h1></h1>
      <div class="grid grid-cols-2 text-center gap-8" v-if="match">
        <BaseBtn :disabled="done ||
        (match.homePlayer === null || match.awayPlayer === null)" @click="removeFromAway">-</BaseBtn>
        <BaseBtn :disabled="done ||
        (match.homePlayer === null || match.awayPlayer === null)" @click="addToAway">+</BaseBtn>
      </div>
    </div>
    <div class="text-center space-y-7" v-if="match">
      <BaseBtn @click="updateMatch" :disabled="(match.homePlayer === null || match.awayPlayer === null)">Save</BaseBtn>
    </div>
    <router-link :to="'/match/' + match.nextMatch"  v-if="match">
      <Card>
        Next match
      </Card>
    </router-link>

  </div>



</template>
