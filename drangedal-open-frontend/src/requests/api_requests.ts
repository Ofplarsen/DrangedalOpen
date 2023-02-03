// Default config options
import axios from "./axios";
import { PostUserLoginRequest } from "../api/user/login";
import { store } from "../store";
import { PostTournament } from "../api/tournament/tournament";

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
  return await axios.get('/player?username="' + username+ '"')
}

export async function postTournament(tournament: PostTournament){
  return await axios.post('/tournament', tournament)
}
