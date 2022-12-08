
<script>
import axios from 'axios'
export default {
    
    name: 'login',
    data()
    {
        return {
            email: "",
            password: ""
        }
    },

    methods:{
        async login(e)
        {

            e.preventDefault()
            let result = await axios.get(            
            `https://uclssapitest.azurewebsites.net/api/User/${this.email}, ${this.password}`
            )

            let relevantData = [];
            relevantData.push({firstName: result.data.firstName, location_id: result.data.location_id, role_id: result.data.role_id, edu_id: result.data.edu_id, edu_name: result.data.edu_name, user_id: result.data.user_id});
            
            console.log(relevantData);
            
            if(result.status == 200 && result.data.user_id > 0) {
                localStorage.setItem("user-token", JSON.stringify(relevantData))
                
                // localStorage.setItem("user-token", "Autherized")
                window.location.href = '/';
            } else {
                document.querySelector(".error-handle").classList.toggle("active")
            }

            
        }
    
    },
    mounted(){
            document.querySelector(".nav").remove();

            let user = localStorage.getItem('user-token');
            if (user) {
                window.location.href = '/';
                
            } else {
               
            }
            
        }
}


</script>


<template>

    <form class="login" >
        <h1>Studieadministation</h1>

        <div class="form-group-wrapper">
            <div class="form-group">
            <label for="Email">Email</label>
            <input required type="text" v-model="email" placeholder="email">
            </div>

            <div class="form-group">
            <label for="Password">Password</label>
            <input required type="password" v-model="password" placeholder="password">
            </div>
            <div class="error-handle">
                <p>Forkert email eller password</p>

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




<style lang="scss" >
.error-handle {
    background: red;
    padding: 15px;
    border-radius: 10px;
    
    display: none;
    &.active {
        display:flex;
    }
    
    p {
        color: white;
        margin: 0;
        position: relative;
        &:before {
            display:inline-block;
            vertical-align: middle;
            margin-right: 8px;
        
            content: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='25' height='25' viewBox='0 0 25 25'%3E%3Cg id='Group_245' data-name='Group 245' transform='translate(-141 -914.582)'%3E%3Ccircle id='Ellipse_28' data-name='Ellipse 28' cx='12.5' cy='12.5' r='12.5' transform='translate(141 914.582)' fill='%23fff'/%3E%3Cpath id='Path_50' data-name='Path 50' d='M0,0,11.838,11.838' transform='translate(147.386 921.358)' fill='none' stroke='red' stroke-width='1'/%3E%3Cline id='Line_2' data-name='Line 2' y1='11.838' x2='11.838' transform='translate(147.386 921.358)' fill='none' stroke='red' stroke-width='1'/%3E%3C/g%3E%3C/svg%3E%0A");
        }
    }
}

</style>