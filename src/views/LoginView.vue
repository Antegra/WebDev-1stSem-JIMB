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
@import "../assets/scss/colors.scss";
@import "../assets/scss/typography.scss";

@import "../assets/scss/variabler.scss";
@import "../assets/scss/button.scss";
@import "../assets/scss/mixins.scss";
@import "../assets/scss/layout.scss";

.auth-wrapper {
   @include mainWrap;
   margin-top: 80px;
    .auth-inner{
        @include flowDesign;
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
  