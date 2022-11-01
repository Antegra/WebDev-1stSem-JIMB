<script setup>
import { ref } from 'vue';


let step = ref(1);
let input_educations = ref("");
let input_subjects = ref("");


// step 1 - Om mødet 
let sp_1 = ref("Angiv måned");
let dates = ref(["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]);

let sp_2 = ref("Vælge type henvendelse")
let types = ref(["Fysik", "Online", "Telefon"]);


// step 2 - Hvem blev vejledt?
let sp_3 = ref("Hvem blev vejledt?");
let persons = ref(["Mand", "Kvinde", "Gruppe", "andet"]);

let sp_4 = ref("Niveau");
let niveaus = ref(["Nuværende studerende", "Potentielle studerende"]);

// step 3 - Uddannelsested
let sp_5 = ref("Uddannelsested");
let locations = ref(["Odense", "Vejle", "Svendborg", "Jellinge"]);
let educations = ref(["Administrationsbachelor", "Automationsteknolog", "Autoteknolog", "Bioanalytiker", "Byggekoordinator", "Bygningskonstruktør", "Datamatiker", "Digital konceptudvikling", "E-handel", "El-installatør", "Energiteknolog", "Ergoterapeut", "Financial controller", "Finans", "Finansøkonom", "Fysioterapeut", "Handelsøkonom", "Innovation og entrepreneurship", "International handel og markedsføring", "International hospitality management", "IT-sikkerhed", "IT-teknolog", "Jordbrug", "Jordbrugsteknolog", "Laborant", "Logistikøkonom", "Lærer", "Markedsføringsøkonom", "Multimediedesigner", "Procesteknolog", "Produktionsteknolog", "Produktudvikling og teknisk integration", "Pædagog", "Radiograf", "Serviceøkonom", "Socialrådgiver", "Softwareudvikling", "Sport management", "Sundhedsadministrativ koordinator", "Sygeplejerske", "VVS-installatør", "Webudvikling", "Økonomi og IT"]);
let f_educations = ref(["Administrationsbachelor", "Automationsteknolog", "Autoteknolog", "Bioanalytiker"]);

let educations_minus_fav = educations.value.filter(item => !f_educations.value.includes(item))


// step 4 - Hvad handlede samtalen om ?
let sp_6 = ref("Hvad handlede samtalen om ?");
let subjects = ref(["Administrative forhold", "Barsel", "Eksamen", "Fastholde trivsel", "Internationale muligheder", "Mistrivsel", "Optagelsesvejledning", "Ordensreglement", "Orlov", "Overflytning/genindskrivning", "Personlige forhold", "Praktik i DK/klinik/dialogmøder", "Ikke studierelevant", "SPS", "Studieophør", "Studieplanlægning", "Studietvivl / Studievalg", "Studieudfordringer", "Sygdom", "Undervisningen", "Økonomi",]);


let durations = ref(["1-15 min", "16-30 min", "31-45 min", "46-60 min", "Mere end 60 min"]);



function filteredEducations() {
    return educations_minus_fav.filter((edu) =>
        edu.toLowerCase().includes(input_educations.value.toLowerCase())
    );
}

function filteredSubject() {
    return subjects.value.filter((subject) =>
        subject.toLowerCase().includes(input_subjects.value.toLowerCase())
    );
}


function test(e) {
    console.log(e);

}

function next() {
    step.value += 1;
}

function previous() {
    step.value = step.value - 1;
}

function done() {
    step.value = 1;
    window.location.href = '/';
}


</script>


<template>
    <div>
        <!-- step 1 - Om mødet -->
        <section class="register" v-show="step === 1">
            <div class="form-group">
                <h2>Om mødet</h2>

                <p>{{ sp_1 }}</p>
                <select>
                    <option v-for="date in dates" value="{{ date }}"> {{ date }}</option>
                </select>
                <p>{{ sp_2 }}</p>
                <button v-for="type in types"> {{ type }} </button>


            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="next" @click.prevent="next">
            </div>

        </section>

        <!-- step 2 - Hvem er det med -->
        <section class="register" v-show="step === 2">
            <h3>{{ sp_3 }}</h3>
            <div>
                <button v-for="person in persons"> {{ person }} </button>
            </div>

            <h3>{{ sp_4 }}</h3>
            <div>
                <button v-for="niveau in niveaus"> {{ niveau }}</button>
            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next">
            </div>
        </section>

        <!-- step 3 -  Uddannelsested-->
        <section class="register" v-show="step === 3">
            <h2>{{ sp_5 }}</h2>

            <div>
                <button v-for="location in locations"> {{ location }} </button>
            </div>



            <div class="educations">
                <div v-for="edu in f_educations" :key="edu">
                    <button @click="test(edu)"> {{ edu }} </button>
                    <span>Fav</span>
                </div>
            </div>

            <input type="text" v-model="input_educations" placeholder="Search..." />

            <div class="educations">
                <button v-for="edu in filteredEducations()" :key="edu" @click="test(edu)"> {{ edu }} </button>
            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next">
            </div>

        </section>

        <!-- step 4 - Hvad handler samtalen om -->
        <section class="register" v-show="step === 4">
            <h2>{{ sp_6 }}</h2>

            <input type="text" v-model="input_subjects" placeholder="Search..." />

            <div class="educations">
                <button v-for="subject in filteredSubject()" :key="subject" @click="test(subject)"> {{ subject }}
                </button>
            </div>

            <h2> Hvor lang tid tog det?</h2>

            <div>
                <button v-for="duration in durations" @click="test(duration)"> {{ duration }}</button>
            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="afslut" @click.prevent="done">
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

    .educations {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;


        button {
            width: 170px;
            height: 40px;
        }

        span {
            font-size: 12px;
            background-color: $Maize;
            padding: 2px 10px;

            position: relative;
            left: -35px;
            top: -20px;
        }

    }
}
</style>