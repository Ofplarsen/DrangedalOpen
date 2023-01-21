<script setup lang="ts">
import { StarIcon, CheckCircleIcon } from '@heroicons/vue/solid'
import Card from '../components/Card.vue'
import { Player, User } from "../api/schema";
import { bool } from "yup";

interface Props {
	player: Player
	color?: 'green'
	showRating?: boolean
	to?: string
  modelValue: boolean
}
const { player, color, showRating, modelValue } = defineProps<Props>()
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
				<div class="flex gap-4 w-full justify-between">
					<div class="grid gap-2">
						<p class="font-bold text-lg">
              @{{ player.user.username }} - {{ player.user.firstName }} {{ player.user.lastName }}
						</p>
						<div v-if="showRating" class="flex gap-4">
							Rating: {{player.ranking.rating}} W: {{player.ranking.gamesWon}} - L: {{player.ranking.gamesLost}}
						</div>
					</div>
					<span class="flex-grow"></span>
				</div>
			</router-link>
			<span class="flex-grow"></span>
			<slot></slot>
		</div>
    <div class="flex p-2 h-fit place-items-end" v-else>
        <div class="flex gap-4 w-full justify-between">
          <div class="grid gap-2">
            <p class="font-bold text-lg">
              @{{ player.user.username }} - {{ player.user.firstName }} {{ player.user.lastName }}
              <input type="checkbox" v-model="modelValue"/>
            </p>
            <div v-if="showRating" class="flex gap-4">
              Rating: {{player.ranking.rating}} W: {{player.ranking.gamesWon}} - L: {{player.ranking.gamesLost}}
            </div>
          </div>
          <span class="flex-grow"></span>
        </div>

      <span class="flex-grow"></span>
      <slot></slot>
    </div>
	</Card>
</template>
