export enum MatchType {
	Final = 0,
	SemiFinal = 1

}
export enum status {
	NotStarted =0,
	Started = 1,
	Stopped = 2,
	Canceled = 3
}
export interface User {
	userId: number
	firstName: string
	lastName: string
	email: string
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



