<script setup lang="ts">
import Card from "../Card.vue";
import { Match, Ranking } from "../../api/schema";

interface Props {
  modelValue: Ranking
}
const { modelValue } = defineProps<Props>()
</script>

<template>
  <div>

        <h2 class="text-slate-600">Rating: {{modelValue.rating}}</h2>
        <h2 class="text-slate-600"> Wins / Losses: {{ modelValue.gamesWon}} - {{modelValue.gamesLost }}</h2>

  </div>
</template>
