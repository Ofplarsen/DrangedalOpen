<script setup lang="ts">
import { store } from '../store'

import { UserIcon } from '@heroicons/vue/solid'
</script>

<template>
	<nav class="bg-slate-900 w-full fixed top-0 z-50">
		<div
			class="container mx-auto px-4 py-2 flex justify-between items-center"
		>
			<router-link to="/">
				<img
					src="src/assets/logo.png"
					alt="Badminton logo"
					class="w-16"
					data-bs-toggle="tooltip"
					data-bs-placement="bottom"
					title="Hjem"
				/>
			</router-link>
			<div class="flex gap-8 items-center">
				<router-link to="/">Hjem</router-link>
				<router-link v-if="store.getters.loggedIn" to="/overview">
					Your Matches
				</router-link>
				<router-link to="/leaderboard">
					Leaderboard
				</router-link>
				<router-link v-if="store.getters.loggedIn" to="/tournament/new">
          Create Tournament
				</router-link>
				<router-link
					class="grid place-items-center"
					:to="'/login'"
				>
					<img
						v-if="store.state.user"
						class="rounded-full object-cover w-8 h-8"
						:src="store.state.user.profilePicture"
						:alt="store.state.user.username"
						data-bs-toggle="tooltip"
						data-bs-placement="bottom"
						title="Til profil"
					/>
					<p v-else>Logg inn</p>
				</router-link>
			</div>
		</div>
	</nav>
</template>

<style scoped>
a {
	@apply text-white;
}
.router-link-active {
	@apply text-blue-400;
}
</style>
