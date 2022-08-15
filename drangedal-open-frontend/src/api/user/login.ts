import { User } from '../schema'

export type PostUserLoginRequest = {
	username: string
	password: string
}

export type PostUserLoginResponse = {
	user: User
	token: string
}
