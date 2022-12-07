
<script>
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
                // `http://localhost:3000/user?email=${this.email}&password=${this.password}`
                `https://uclssapitest.azurewebsites.net/api/user?email=${this.email}&password=${this.password}`
            )

            console.log(result)

            
            if(result.status == 200 && result.data.length > 0) {
                localStorage.setItem("user-token", JSON.stringify(result.data[0]))
                window.location.href = '/';
            }

            
        }
    
    },
    mounted(){
            let user = localStorage.getItem('user-token');
            if (user) {
                window.location.href = '/';
                
            } else {
                console.log("not logged in")
            }
            
        }
}


</script>


<template>

    <!-- <div class="login">
        <input type="text" v-model="email" placeholder="email">
        <input type="password" v-model="password" placeholder="password">
        <button v-on:click="login">Login</button>

    </div>
 -->


    <form class="login" >
        <h1>Studieadministation</h1>

        <div class="form-group-wrapper">
            <div class="form-group">
            <label for="Email">Email</label>
            <input type="text" v-model="email" placeholder="email">
            </div>

            <div class="form-group">
            <label for="Password">Password</label>
            <input type="password" v-model="password" placeholder="password">
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

            <button class="button login" v-on:click="login">Login</button>
        </div>
    </form>
</template>




<style lang="scss" ></style>