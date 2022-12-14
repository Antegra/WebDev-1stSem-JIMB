<script setup>
import { ref, computed, onBeforeMount } from 'vue';
import { API_URL } from '../connection';



// henter informantion om bruger som er logget ind
let user = JSON.parse(localStorage.getItem('user-token'));

// Step bruges til at holde styr på hvilket step i flowet brugen er noget til
let step = ref(1);

// Anwsers holder de informationer som bruger ønsker at indsætter i deres sag
let anwsers = {
    month: "",
    type: 0,
    sex: 0,
    niveau: 0,
    locations: user[0].location_id,
    educations: [],
    subject: [],
    duration: 0,
    user_id: user[0].user_id
};

// Tekst til progressbaren
let bub1 = "Måned & type";
let bub2 = "Køn & studiestatus";
let bub3 = "Lokation & uddannelser";
let bub4 = "Emner & tid";

// step 1 - Om mødet 
let sp_1 = ref("Angiv måned");

// Her oprettes der datoer, de har navn og id. Navet bruges til at vise frem til bruger og id bruges til at det skal gemmes i databasen
let dates = ref([{ name: "Januar", id: 0 }, { name: "Februar", id: 1 }, { name: "Marts", id: 2 }, { namae: "April", id: 3 }, { name: "Maj", id: 4 }, { name: "Juni", id: 5 }, { name: "Juli", id: 6 }, { name: "August", id: 7 }, { name: "September", id: 8 }, { name: "Oktober", id: 9 }, { name: "November", id: 10 }, { name: "December", id: 11 }]);
const d = new Date();

let q = d.toISOString().substring(0, 10)
let select_month = ref([]);

// Her bliver dagens dato sat automatisk som det, de gerne vil sende med.
anwsers.month = q;

// Her fortælles hvor mange månede tilbage de har mulighed for at vælge
select_month = [dates.value[d.getMonth()], dates.value[d.getMonth() - 1], dates.value[d.getMonth() - 2]];

let sp_2 = ref("Type henvendelse")
let types = ref([]);

// step 2 - Hvem blev vejledt?
let sp_3 = ref("Hvem blev vejledt?");
let persons = ref([]);

let sp_4 = ref("Studie status");
let niveaus = ref([{ id: 10, name: "Nuværende studerende" }, { id: 20, name: "Potentielle studerende" }]);

// step 3 - Uddannelsested
let sp_5 = ref("Uddannelsested");

// Holder "string" af hvad bruger tasker ind i søgefeltet
let input_educations = ref("");

// Holder alle lokationer
let locations = ref([]);

// Holder alle uddannelser
let educations = ref([]);

// Holder brugernes faste uddannelser
let f_educations = ref([]);

// Tjekke hvilker faste uddannelser som den bruger som er logget ind har, og sætte dem ind i f_educations
if (user[0].edu_id.length > 1) {
    let user_edu_name = user[0].edu_name.split(",");
    let user_edu_id = user[0].edu_id.split(",");
    let user_edu_real_id = [];
    for (let i = 0; i < user_edu_id.length; i++) {
        user_edu_real_id.push(Number(user_edu_id[i]));
    }

    let user_edu_id_sorted = user_edu_real_id.sort(function (a, b) { return a - b });

    for (let i = 0; i < user_edu_id_sorted.length; i++) {

        f_educations.value.push({ id: user_edu_id_sorted[i], name: user_edu_name[i] })
    }

} else {
    let user_edu_name = user[0].edu_name;
    let user_edu_id = user[0].edu_id;


    for (let i = 0; i < user_edu_id.length; i++) {
        f_educations.value.push({ id: user_edu_id, name: user_edu_name })
    }
}

// step 4 - Hvad handlede samtalen om ?
let sp_6 = ref("Samtaleemne");

// Holder "string" af hvad bruger tasker ind i søgefeltet
let input_subjects = ref("");

// Holder alle emner
let subjects = ref([]);

// Holder længerne 
let durations = ref([]);

// Disse functioner bliver kørt som det første når siden bliver loaded
onBeforeMount(async () => {
    // Henter types fra api og gemmen ned i types variablen 
    const fetchedTypes = await fetch(API_URL + 'type')
        .then((fetchedTypes) => fetchedTypes.json())
    for (let i = 0; i < fetchedTypes.length; i++) {
        types.value.push({ name: fetchedTypes[i].name, id: fetchedTypes[i].type_id })
    }

    // Henter gender fra api og gemmen ned i gender variablen 
    const fetchedGender = await fetch(API_URL + 'sex')
        .then((fetchedGender) => fetchedGender.json())
    for (let i = 0; i < fetchedGender.length; i++) {
        persons.value.push({ name: fetchedGender[i].name, id: fetchedGender[i].sex_id })
    }

    // Henter locations fra api og gemmen ned i location variablen 
    const fetchedLocation = await fetch(API_URL + 'location')
        .then((fetchedLocation) => fetchedLocation.json())
    for (let i = 0; i < fetchedLocation.length; i++) {
        locations.value.push({ id: fetchedLocation[i].location_id, name: fetchedLocation[i].name })
    }

    // Henter locations fra api og gemmen ned i location variablen 
    const fetchedEducation = await fetch(API_URL + 'Education')
        .then((fetchedEducation) => fetchedEducation.json())
    for (let i = 0; i < fetchedEducation.length; i++) {
        educations.value.push({ id: fetchedEducation[i].edu_id, name: fetchedEducation[i].name })
    }

    // Henter Subjects fra api og gemmen ned i Subjects variablen 
    const fetchedSubject = await fetch(API_URL + 'Subject')
        .then((fetchedSubject) => fetchedSubject.json())
    for (let i = 0; i < fetchedSubject.length; i++) {
        subjects.value.push({ id: fetchedSubject[i].subject_id, name: fetchedSubject[i].name, description: fetchedSubject[i].description })
    }
    // Henter Duration fra api og gemmen ned i Duration variablen 
    const fetchedDuration = await fetch(API_URL + 'Duration')
        .then((fetchedDuration) => fetchedDuration.json())
    for (let i = 0; i < fetchedDuration.length; i++) {
        durations.value.push({ id: fetchedDuration[i].duration_id, name: fetchedDuration[i].length })
    }
})

// her bliver bliver f_educations filtere fra alle uddannelser
const educations_minus_fav2 = computed(() => {
    return educations.value.filter((obj) => {
        for (let i = 0; i < f_educations.value.length; i++) {
            if (f_educations.value[i].id == obj.id) {
                return false;
            }
        }

        return true;
    });


})

// Dette er et søge felt som søge på de uddannelser som ikke er faste på brugeren
const filteredEducations = computed(() => {
    return educations_minus_fav2.value.filter((edu) =>
        edu.name.toLowerCase().includes(input_educations.value.toLowerCase())
    );

})

// Dette er et søge felt som søge på emner
function filteredSubject() {
    return subjects.value.filter(subject_title =>
        subject_title.description.toLowerCase().includes(input_subjects.value.toLowerCase()) || subject_title.name.toLowerCase().includes(input_subjects.value.toLowerCase()));
}

// Sætter den valgte månede id i anwsers
function month(e) {
    d.setMonth(e.target.value);
    anwsers.month = d.toISOString().substring(0, 10);
}

// Sætter den valgte type id i anwsers, som sætter styling på den valgte type
function meeting(e) {
    anwsers.type = e;
    const boxes = document.querySelectorAll('.form-group-1-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e).classList.toggle("selected");

}

// Sætter den valgte gender id i anwsers, som sætter styling på den valgte gender
function sex(e) {
    anwsers.sex = e.id;

    const boxes = document.querySelectorAll('.form-group-2-1 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e.name).classList.toggle("selected");

}

// Sætter den nivuea type id i anwsers, som sætter styling på den valgte nivea
function level(e) {
    anwsers.niveau = e.id;

    const boxes = document.querySelectorAll('.form-group-2-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e.id).classList.toggle("selected");

}

// Sætter den valgte type id i anwsers, som sætter styling på den valgte type
function location_anwser(e) {

    anwsers.locations = e.id;

    const boxes = document.querySelectorAll('.form-group-3-1 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });
    document.getElementById(e.name).classList.toggle("selected");
}

// Sætter de valgte uddannelser id i anwsers, som sætter styling på den valgte uddannelser
function educations_anwser(e) {
    if (anwsers.educations.includes(e.id)) {
        anwsers.educations = anwsers.educations.filter(function (item) {
            return item !== e.id
        });
    } else {
        anwsers.educations.push(e.id);

    }
    document.getElementById(e.name).classList.toggle("selected");
}

// Sætter de valgte emner id i anwsers, som sætter styling på den valgte emner
function subject_anwser(e) {
    if (anwsers.subject.includes(e.id)) {
        anwsers.subject = anwsers.subject.filter(function (item) {
            subjects.value[e.id].isSelected = false;
            return item !== e.id
        });
    } else {
        anwsers.subject.push(e.id);
        subjects.value[e.index].isSelected = true;
    }

    document.getElementById(e.name).classList.toggle("selected");
}

// Sætter den valgte længe id i anwsers, som sætter styling på den valgte længe
function duration_anwser(e) {
    anwsers.duration = e.id;
    const boxes = document.querySelectorAll('.form-group-4-2 .selected');

    boxes.forEach(box => {
        box.classList.remove('selected');
    });

    document.getElementById(e.name).classList.toggle("selected");
}

// Sætter ændre vi step, for bringe burger videre til næste step i flowet, samt tjekker om alt er blevet udfyldt
function next(e) {
    const boxes = document.querySelectorAll('p')
    boxes.forEach(box => {
        box.classList.remove("alert")
    });

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

    }
}

// Denne function loader flere emner eller uddannelser
function loadMore() {
    document.querySelector(".loadbtn").classList.toggle("loaded");
    document.querySelector(".load").classList.toggle("displaynone");
}

// bringer bruger tilbage
function previous(x) {
    const boxes = document.querySelectorAll('p')
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

// Her sender vi anwsers til database og oprette en ny sag
async function done() {
    var c = ((15 < anwsers.niveau) ? false : true);
    let case_id = 0;

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
        step.value = 0;

        const boxes = document.querySelectorAll('alert')
        boxes.forEach(box => {
            box.classList.remove("alert");
        });


        try {
            const params = {
                "case_id": 0,
                "month": anwsers.month,
                "name": "string",
                "supervisor": "string",
                "sex": "string",
                "length": "string",
                "education": "string",
                "location": "string",
                "subject": "string",
                "user_id": anwsers.user_id,
                "sex_id": anwsers.sex,
                "duration_id": anwsers.duration,
                "type_id": anwsers.type,
                "edu_id": 0,
                "location_id": 0,
                "subject_id": 0,
                "primeEdu": 1,
                "niveau": c,
                "nationality": true
            };

            const options = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(params)
            };
            // Grund sagen bliver oprettet og sender case_id tilbage som bliver gemt i et variable
            await fetch('https://uclssapitest.azurewebsites.net/api/Case', options)
                .then(response => response.json())
                .then(response => {
                    case_id = response.case_id;
                });
        } catch (error) {
            console.error("failed to post, case");
        }

        // Sender educations til database, her bruges case_id fra grund sagen for at kunne oprette combine tablerne
        for (let i = 0; i < anwsers.educations.length; i++) {
            try {
                const params = {
                    "edu_id": anwsers.educations[i],
                    "case_id": case_id
                };

                const options = {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(params)
                };
                await fetch(API_URL + 'EducationCase', options)
                    .then(response => response)
            } catch (error) {
                console.error("failed to post, Educations");
            }
        };
        // Sender lokation til database, her bruges case_id fra grund sagen for at kunne oprette combine tablerne
        try {
            const params2 = {

                "location_id": anwsers.locations,
                "case_id": case_id
            };

            const options2 = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(params2)
            };
            await fetch(API_URL + 'LocationCase', options2)
                .then(response => response)
        } catch (error) {
            console.error("failed to post, locations");
        }
        // Sender emner til database, her bruges case_id fra grund sagen for at kunne oprette combine tablerne
        for (let i = 0; i < anwsers.subject.length; i++) {
            try {
                const params = {

                    "subject_id": anwsers.subject[i],
                    "case_id": case_id
                };

                const options = {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(params)
                };
                await fetch(API_URL + 'SubjectCase', options)
                    .then(response => response)
            } catch (error) {
                console.error("failed to post, subjects");
            }
        };
        // Step bliver sat til 1 igen, så flowet er klar til at bliver gået igennem igen
        step.value = 1;

        // Sender brugen tilbage til forsiden
        window.location.href = '/?succes=true';
    }


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
                        <option class="form-text" v-for="date in select_month" :value="date.id"> {{ date.name }}
                        </option>
                    </select>
                </div>
                <h2>{{ sp_2 }}</h2>
                <p class="alert_text alert_1 ">* Du mangler at udfylde noget her.</p>
                <div class="form-group-1-2 form-style">
                    <button class="form-text" v-for="type in types" @click="meeting(type.id)" :id="type.id"> {{
                            type.name
                    }} </button>
                </div>
            </div>

            <div class="navigation-group">
                <div class="next"><input href="#sec-step" class="form_btn button" type="submit" value="Næste"
                        @click.prevent="next(1)">
                </div>
            </div>
        </section>

        <!-- step 2 - Hvem er det med -->
        <section class="register" id="sec-step" v-show="step === 2">
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
            <p class="alert_text alert_2">* Du mangler at udfylde noget her.</p>
            <div class="form-group-2-1 form-style">
                <button class="form-text" v-for="person in persons" @click="sex(person)" :id="person.name"> {{
                        person.name
                }}
                </button>
            </div>
            <h2 class="seperator">{{ sp_4 }}</h2>
            <p class="alert_text alert_3">* Du mangler at udfylde noget her.</p>
            <div class="form-group-2-2 form-style">
                <button class="form-text" v-for="niveau in niveaus" @click="level(niveau)" :id="niveau.id"> {{
                        niveau.name
                }}</button>
            </div>
            <div class="navigation-group">
                <div class="back "><input class="form_btn button back" type="submit" value="Tilbage"
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
            <p class="alert_text alert_4">* Du mangler at udfylde noget her.</p>
            <div class="form-group-3-1 form-style">
                <button class="form-text" :class="{ 'selected': location.id == anwsers.locations }"
                    v-for="location in locations" :id="location.name" @click="location_anwser(location)"> {{
                            location.name
                    }}
                </button>
            </div>
            <h2 class="seperator">Uddannelser</h2>
            <p class="alert_text alert_5">* Du mangler at udfylde noget her.</p>
            <div class="educations form-group-3-2 form-style">
                <div v-for="educations in f_educations" :key="educations">
                    <button class="form-text" @click="educations_anwser(educations)" :id="educations.name"> {{
                            educations.name
                    }}
                    </button>
                    <span>Fast</span>
                </div>
            </div>
            <div class="search-box position-fix">
                <input class="form-text" type="text" v-model="input_educations"
                    placeholder="Søg efter uddannelser..." />
            </div>
            <div class="educations loadbtn">
                <button class="form-text" v-for="educations in filteredEducations" :id="educations.name"
                    :key="educations" @click="educations_anwser(educations)"> {{
                            educations.name
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
        <div class="spinner" v-show="(step === 0)">
            <div class="lds-roller">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
            <p>Opretter sagen</p>
        </div>
        <!-- step 4 - Hvad handler samtalen om -->
        <section class="register gone form-group-4 " v-show="step === 4">

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
                <input class="form-text" type="text" v-model="input_subjects" placeholder="Søg efter emner..." />
            </div>
            <p class="alert_text alert_6">* Du mangler at udfylde noget her.</p>
            <div class="educations form-group-4-1 form-style">
                <div class="subjects" v-for="(subject, index) in filteredSubject()">
                    <p v-show="subject.description" id="subject_icon">i<span id="subject_test"> {{ subject.description
                    }}</span></p>

                    <button class="form-text" :id="subject.name" :class="{ 'selected': subject.isSelected }"
                        :key="subject" @click="subject_anwser({ ...subject, index: index })"> {{
                                subject.name
                        }}
                    </button>
                </div>
            </div>
            <h2 class="seperator">Samtalens længde</h2>
            <p class="alert_text alert_7">* Du mangler at udfylde noget her.</p>
            <div class="form-group-4-2 form-style">
                <button class="form-text" v-for="duration in durations" :id="duration.name"
                    @click="duration_anwser(duration)"> {{
                            duration.name
                    }}</button>
            </div>
            <div class="navigation-group">
                <div class="back"><input class="form_btn button back" type="submit" value="Tilbage"
                        @click.prevent="previous(1)"></div>
                <div class="seperatordiv"></div>
                <div class="next"><input class="form_btn button next" type="submit" value="Næste"
                        @click.prevent="done()"></div>
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
    max-width: 801px;
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
    padding: 13px;
    font-size: 16px;
    color: rgb(255, 255, 255);
    border-radius: 5px;
    background: red;
    max-width: 300px;
    justify-content: center;
    align-items: center;
    text-align: center;
    margin: auto;
    margin-bottom: 20px;
}

.section-wrapper {
    @include mainWrap;
}

.register {
    @include flowDesign;
    position: relative;

    .form_btn {
        border: none;

        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        font-size: 16px;
    }

    .educations {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        gap: 16px;
        width: 100%;

        .subjects {
            display: flex;
        }

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
        width: 224px;
        height: 50px;
        position: relative;

        span {
            position: absolute;
            top: -10px;
            display: none;
            padding: 20px;
            min-width: 200px;
            text-align: center;
            color: $Midnight-Green;
            font-weight: 400;
            font-style: initial;
            font-size: 16px;
            background: #fff;
            border: 1px solid $Midnight-Green;
        }

        #subject_icon {
            font-style: italic;
            font-size: 14px;
            color: fff;
            background-color: $Verdigris;
            border-radius: 50%;
            width: 20px;
            height: 20px;
            display: flex;
            justify-content: center;
            align-items: center;
            position: absolute;
            top: -8px;
            right: -10px;

            &:hover {
                span {
                    display: block;
                    z-index: 99999;
                }
            }
        }
    }
}

.spinner {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 50vw;
    height: 50vh;

    p {
        padding-top: 14px;
        color: $Midnight-Green;
    }

    .lds-roller {
        display: inline-block;
        position: relative;
        width: 80px;
        height: 80px;
    }

    .lds-roller div {
        animation: lds-roller 1.5s cubic-bezier(0.5, 0, 0.5, 1) infinite;
        transform-origin: 40px 40px;
    }

    .lds-roller div:after {
        content: " ";
        display: block;
        position: absolute;
        width: 7px;
        height: 7px;
        border-radius: 50%;
        background: $Midnight-Green;
        margin: -4px 0 0 -4px;
    }

    .lds-roller div:nth-child(1) {
        animation-delay: -0.036s;
    }

    .lds-roller div:nth-child(1):after {
        top: 63px;
        left: 63px;
    }

    .lds-roller div:nth-child(2) {
        animation-delay: -0.072s;
    }

    .lds-roller div:nth-child(2):after {
        top: 68px;
        left: 56px;
    }

    .lds-roller div:nth-child(3) {
        animation-delay: -0.108s;
    }

    .lds-roller div:nth-child(3):after {
        top: 71px;
        left: 48px;
    }

    .lds-roller div:nth-child(4) {
        animation-delay: -0.144s;
    }

    .lds-roller div:nth-child(4):after {
        top: 72px;
        left: 40px;
    }

    .lds-roller div:nth-child(5) {
        animation-delay: -0.18s;
    }

    .lds-roller div:nth-child(5):after {
        top: 71px;
        left: 32px;
    }

    .lds-roller div:nth-child(6) {
        animation-delay: -0.216s;
    }

    .lds-roller div:nth-child(6):after {
        top: 68px;
        left: 24px;
    }

    .lds-roller div:nth-child(7) {
        animation-delay: -0.252s;
    }

    .lds-roller div:nth-child(7):after {
        top: 63px;
        left: 17px;
    }

    .lds-roller div:nth-child(8) {
        animation-delay: -0.288s;
    }

    .lds-roller div:nth-child(8):after {
        top: 56px;
        left: 12px;
    }

    @keyframes lds-roller {
        0% {
            transform: rotate(0deg);
        }

        100% {
            transform: rotate(360deg);
        }
    }
}
</style>