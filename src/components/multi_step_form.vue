<script setup>
import { ref } from 'vue';


let step = ref(1);
let first_name = ref("");


function next() {
    step.value += 1;
    

}

function previous() {
    step.value = step.value - 1;

}

</script>


<template>
    <div>
        <section class="register" v-show="step === 1">
            <div class="form-group">
                <h2>title 1.</h2>
                <input v-model="first_name" type="text" name="" id="" placeholder="First name">

            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="next" @click.prevent="next">
            </div>

        </section>

        <section class="register" v-show="step === 2">
            <h2>title 2.</h2>
            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next">
            </div>
        </section>

        <section class="register" v-show="step === 3">
            <h2>title 3.</h2>
            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next">
            </div>

        </section>
    </div>
</template>


<style lang="scss" scoped>
@import "../assets/colors.scss";

.register {
    background-color: $Columbia-blue;
    width: 75vw;
    height: 75vh;
    margin: auto;
    padding: 2vh 0;

    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;

    h2 {
        text-transform: capitalize;
        font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        Color: $Midnight-Green;
        padding: 0;
        margin: 0;
    }

    .form_btn {
        margin: 0 1vw;
        background-color: $Midnight-Green;
        border: none;
        text-transform: uppercase;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
    }
}
</style>