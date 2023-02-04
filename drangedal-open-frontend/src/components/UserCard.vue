<script setup lang="ts">
import { StarIcon, CheckCircleIcon } from '@heroicons/vue/solid'
import Card from '../components/Card.vue'
import { User } from '../api/schema'

interface Props {
	user: User
	color?: 'green'
	showRating?: boolean
	to?: string
}
const { user, color, showRating } = defineProps<Props>()
</script>

<template>
	<Card :color="color" v-if="to">
		<div class="flex p-2 h-fit place-items-end">
			<router-link
				:to="to"
				class="flex w-full p-2"
				data-bs-toggle="tooltip"
				data-bs-placement="bottom"
				title="Til profil"
			>
				<div class="flex gap-4 w-full justify-between">
					<img
						class="w-16 h-16 rounded-full object-cover"
						:src="user.profilePicture"
						:alt="user.username"
					/>
					<div class="grid gap-4">
						<p class="font-bold text-lg">
							{{ user.firstName }} {{ user.lastName }}
						</p>
						<p class="text-slate-600 place-self-start">
							@{{ user.username }}
						</p>
						<div v-if="showRating" class="flex gap-4">
						</div>
					</div>
					<span class="flex-grow"></span>
				</div>
			</router-link>
			<span class="flex-grow"></span>
			<slot></slot>
		</div>
	</Card>

	<Card v-else :color="color">
		<div
			class="flex gap-4 w-full justify-between p-2 h-fit place-items-end"
		>
			<img
				class="w-16 h-16 rounded-full object-cover"
				:src="user.profilePicture"
				:alt="user.username"
			/>
			<div class="grid gap-4">
				<p class="font-bold text-lg">
					{{ user.firstName }} {{ user.lastName }}
				</p>
				<p class="text-slate-600">@{{ user.username }}</p>
				<div v-if="showRating" class="flex gap-4">
				</div>
			</div>
			<span class="flex-grow"></span>
			<slot></slot>
		</div>
	</Card>
</template>
