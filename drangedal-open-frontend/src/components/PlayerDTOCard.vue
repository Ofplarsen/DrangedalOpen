<script setup lang="ts">
import { StarIcon, CheckCircleIcon } from '@heroicons/vue/solid'
import Card from '../components/Card.vue'
import { Player, PlayerDTO, User } from "../api/schema";
import { bool } from "yup";
import { ChosenPlayer } from "../api/tournament/tournament";
import { computed, ref } from "vue";

interface Props {
	color?: 'green'
	showRating?: boolean
	to?: string
  modelValue: ChosenPlayer
}
const { color, showRating, modelValue } = defineProps<Props>()

function initColor(){
  if(modelValue.chosen)
    col.value = 'green'
  else
    col.value = 'red'
}

function clicked(){
  modelValue.chosen = !modelValue.chosen

  if(modelValue.chosen)
    col.value = 'green'
  else
    col.value = 'red'
}

const col = ref('red')

const colorClass = computed(() => {
  switch (col.value) {
    case 'green':
      return 'bg-green-100'
    default:
      return 'bg-white'
  }
})
initColor()
</script>

<template>
	<Card :color="color">
		<div class="flex p-2 h-fit place-items-end" v-if="to != null">
			<router-link
				:to="to"
				class="flex w-full p-2"
				data-bs-toggle="tooltip"
				data-bs-placement="bottom"
				title="Til profil"
			>
				<div class="flex gap-4 w-full justify-between" :class="colorClass" @click = "clicked">
					<div class="grid gap-2">
						<p class="font-bold text-lg">
              @{{ modelValue.player.username }}
						</p>
						<div v-if="showRating" class="flex gap-4">
							Rating: {{modelValue.player.ranking.rating}} W: {{modelValue.player.ranking.gamesWon}} - L: {{modelValue.player.ranking.gamesLost}}
						</div>
					</div>
					<span class="flex-grow"></span>
				</div>
			</router-link>
			<span class="flex-grow"></span>
			<slot></slot>
		</div>
    <div class="flex p-2 h-fit place-items-end" v-else :class="colorClass" @click="clicked">
        <div class="flex gap-4 w-full justify-between">
          <div class="grid gap-2">
            <p class="font-bold text-lg">
              @{{ modelValue.player.username }}
            </p>
            <div v-if="showRating" class="flex gap-4">
              Rating: {{modelValue.player.ranking.rating}} W: {{modelValue.player.ranking.gamesWon}} - L: {{modelValue.player.ranking.gamesLost}}
            </div>
          </div>
          <span class="flex-grow"></span>
        </div>

      <span class="flex-grow"></span>
      <slot></slot>
    </div>
	</Card>
</template>
