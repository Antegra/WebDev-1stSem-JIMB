<script setup>
import { ref } from 'vue';


let step = ref(1);

let anwsers = {
    month: "",
    type: "",
    sex: "",
    niveau: "",
    locations: [],
    educations: [],
    subject: [],
    duration: ""

};


let bub1 = "Måned & type";
let bub2 = "Køn & studiestatus";
let bub3 = "Lokation & uddannelser";
let bub4 = "Emner & tid";


// step 1 - Om mødet 
let sp_1 = ref("Angiv måned");
let dates = ref(["Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December"]);
const d = new Date();
let select_month = ref([]);
anwsers.month = dates.value[d.getMonth()];
select_month = [dates.value[d.getMonth()], dates.value[d.getMonth() - 1]];


let sp_2 = ref("Vælge type henvendelse")
let types = ref(["Fysik", "Online", "Telefon"]);

// step 2 - Hvem blev vejledt?
let sp_3 = ref("Hvem blev vejledt?");
let persons = ref(["Mand", "Kvinde", "Gruppe", "andet"]);

let sp_4 = ref("Niveau");
let niveaus = ref(["Nuværende studerende", "Potentielle studerende"]);

// step 3 - Uddannelsested
let sp_5 = ref("Uddannelsested");
let input_educations = ref("");
let locations = ref(["Odense", "Vejle", "Svendborg", "Jellinge", "Frederica"]);
let educations = ref(["Administrationsbachelor", "Automationsteknolog", "Autoteknolog", "Bioanalytiker", "Byggekoordinator", "Bygningskonstruktør", "Datamatiker", "Digital konceptudvikling", "E-handel", "El-installatør", "Energiteknolog", "Ergoterapeut", "Financial controller", "Finans", "Finansøkonom", "Fysioterapeut", "Handelsøkonom", "Innovation og entrepreneurship", "International handel og markedsføring", "International hospitality management", "IT-sikkerhed", "IT-teknolog", "Jordbrug", "Jordbrugsteknolog", "Laborant", "Logistikøkonom", "Lærer", "Markedsføringsøkonom", "Multimediedesigner", "Procesteknolog", "Produktionsteknolog", "Produktudvikling og teknisk integration", "Pædagog", "Radiograf", "Serviceøkonom", "Socialrådgiver", "Softwareudvikling", "Sport management", "Sundhedsadministrativ koordinator", "Sygeplejerske", "VVS-installatør", "Webudvikling", "Økonomi og IT"]);
let f_educations = ref(["Administrationsbachelor", "Automationsteknolog", "Autoteknolog", "Bioanalytiker"]);

let educations_minus_fav = educations.value.filter(item => !f_educations.value.includes(item))

// step 4 - Hvad handlede samtalen om ?
let sp_6 = ref("Hvad handlede samtalen om ?");
let input_subjects = ref("");
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

function month(e) {
    anwsers.month = e.target.value;
}

function meeting(e) {
    anwsers.type = e;
    const boxes = document.querySelectorAll('.form-group-1-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");
    console.log(anwsers);
}

function sex(e) {
    anwsers.sex = e;

    const boxes = document.querySelectorAll('.form-group-2-1 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");
    console.log(anwsers);
}

function level(e) {
    anwsers.niveau = e;

    const boxes = document.querySelectorAll('.form-group-2-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");
    console.log(anwsers);
}

function location_anwser(e) {
    if (anwsers.locations.includes(e)) {
        anwsers.locations = anwsers.locations.filter(function (item) {
            return item !== e
        });
    } else {
        anwsers.locations.push(e);

    }
    console.log(anwsers);

    document.getElementById(e).classList.toggle("selected");
}

function educations_anwser(e) {
    if (anwsers.educations.includes(e)) {
        anwsers.educations = anwsers.educations.filter(function (item) {
            return item !== e
        });
    } else {
        anwsers.educations.push(e);

    }
    document.getElementById(e).classList.toggle("selected");

}

function subject_anwser(e) {
    anwsers.subject.push(e);
    document.getElementById(e).classList.toggle("selected");
}

function duration_anwser(e) {
    anwsers.duration = e;
    const boxes = document.querySelectorAll('.form-group-4-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");
    console.log(anwsers);
}

function next(e) {
    const boxes = document.querySelectorAll('button')
    switch (e) {
        case 1:

            if (anwsers.type == "") {
                boxes.forEach(box => {
                    box.classList.add("alert")
                });
            } else {
                step.value += 1;
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;

        case 2:
            if (anwsers.sex == "" || anwsers.niveau == "") {
                boxes.forEach(box => {
                    box.classList.add("alert")
                });
            } else {
                step.value += 1;
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;

        case 3:
            if (anwsers.educations == "" || anwsers.locations == "") {
                boxes.forEach(box => {
                    box.classList.add("alert")
                });
            } else {
                step.value += 1;
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;

        case 4:
            if (anwsers.subject == "" || anwsers.duration == "") {
                boxes.forEach(box => {
                    box.classList.add("alert")
                });
            } else {
                step.value += 1;
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;
    }
}

function previous() {
    const boxes = document.querySelectorAll('button')
    boxes.forEach(box => {
        box.classList.remove("alert")
    });
    step.value = step.value - 1;
}

function done() {
    step.value = 1;
    window.location.href = '/';
}


</script>


<template>
    <div class="section-wrapper">
        <!-- step 1 - Om mødet -->
        <section class="register" v-show="step === 1">
            <div class="progress_bar">
                <div class="1 bobble active">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobble">
                    <p>2</p>
                    <p> {{bub2}}</p>
                </div>
                <div class="3 bobble">
                    <p>3</p>
                    <p>{{bub3}}</p>
                 
                </div>
                <div class="4 bobble">
                    <p>4</p>
                    <p>{{bub4}}</p>
                </div>
            </div>
            <div class="form-group-1">
                <h2>Om mødet</h2>

                <p>{{ sp_1 }}</p>
                <div class="form-group-1-1">
                    <select @change="month($event)">
                        <option v-for="date in select_month" :value="date"> {{ date }}</option>
                    </select>
                </div>
                <p>{{ sp_2 }}</p>
                <div class="form-group-1-2">
                    <button v-for="type in types" @click="meeting(type)" :id="type"> {{ type }} </button>
                </div>

            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="next" @click.prevent="next(1)">
            </div>

        </section>

        <!-- step 2 - Hvem er det med -->
        <section class="register" v-show="step === 2">
            <div class="progress_bar">
                <div class="1 bobble active">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobble active">
                    <p>2</p>
                    <p> {{bub2}}</p>
                </div>
                <div class="3 bobble">
                    <p>3</p>
                    <p>{{bub3}}</p>
                 
                </div>
                <div class="4 bobble">
                    <p>4</p>
                    <p>{{bub4}}</p>
                </div>
            </div>

            <h3>{{ sp_3 }}</h3>
            <div class="form-group-2-1">
                <button v-for="person in persons" @click="sex(person)" :id="person"> {{ person }} </button>
            </div>

            <h3>{{ sp_4 }}</h3>
            <div class="form-group-2-2">
                <button v-for="niveau in niveaus" @click="level(niveau)" :id="niveau"> {{ niveau }}</button>
            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next(2)">
            </div>

        </section>


        <!-- step 3 -  Uddannelsested-->
        <section class="register" v-show="step === 3">
            <div class="progress_bar">
                <div class="1 bobble active">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobble active">
                    <p>2</p>
                    <p> {{bub2}}</p>
                </div>
                <div class="3 bobble active">
                    <p>3</p>
                    <p>{{bub3}}</p>
          
                </div>
                <div class="4 bobble">
                    <p>4</p>
                    <p>{{bub4}}</p>
                </div>
            </div>
            <h2>{{ sp_5 }}</h2>

            <div class="form-group-3-1">
                <button v-for="location in locations" :id="location" @click="location_anwser(location)"> {{ location }}
                </button>
            </div>

            <div class="educations form-group-3-2">
                <div v-for="edu in f_educations" :key="edu">
                    <button @click="educations_anwser(edu)" :id="edu"> {{ edu }} </button>
                    <span>Fav</span>
                </div>
            </div>

            <input type="text" v-model="input_educations" placeholder="Search..." />

            <div class="educations">
                <button v-for="edu in filteredEducations()" :id="edu" :key="edu" @click="educations_anwser(edu)"> {{ edu
                }}
                </button>
            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next(3)">
            </div>

        </section>


        <!-- step 4 - Hvad handler samtalen om -->
        <section class="register form-group-4" v-show="step === 4">
            <div class="progress_bar">
                <div class="1 bobble active">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobbl active">
                    <p>2</p>
                    <p> {{bub2}}</p>
                </div>
                <div class="3 bobble active">
                    <p>3</p>
                    <p>{{bub3}}</p>
                 
                </div>
                <div class="4 bobble active">
                    <p>4</p>
                    <p>{{bub4}}</p>
                </div>
            </div>
            <h2>{{ sp_6 }}</h2>

            <input type="text" v-model="input_subjects" placeholder="Search..." />

            <div class="educations form-group-4-1">
                <button v-for="subject in filteredSubject()" :id="subject" :key="subject"
                    @click="subject_anwser(subject)"> {{
                            subject
                    }}
                </button>
            </div>

            <h2> Hvor lang tid tog det?</h2>

            <div class="form-group-4-2">
                <button v-for="duration in durations" :id="duration" @click="duration_anwser(duration)"> {{ duration
                }}</button>
            </div>

            <div class="navigation-group">
                <input class="form_btn" type="submit" value="previous" @click.prevent="previous">
                <input class="form_btn" type="submit" value="next" @click.prevent="next(4)">
            </div>


        </section>

        <!-- step 5 - result -->
        <section class="register" v-show="step === 5">
            <h2>test</h2>

            <div class="anwsers">
                <p>Sex: {{ anwsers.sex }}</p>
                <p>Type: {{ anwsers.type }}</p>
                <p>Month: {{ anwsers.month }}</p>
                <p>Duration: {{ anwsers.duration }}</p>
                <p>Location: <li v-for="e in anwsers.locations"> {{ e }} </li>
                </p>
                <p>Educations: <li v-for="e in anwsers.educations">{{ e }} </li>
                </p>
                <p>Subjects: <li v-for="e in anwsers.subject">{{ e }} </li>
                </p>
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
@import "../assets/typography.scss";
@import "../assets/button.scss";
@import "../assets/variabler.scss";
@import "../assets/mixins.scss";

.progress_bar {
    display: flex;
    justify-content: space-around;
    width: 80%;
    position: absolute;
    top: -120px;


    .bobble {
        background: #fff;
        border-radius: 50%;
        height: 60px;
        width: 60px;
        display: flex;
        align-items: center;
        justify-content: center;
        position:relative;
        box-shadow: $stdDropshadow;
        
        &:after {
            position:absolute;
            content: " ";
            width: 182px;
            height: 3px;
            background: #fff;
            left: -175px;
            box-shadow: $stdDropshadow;
            z-index: -1;

        }

   
        &:first-of-type {
            &:after {
                content: unset;
            }
        }
    }

    p {
        text-align: center;
        font-size: 16px;
        color: $Midnight-Green;
        
        &:last-of-type {
            position:absolute;
            bottom: -44px;
            font-size: 16px;
            font-weight: 400;
            white-space: nowrap;
        }
    }

    .active {
        background-color: $Verdigris;

        &:after {
            background-color: $Verdigris;
        }

        p {
            color:#fff;
            &:last-of-type {
               
                color: $Midnight-Green;
            }
            
        }
    }
}

.selected {
    background-color: $Maize;
    color: $Midnight-Green;
    border: none;
}

.alert {
    border-color: red;
}


.section-wrapper {
   @include mainWrap; 
}
.register {
    background-color: $Columbia-blue;
    width: 75vw;
    
    margin: auto;
    padding: 2vh 0;
    position: relative;

    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;

   @include flowDesign; 

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

    .anwsers {
        font-size: 16px;
    }
}
</style>