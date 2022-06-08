export enum MatchType {
	Final = 0,
	SemiFinal = 1

}
export interface User {
	userId: number
	firstName: string
	lastName: string
	email?: string
	profilePicture?: string
	rating: number
}

export interface LoginInfo {
	email: string
	password: string
}

export interface Match {
	matchId: number
	date: string
	home: User[]
	away: User[]
	scoreHome: number
	scoreAway: number
	type: MatchType
}

export interface Tournament {
	tournamentId: number
	matches: Match[]
	startDate: string
	endDate: string
}



