export enum MatchType {
	Final = 0,
	SemiFinal = 1

}
export interface MatchRules {
	matchType: MatchType
	scoreToWin: number
}

export interface User {
	username: string
	firstName: string
	lastName: string
	email: string
	profilePicture?: string
	phoneNumber: number
	userStatus: userStatus
}

export enum userStatus{
	Active,
	Disabled
}

export interface Player {
	user: User
	ranking: Ranking
}

export interface PlayerDTO {
	username: string
	ranking: Ranking
}

export interface Ranking{
	rating: number
	gamesWon: number
	gamesLost: number
}

export interface LoginInfo {
	email: string
	password: string
}

export interface Match {
	matchGuid: string
	homePlayer: User[]
	awayPlayer: User[]
	homeScore: number
	awayScore: number
	matchRules: MatchRules
}

export interface Tournament {
	tournamentId: string
	matches: Match[]
	name: string
}


export interface Alternative {
	id: string,
	alt: string
}
