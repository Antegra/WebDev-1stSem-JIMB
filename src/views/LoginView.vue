<script>
import Login from "../components/login.vue"


    export default {
        name: 'app',
        components: {
            Login
        }
    }


</script>

<template>
  <div class="auth-wrapper">
    <div class="auth-inner">
        <Login />
    </div>
  </div>
</template>

<style lang="scss">
@import "../assets/colors.scss";
@import "../assets/typography.scss";
@import "../assets/button.scss";
@import "../assets/variabler.scss";

.auth-wrapper {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    max-width: 1080;
    height: 90vh;
    .auth-inner{
        display: flex;
        flex-direction: column;
        justify-content: center;
        max-width: 1080px;
        width: 100%;
        margin:auto;
        align-items: center;
        height: 550px;
        
        background: $Midnight-Green;
        border-radius: $stdBorderRadius;
        color: #fff;
        h1 {
            margin-bottom: 54px;
        }
        .form-group-wrapper {
            max-width: 304px;
            margin: auto;
        }
        .form-group {
            display:flex;
            flex-direction: column;
            
            
            margin: auto;
            margin-bottom: 24px;
            label {
                margin-bottom: 5px;
            }
            input {
                height: 50px;
                border-radius: 10px;
                outline: none;
                border: none;
                font-size: 16px;
                padding-left: 5px;
            }
        }

        .form-group-essentiels {
            
            margin: auto;
            margin-top: 24px;
            display: flex;
            font-size: 12px;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 32px;
            .inner-form-group {
                display:flex;
                align-items:center;
            }
            a {
                
                color: #fff;
            
                font-style: italic;
                text-decoration: none;
            }

        }
    }
}

</style>
  