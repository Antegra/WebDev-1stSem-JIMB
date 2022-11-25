<script setup>



function find() {
    if (location.search.includes('succes=true')) {
        console.log("vis")

        const succes = document.getElementById("succes-modal")
        succes.style.display = "flex";
    }
};


window.onload = find;


function CloseModel() {
    const succes = document.getElementById("succes-modal")
    succes.style.display = "none";
}

</script>


<template>
    <div id="succes-modal" class="modal-wrap">
        <div class="modal">
            <h3>SUCCES!</h3>
            <p>Du har nu oprettet en ny sag!</p>
            <button @click="CloseModel">Luk</button>
        </div>

    </div>
</template>





  
<style lang="scss" scoped>
@import "../assets/scss/colors.scss";
@import "../assets/scss/typography.scss";

@import "../assets/scss/variabler.scss";
@import "../assets/scss/button.scss";
@import "../assets/scss/mixins.scss";
@import "../assets/scss/layout.scss";

#succes-modal {
    display: none;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);

    width: 100vw;
    height: 100vh;

    justify-content: center;
    align-items: center;

    background: rgba(1, 1, 1, 0.4);
    transition: 1s ease;

    .modal {
        border-radius: 10px;
        box-shadow: $stdDropshadow;
        background: #9b3c7d;
        padding: 20px;
        text-align: center;
    }
}
</style>
