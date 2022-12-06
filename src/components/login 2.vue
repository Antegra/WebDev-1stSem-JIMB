
<script setup>
import axios from 'axios';
import { ref, onBeforeMount } from 'vue';

let users = ref([]);

onBeforeMount(async () => {

const fetchedUser = await fetch('https://uclssapitest.azurewebsites.net/api/user')
    .then((fetchedUser) => fetchedUser.json())
    
    for (let i = 0; i < fetchedUser.length; i++) {
    users.value.push({ id: fetchedUser[i].user_id, email: fetchedUser[i].email, password: fetchedUser[i].password})
    // console.log(users.value[i])
}    
console.log(users.value[0].email + " " + users.value[0].password)

})

const myLoginRoutine = user => new Promise ((resolve, reject) => {
  axios({url: 'auth', data: user, method: 'POST' })
    .then(resp => {
      const token = resp.data.token
      localStorage.setItem('user-token', token) // store the token in localstorage
      resolve(resp)
    })
  .catch(err => {
    localStorage.removeItem('user-token') // if the request fails, remove any possible user token if possible
    reject(err)
  })
})

console.log(myLoginRoutine);


let user = document.getElementById("email");
let password = document.getElementById("password");




</script>
<template>
    <form class="login" @submit.prevent="login">
        <h1>Studieadministation</h1>

        <div class="form-group-wrapper">
            <div class="form-group">
            <label for="Email">Email</label>
            <input type="text" name="e-mail" id="email" class="form-control" placeholder="" value="dd">
            </div>

            <div class="form-group">
            <label for="Password">Password</label>
            <input type="password" name="password" id="password" class="form-control" placeholder="" value="">
            </div>

            <div class="form-group-essentiels">
                <div class="inner-form-group">
                    <input type="checkbox" value="lsRememberMe" id="rememberMe"> 
                    <label for="rememberMe">Husk mig</label>
                </div>
                <div class="inner-form-group">
                    <a href="#">Glemt password?</a>
                </div>
                
            </div>

            <input class="button login" onclick="check(this.form)" type="submit" placeholder="login">
        </div>
    </form>
</template>




<style lang="scss" ></style>