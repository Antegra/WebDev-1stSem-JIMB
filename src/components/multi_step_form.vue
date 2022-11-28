<script setup>
import { ref } from 'vue';

let step = ref(1);

let anwsers = {
    month: "",
    type: "",
    sex: "",
    niveau: "",
    locations: "",
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

async function getText() {
    await fetch('https://uclssapitest.azurewebsites.net/api/type')
        .then((response) => response.json())
        .then((test) => console.log(test))
    for (let i = 0; i < test.length; i++) {
        console.log(test.name)
    }
}

// step 2 - Hvem blev vejledt?
let sp_3 = ref("Hvem blev vejledt?");
let persons = ref(["Mand", "Kvinde", "Gruppe"]);

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
let subjects = ref([{ title: "Administrative forhold", description: "Vejledning om at søge dispensation, merit, kompetencevurdering mm." }, { title: "Barsel", description: "" }, { title: "Eksamen", description: "fx regler, klage, snyd, omprøver, særlige prøvevilkår" }, { title: "Fastholde trivsel", description: "statussamtaler og opfølgning på studerende mm." }, { title: "Internationale muligheder", description: "studieophold og/eller praktik" }, { title: "Mistrivsel", description: "fx i forhold til studiet, hverdagen" }, { title: "Optagelsesvejledning", description: "fx indhold, adgangskrav, videreuddannelse, struktur" }, { title: "Ordensreglement", description: "fx krænkelser, overskridelser af regler" }, { title: "Orlov", description: "" }, { title: "Overflytning/genindskrivning", description: "(internt/eksternt)" }, { title: "Personlige forhold", description: "(fx alvorlige sociale begivenheder, familiære/nære forhold)" }, { title: "Praktik i DK/klinik/dialogmøder", description: "Spørgsmål om praktik eller lign." }, { title: "Ikke studierelevant", description: "Ting der ikke er relevante" }, { title: "SPS", description: "Spørgsmål om SPS" }, { title: "Studieophør", description: "Udmeldelse" }, { title: "Studieplanlægning", description: "individuel studieplan, omlagte forløb. Fx forsinkede studerende og UCL Eliteordning" }, { title: "Studietvivl / Studievalg", description: "Spørgsmå om studievallg" }, { title: "Studieudfordringer", description: "faglige, eksamensnervøsitet/-angst, studie- og eksamensteknik, forståelse for studiet, samarbejdsvanskeligheder, manglende gruppe mm." }, { title: "Sygdom", description: "egen fysisk eller psykisk sygdom mm." }, { title: "Undervisningen", description: "fx samarbejdsvanskeligheder med underviser, kritik af kvaliteten" }, { title: "Økonomi", description: "fx SU, private forhold" }]);


let durations = ref(["1-15 min", "16-30 min", "31-45 min", "46-60 min", "Mere end 60 min"]);




function filteredEducations() {

    return educations_minus_fav.filter((edu) =>
        edu.toLowerCase().includes(input_educations.value.toLowerCase())
    );
}

function filteredSubject() {
    let subject_title = [];

    for (let i = 0; i < subjects.value.length; i++) {

        let obj = {
            title: subjects.value[i].title,
            description: subjects.value[i].description
        }
        subject_title.push(obj);
    }

    return subject_title.filter(subject_title =>
        subject_title.description.toLowerCase().includes(input_subjects.value.toLocaleLowerCase()) || subject_title.title.toLowerCase().includes(input_subjects.value.toLocaleLowerCase()));


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

}

function sex(e) {
    anwsers.sex = e;

    const boxes = document.querySelectorAll('.form-group-2-1 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");

}

function level(e) {
    anwsers.niveau = e;

    const boxes = document.querySelectorAll('.form-group-2-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");

}

function location_anwser(e) {

    anwsers.locations = e;


    const boxes = document.querySelectorAll('.form-group-3-1 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });
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

}

function next(e) {

    switch (e) {
        case 1:
            const boxes = document.querySelector('.alert_1')
            if (anwsers.type == "") {
                boxes.classList.add("alert")
                location.href = "#";
                location.href = "#alert_1";

            } else {
                step.value += 1;
                boxes.classList.remove("alert");

            }
            break;

        case 2:
            if (anwsers.sex == "" || anwsers.niveau == "") {
                if (anwsers.sex == "") {
                    const boxes = document.querySelector('.alert_2')
                    boxes.classList.add("alert")
                    location.href = "#";
                    location.href = "#alert_2";

                } else if (anwsers.niveau == "") {
                    const boxes = document.querySelector('.alert_3')
                    boxes.classList.add("alert")
                    location.href = "#";
                    location.href = "#alert_3";
                }

            } else {
                step.value += 1;
                const boxes = document.querySelectorAll('alert')
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;

        case 3:
            if (anwsers.locations == "" || anwsers.educations == "") {
                if (anwsers.locations == "") {
                    const boxes = document.querySelector('.alert_4')
                    boxes.classList.add("alert")
                    location.href = "#";
                    location.href = "#alert_4";

                } else if (anwsers.educations == "") {
                    const boxes = document.querySelector('.alert_5')
                    boxes.classList.add("alert")
                }

            } else {
                step.value += 1;
                const boxes = document.querySelectorAll('alert')
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;

        case 4:
            if (anwsers.subject == "" || anwsers.duration == "") {
                if (anwsers.subject == "") {
                    const boxes = document.querySelector('.alert_6')

                    boxes.classList.add("alert")
                    location.href = "#";
                    location.href = "#alert_6";

                } else if (anwsers.duration == "") {
                    const boxes = document.querySelector('.alert_7')
                    boxes.classList.add("alert")
                }
            } else {
                step.value += 1;
                const boxes = document.querySelectorAll('alert')
                boxes.forEach(box => {
                    box.classList.remove("alert");
                });
            }
            break;
    }
}

function loadMore() {
    document.querySelector(".loadbtn").classList.toggle("loaded");
    document.querySelector(".load").classList.toggle("displaynone");
}

function previous(x) {
    const boxes = document.querySelectorAll('button')
    boxes.forEach(box => {
        box.classList.remove("alert")
    });
    // step.value = step.value - 1;

    switch (x) {
        case 1:
            step.value = step.value - 1;
            break;

        case 2:
            step.value = step.value - 2;
            break;

        case 3:
            step.value = step.value - 3;
            break;

    }
}

function done() {
    // step.value = 1;
    window.location.href = '/?succes=true';

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
                <div class="2 bobble" @click.prevent="next(1)">
                    <p>2</p>
                    <p> {{ bub2 }}</p>
                </div>
                <div class="3 bobble" @click.prevent="next(2)">
                    <p>3</p>
                    <p>{{ bub3 }}</p>

                </div>
                <div class="4 bobble" @click.prevent="next(3)">
                    <p>4</p>
                    <p>{{ bub4 }}</p>
                </div>
            </div>
            <div class="form-group-1">

                <h2>{{ sp_1 }}</h2>
                <div class="form-group-1-1 form-style">
                    <select @change="month($event)">
                        <option v-for="date in select_month" :value="date"> {{ date }}</option>
                    </select>
                    <button v-on:click="getText()">test</button>
                </div>
                <h2>{{ sp_2 }}</h2>
                <p class="alert_text alert_1 ">* Vælg venligst type henvændelse</p>
                <div class="form-group-1-2 form-style">
                    <button v-for="type in types" @click="meeting(type)" :id="type"> {{ type }} </button>
                </div>
            </div>

            <div class="navigation-group">
                <div class="next"><input class="form_btn button" type="submit" value="Næste" @click.prevent="next(1)">
                </div>
            </div>
        </section>

        <!-- step 2 - Hvem er det med -->
        <section class="register" v-show="step === 2">
            <div class="progress_bar">
                <div class="1 bobble active" @click.prevent="previous(1)">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobble active">
                    <p>2</p>
                    <p> {{ bub2 }}</p>
                </div>
                <div class="3 bobble" @click.prevent="next(1)">
                    <p>3</p>
                    <p>{{ bub3 }}</p>

                </div>
                <div class="4 bobble" @click.prevent="next(2)">
                    <p>4</p>
                    <p>{{ bub4 }}</p>
                </div>
            </div>

            <h2>{{ sp_3 }}</h2>
            <p class="alert_text alert_2">* Du mangler noget her </p>
            <div class="form-group-2-1 form-style">
                <button v-for="person in persons" @click="sex(person)" :id="person"> {{ person }} </button>
            </div>

            <h2 class="seperator">{{ sp_4 }}</h2>
            <p class="alert_text alert_3">* Du mangler at udfylde niveau.</p>
            <div class="form-group-2-2 form-style">
                <button v-for="niveau in niveaus" @click="level(niveau)" :id="niveau"> {{ niveau }}</button>
            </div>

            <div class="navigation-group">
                <div class="back"><input class="form_btn button back" type="submit" value="Tilbage"
                        @click.prevent="previous(1)"></div>
                <div class="seperatordiv"></div>
                <div class="next"><input class="form_btn button next" type="submit" value="Næste"
                        @click.prevent="next(2)"></div>
            </div>
        </section>

        <!-- step 3 -  Uddannelsested-->
        <section class="register" v-show="step === 3">
            <div class="progress_bar">
                <div class="1 bobble active" @click.prevent="previous(2)">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobble active" @click.prevent="previous(1)">
                    <p>2</p>
                    <p> {{ bub2 }}</p>
                </div>
                <div class="3 bobble active">
                    <p>3</p>
                    <p>{{ bub3 }}</p>
                </div>
                <div class="4 bobble" @click.prevent="next(1)">
                    <p>4</p>
                    <p>{{ bub4 }}</p>
                </div>
            </div>
            <h2>{{ sp_5 }}</h2>
            <p class="alert_text alert_4">* Du mangler noget her...</p>
            <div class="form-group-3-1 form-style">
                <button v-for="location in locations" :id="location" @click="location_anwser(location)"> {{ location }}
                </button>
            </div>

            <h2 class="seperator">Vælg uddannelse(r)</h2>
            <p class="alert_text alert_5">* Du mangler noget her...</p>
            <div class="educations form-group-3-2 form-style">
                <div v-for="edu in f_educations" :key="edu">
                    <button @click="educations_anwser(edu)" :id="edu"> {{ edu }} </button>
                    <span>Fast</span>
                </div>
            </div>

            <div class="search-box position-fix">
                <input type="text" v-model="input_educations" placeholder="Søg..." />
            </div>

            <div class="educations loadbtn">
                <button v-for="edu in filteredEducations()" :id="edu" :key="edu" @click="educations_anwser(edu)"> {{ edu
                }}
                </button>
            </div>

            <span class="load" @click="loadMore()">Indlæs mere</span>

            <div class="navigation-group">
                <div class="back"><input class="form_btn button back" type="submit" value="Tilbage"
                        @click.prevent="previous(1)"></div>
                <div class="seperatordiv"></div>
                <div class="next"><input class="form_btn button next" type="submit" value="Næste"
                        @click.prevent="next(3)"></div>
            </div>

        </section>

        <!-- step 4 - Hvad handler samtalen om -->
        <section class="register form-group-4 " v-show="step === 4">
            <div class="progress_bar">
                <div class="1 bobble active" @click.prevent="previous(3)">
                    <p>1</p>
                    <p>{{ bub1 }}</p>
                </div>
                <div class="2 bobble active" @click.prevent="previous(2)">
                    <p>2</p>
                    <p> {{ bub2 }}</p>
                </div>
                <div class="3 bobble active" @click.prevent="previous(1)">
                    <p>3</p>
                    <p>{{ bub3 }}</p>
                </div>
                <div class="4 bobble active ">
                    <p>4</p>
                    <p>{{ bub4 }}</p>
                </div>
            </div>
            <h2>{{ sp_6 }}</h2>

            <div class="search-box">
                <input type="text" v-model="input_subjects" placeholder="Søg..." />
            </div>
            <p class="alert_text alert_6">* Du mangler noget her...</p>
            <div class="educations form-group-4-1 form-style">

                <div class="subjects" v-for="subject in filteredSubject()">

                    <p v-show="subject.description" id="subject_icon">i<span id="subject_test"> {{ subject.description
                    }}</span></p>

                    <button :id="subject.title" :key="subject.title" @click="subject_anwser(subject.title)"> {{
                            subject.title
                    }}
                    </button>

                </div>

            </div>

            <h2 class="seperator"> Hvor lang tid tog det?</h2>
            <p class="alert_text alert_7">* Du mangler noget her...</p>
            <div class="form-group-4-2 form-style">
                <button v-for="duration in durations" :id="duration" @click="duration_anwser(duration)"> {{ duration
                }}</button>
            </div>

            <div class="navigation-group">
                <div class="back"><input class="form_btn button back" type="submit" value="Tilbage"
                        @click.prevent="previous(1)"></div>
                <div class="seperatordiv"></div>
                <div class="next"><input class="form_btn button next" type="submit" value="Næste"
                        @click.prevent="next(4)"></div>
            </div>

        </section>

        <!-- step 5 - result -->
        <section class="register" v-show="step === 5">
            <h2>Dette er de information du har valgt</h2>

            <div class="anwsers">
                <p>Sex: {{ anwsers.sex }}</p>
                <p>Type: {{ anwsers.type }}</p>
                <p>Month: {{ anwsers.month }}</p>
                <p>Duration: {{ anwsers.duration }}</p>
                <p>Location: {{ anwsers.locations }}
                </p>
                <p>Educations: <li v-for="e in anwsers.educations">{{ e }} </li>
                </p>
                <p>Subjects: <li v-for="e in anwsers.subject">{{ e }} </li>
                </p>
            </div>

            <div class="navigation-group">

                <div class="back"> <input class="form_btn button back" type="submit" value="Tilbage"
                        @click.prevent="previous(1)"></div>
                <div class="seperatordiv"></div>
                <div class="next"><input class="form_btn button next" type="submit" value="Afslut"
                        @click.prevent="done"></div>
            </div>

        </section>
    </div>
</template>

<style lang="scss" scoped>
@import "../assets/scss/colors.scss";
@import "../assets/scss/typography.scss";
@import "../assets/scss/variabler.scss";
@import "../assets/scss/button.scss";
@import "../assets/scss/mixins.scss";
@import "../assets/scss/layout.scss";

.progress_bar {
    display: flex;
    justify-content: space-between;
    width: 100%;
    max-width: 861px;
    position: absolute;
    top: -120px;

    p {
        &:first-of-type {
            margin-bottom: 0px;
        }
    }

    .bobble {
        background: #fff;
        border-radius: 50%;
        height: 60px;
        width: 60px;
        display: flex;
        align-items: center;
        justify-content: center;
        position: relative;
        box-shadow: $stdDropshadow;

        &:after {
            position: absolute;
            content: " ";
            width: 220px;
            height: 3px;
            background: #fff;
            left: -214px;
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
            position: absolute;
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
            color: #fff;

            &:last-of-type {

                color: $Midnight-Green;
            }
        }
    }
}

.selected {
    background-color: $Maize !important;
    color: $Midnight-Green;
    border: none;
    font-weight: bold;
    transition: 0.5s;
    box-shadow: $stdDropshadow;
}

.alert_text {
    display: none;
}

.alert {
    display: flex;
    justify-content: center;
    padding-bottom: 15px;
    font-size: 12px;
    color: rgb(255, 255, 255);
    text-decoration: underline dotted red 5px;
}


.section-wrapper {
    @include mainWrap;
}

.register {
    @include flowDesign;
    position: relative;


    .form_btn {
        border: none;
        text-transform: uppercase;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        font-size: 12px;
    }

    .educations {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        gap: 16px;
        width: 100%;



        button {
            width: 170px;
            height: 40px;
        }

        span {
            font-size: 12px;
            background-color: $Verdigris;
            padding: 2px 10px;

            position: relative;
            left: -6px;
            top: -79px;
            border-radius: 10px;
            box-shadow: $stdDropshadow;
        }

    }

    .anwsers {
        font-size: 16px;
    }

    .subjects {
        width: 240px;
        height: 50px;
        position: relative;

        span {
            position: absolute;
            top: -10px;
            display: none;
            padding: 10px 10px;
            min-width: 200px;
            text-align: center;
        }

        #subject_icon {
            font-style: italic;
            font-size: 14px;
            color: rgb(255, 255, 255);
            background-color: $Verdigris;

            border-radius: 50%;
            width: 20px;
            height: 20px;

            display: flex;
            justify-content: center;
            align-items: center;

            position: absolute;
            top: -8px;
            right: 8px;

            &:hover {
                span {
                    display: block;
                    z-index: 99999;
                }

            }
        }




    }
}
</style>