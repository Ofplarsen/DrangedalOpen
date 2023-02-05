// Default config options
import axios from "./axios";
import { PostUserLoginRequest } from "../api/user/login";
import { store } from "../store";
import { PostTournament } from "../api/tournament/tournament";
import { MatchDTO } from "../api/schema";

export async function login(userLogin:PostUserLoginRequest){
  return await axios.post('/login', userLogin).then(response => {
    store.dispatch('SET_USER_DATA', response.data)
    console.log(response)
  })
}

export async function getPlayers(){
  return await axios.get('/player/players/all')
}

export async function getPlayersDTO(){
  return await axios.get('/player/players')
}

export async function getPlayer(username: string){
  return await axios.get('/player?username=' + username )
}

export async function getMatches(username: string, all: boolean){
  return await axios.get('/match/player?username=' + username+ '&all=' + all)
}
export async function getMatch(id: string){
  return await axios.get('/match?id=' + id)
}
export async function putMatch(match: MatchDTO){
  return await axios.put('/match', match)
}

export async function getTournaments(old: boolean){
  return await axios.get('/tournament/all?'+ '?old=' + old)
}

export async function getTournament(id: string){
  return await axios.get('/tournament?id=' +id + '')
}

export async function postTournament(tournament: PostTournament){
  return await axios.post('/tournament', tournament)
}
