
<script>




// import { ref, onBeforeMount } from 'vue';
// import axios from 'axios';

// let users = ref([]);

// onBeforeMount(async () => {
// const fetchedUser = await fetch('https://uclssapitest.azurewebsites.net/api/user')
//     .then((fetchedUser) => fetchedUser.json())
    
//     for (let i = 0; i < fetchedUser.length; i++) {
//     users.value.push({ id: fetchedUser[i].user_id, email: fetchedUser[i].email, password: fetchedUser[i].password})
//     }
    
// let email = users.value[1].email;
// let password = users.value[1].password;


// console.log(email)
// })

// async created() {
//   GET request using fetch with async/await
//   const response = await fetch("https://uclssapitest.azurewebsites.net/api/user");
//   const data = await response.json();
//   this.totalVuePackages = data.total;
// }

import axios from 'axios'
export default {
    
    name: 'Login',
    data()
    {
        return {
            email: "",
            password: ""
        }
    },

    methods:{
        async login()
        {
            let result = await axios.get(
                `https://uclssapitest.azurewebsites.net/api/user?email=${this.email}?password=${this.password}`
            )
            console.log(result)
        }
    }
}


</script>


<template>

    <div class="login">
        <input type="text" v-model="email" placeholder="email">
        <input type="password" v-model="password" placeholder="password">
        <button v-on:click="login">Login</button>

    </div>



    <!-- <form class="loginform" action="/" >
        <h1>Studieadministation</h1>

        <div class="form-group-wrapper">
            <div class="form-group">
            <label for="Email">Email</label>
            <input  type="text" name="e-mail" id="email" class="form-control" placeholder="">
            </div>

            <div class="form-group">
            <label for="Password">Password</label>
            <input  type="password" name="password" id="password"  class="form-control" placeholder="" >
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

            <button class="button login" type="submit" @click="validateOnSubmit()" placeholder="login">Loddin</button>
        </div>
    </form> -->
</template>




<style lang="scss" ></style>