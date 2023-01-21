import {Player} from "../schema";

export type PostTournament = {
    name: string,
    players: Player[]
}

export type ChosenPlayer = {
    player: Player,
    chosen: boolean
}
