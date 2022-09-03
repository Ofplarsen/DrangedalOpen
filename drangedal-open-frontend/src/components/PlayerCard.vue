<script setup lang="ts">
import { StarIcon, CheckCircleIcon } from '@heroicons/vue/solid'
import Card from '../components/Card.vue'
import { Player, User } from "../api/schema";

interface Props {
	player: Player
	color?: 'green'
	showRating?: boolean
	to?: string
}
const { player, color, showRating } = defineProps<Props>()
</script>

<template>
	<Card :color="color">
		<div class="flex p-2 h-fit place-items-end">
			<router-link
				:to="'player/'+player.user.username"
				class="flex w-full p-2"
				data-bs-toggle="tooltip"
				data-bs-placement="bottom"
				title="Til profil"
			>
				<div class="flex gap-4 w-full justify-between">
					<div class="grid gap-4">
						<p class="font-bold text-lg">
							{{ player.user.firstName }} {{ player.user.lastName }}
						</p>
						<p class="text-slate-600 place-self-start">
							@{{ player.user.username }}
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
	</Card>
</template>
