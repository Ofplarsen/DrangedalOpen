import { Player, PlayerDTO } from "../schema";

export type PostTournament = {
    name: string,
    players: string[]
}

export type ChosenPlayer = {
    player: PlayerDTO,
    chosen: boolean
}
