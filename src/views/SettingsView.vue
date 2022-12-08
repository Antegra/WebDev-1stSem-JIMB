<script>
import tab from "../components/tabs.vue";
import { onBeforeMount, ref } from "vue";
export default {
  components: {
    tab,
  },
  data() {
    return {
      tabList: [
        "Brugere",
        "Emner",
        "Lokationer",
        "Uddannelser",
        "Eksport",
        "Profil",
      ],
      //user tab
      users: [],
      userModalShow: false,
      user_id: 0,
      firstName: "",
      lastName: "",
      email: "",
      password: "",
      title: "",
      location: "",
      location_id: "",
      edu_id: "",
      role_id: 0,
      edu_name: "",
      description: "",
      //subject tab
      subjects: [],
      subjectModalShow: false,
      subject_id: "",
      name: "",
      locations: [],
      educations: []
    };
  },
  methods: {
    //Methodes for the user tab
    getUsers() {
      fetch("https://uclssapitest.azurewebsites.net/api/user")
        .then((response) => response.json())
        .then((data) => (this.users = data));
    },
    addClick() {
      this.user_id = 0;
      this.firstName = "";
      this.lastName = "";
      this.email = "";
      this.password = "";
      this.title = "";
      this.location = "";
      this.location_id = "";
      this.role_id = 0;
      this.edu_id = "";
      this.edu_name = "";
    },
    editUser(user) {
      this.modalTitle = "Rediger "+ user.firstName + "s profil";
      this.user_id = user.user_id;
      this.firstName = user.firstName;
      this.lastName = user.lastName;
      this.email = user.email;
      this.password = user.password;
      this.title = user.title;
      this.location = user.location;
      this.location_id = user.location_id;
      this.role_id = user.role_id;
      this.edu_id = user.edu_id;
      this.edu_name = user.edu_name;
    },
    createClick() {
      fetch("https://uclssapitest.azurewebsites.net/api/user/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: this.user_id,
          firstName: this.firstName,
          lastName: this.lastName,
          email: this.email,
          password: this.email,
          title: this.title,
          location: this.location,
          location_id: this.location_id,
          role_id: this.role_id,
          edu_id: this.edu_id,
          edu_name: this.edu_name,
        }),
      })
      .then((response) => {
            response.json()
            this.getUsers();
        });
    },
    updateClick(user_id) {
      fetch("https://uclssapitest.azurewebsites.net/api/user/" + user_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: this.user_id,
          firstName: this.firstName,
          lastName: this.lastName,
          email: this.email,
          password: this.email,
          title: this.title,
          location: this.location,
          location_id: this.location_id,
          role_id: this.role_id,
          edu_id: this.edu_id,
          edu_name: this.edu_name,
        }),
      })
        .then((response) => {
            response.json()
            this.getUsers();
        });
    },
    deleteUser(user_id) {
      if(!confirm("Er du sikker på at du vil slette brugeren?")){
            return;
        }
      fetch("https://uclssapitest.azurewebsites.net/api/user/" + user_id, {
        method: "DELETE",
      })
      .then((response)=>{
            response.json()
            this.getUsers();
        });
    },
    //Methodes for the subject tab
    getSubjects() {
      fetch("https://uclssapitest.azurewebsites.net/api/subject")
        .then((response) => response.json())
        .then((data) => (this.subjects = data));
    },
    addClick() {
      this.subject_id = 0;
      this.name = "";
      this.description = "";
    },
    editSubject(subject) {
      this.modalTitle = "Rediger emne";
      this.subject_id = subject.subject_id;
      this.name = subject.name;
      this.description = subject.description;
    },
    createClick() {
      fetch("https://uclssapitest.azurewebsites.net/api/subject/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          subject_id: this.subject_id,
          name: this.name,
          description: this.description
        }),
      })
      .then((response) => {
            response.json()
            this.getSubjects();
        });
    },
    updateClick(subject_id) {
      fetch("https://uclssapitest.azurewebsites.net/api/subject/" + subject_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          subject_id: this.subject_id,
          name: this.name,
          description: this.description
        }),
      })
        .then((response) => {
            response.json()
            this.getSubjects();
        });
    },
    deleteSubject(subject_id) {
      if(!confirm("Er du sikker på at du vil slette emnet?")){
            return;
        }
      fetch("https://uclssapitest.azurewebsites.net/api/subject/" + subject_id, {
        method: "DELETE",
      })
      .then((response)=>{
            response.json()
            this.getSubjects();
        });
    },
    getLocations() {
      fetch("https://uclssapitest.azurewebsites.net/api/location")
        .then((response) => response.json())
        .then((data) => (this.locations = data));
    },
    toggleEditMode(location_id) {
      this.disabled = false;
      document.getElementsByClassName("edit-editlocation")[0].style.display =
        "none";
      document.getElementsByClassName("save-editlocation")[0].style.display =
        "block";
    },
    editLocation(location_id, name) {
      fetch(
        "https://uclssapitest.azurewebsites.net/api/location/" + location_id,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            location_id: location_id,
            name: name,
          }),
        }
      )
        .then((response) => response.json())
        .then((data) => console.log(data));
      this.disabled = true;
      document.getElementsByClassName("edit-editlocation")[0].style.display =
        "block";
      document.getElementsByClassName("save-editlocation")[0].style.display =
        "none";
    },
    deleteLocation(location_id) {
      fetch(
        "https://uclssapitest.azurewebsites.net/api/location/" + location_id,
        { method: "DELETE" }
      ).then(() => (this.status = "Delete successful"));
    },
    //post, delete, edit locations
    getEducations() {
      fetch("https://uclssapitest.azurewebsites.net/api/education")
        .then((response) => response.json())
        .then((data) => (this.educations = data));
    },
    toggleEditMode(edu_id) {
      this.disabled = false;
      document.getElementsByClassName("edit-editeducation")[0].style.display =
        "none";
      document.getElementsByClassName("save-editeducation")[0].style.display =
        "block";
    },
    editEducation(edu_id, name) {
      fetch("https://uclssapitest.azurewebsites.net/api/education/" + edu_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          edu_id: edu_id,
          name: name,
          location: location,
        }),
      })
        .then((response) => response.json())
        .then((data) => console.log(data));
      this.disabled = true;
      document.getElementsByClassName("edit-editeducation")[0].style.display =
        "block";
      document.getElementsByClassName("save-editeducation")[0].style.display =
        "none";
    },
  },
  beforeMount() {
    this.getUsers();
    this.getSubjects();
    this.getLocations();
    this.getEducations();
  },
};
</script>
<template>
  <div class="settings">
    <div class="modal" v-if="userModalShow">
      <div class="modal-container">
        <h2 class="modal-title">Tilføj en ny bruger</h2>
        <div class="modal-content">
          <div class="input-container">
            <span>Fornavn</span>
            <input type="text" v-model="firstName" />
          </div>
          <div class="input-container">
            <span>Efternavn</span>
            <input type="text" v-model="lastName" />
          </div>
          <div class="input-container">
            <span>Email</span>
            <input type="text" v-model="email" />
          </div>
          <div class="input-container">
            <span>Role_id</span>
            <input type="text" v-model="role_id" />
          </div>
          <div class="input-container">
            <span>Edu_id</span>
            <input type="text" v-model="edu_id" />
          </div>
        </div>
        <div class="action-container">
          <button
            class="yellow-button"
            v-if="user_id == 0"
            @click="createClick(), (userModalShow = false)"
          >
            Opret
          </button>
          <button 
            class="yellow-button"
            v-if="user_id != 0" 
            @click="updateClick(user_id), (userModalShow = false)"
          >
            Opdater
          </button>
          <button @click="userModalShow = false">Luk</button>
        </div>
      </div>
    </div>
    <div class="modal" v-if="subjectModalShow">
      <div class="modal-container">
        <h2 class="modal-title">Tilføj et nyt emne</h2>
        <div class="modal-content">
          <div class="input-container">
            <span>Name</span>
            <input type="text" v-model="name" />
          </div>
          <div class="input-container">
            <span>Hjælpebeskrivelse</span>
            <input type="text" v-model="description" />
          </div>
        </div>
        <div class="action-container">
          <button
            class="yellow-button"
            v-if="subject_id == 0"
            @click="createClick(), (subjectModalShow = false)"
          >
            Opret
          </button>
          <button 
            class="yellow-button"
            v-if="subject_id != 0" 
            @click="updateClick(subject_id), (subjectModalShow = false)"
          >
            Opdater
          </button>
          <button @click="subjectModalShow = false">Luk</button>
        </div>
      </div>
    </div>
    <div class="settings-container">
      <tab :tabList="tabList">
        <template v-slot:tabPanel-1>
          <div class="header">
            <h2>Brugere</h2>
            <button @click="addClick(user), (userModalShow = true)">
              Tilføj ny bruger
            </button>
          </div>
          <table>
            <thead>
              <tr>
                <th>Fornavn</th>
                <th>Efternavn</th>
                <th>Email</th>
                <th>Brugerrolle</th>
                <th>Rediger/slet</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="user in users" :key="user.user_id">
                <td>
                  <p>{{ user.firstName }}</p>
                </td>
                <td>
                  <p>{{ user.lastName }}</p>
                </td>
                <td>
                  <p>{{ user.email }}</p>
                </td>
                <td>{{ user.title }}</td>
                <td class="edit_save">
                  <button
                    @click="editUser(user), (userModalShow = true)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="b21743bd27446b402537e815c62aa968"
                          d="M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z"
                          transform="translate(1216.246 610.243)"
                          fill="#153943"
                        />
                      </g>
                    </svg>
                  </button>
                  <button class="delete" @click="deleteUser(user.user_id)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="da086273b974cb595139babd4da17772"
                          d="M21.015,10.466l-.328,9.75a3.245,3.245,0,0,1-3.281,3.106H11.172a3.245,3.245,0,0,1-3.281-3.1l-.328-9.753A.821.821,0,0,1,9.2,10.413l.328,9.752a1.627,1.627,0,0,0,1.641,1.549h6.234a1.627,1.627,0,0,0,1.641-1.552l.328-9.749a.821.821,0,0,1,1.641.053ZM22.1,7.221a.813.813,0,0,1-.82.805H7.3a.805.805,0,1,1,0-1.611H9.841a1.04,1.04,0,0,0,1.044-.925,2.437,2.437,0,0,1,2.448-2.17h1.911a2.437,2.437,0,0,1,2.448,2.17,1.04,1.04,0,0,0,1.044.925h2.543a.813.813,0,0,1,.82.805Zm-9.791-.805h3.96a2.619,2.619,0,0,1-.209-.76.815.815,0,0,0-.815-.725H13.334a.815.815,0,0,0-.815.725,2.62,2.62,0,0,1-.21.76Zm.826,12.2V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Zm3.949,0V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Z"
                          transform="translate(1256.167 608.678)"
                          fill="#eb0000"
                        />
                      </g>
                    </svg>
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <template v-slot:tabPanel-2>
          <div class="header">
            <h2>Emner</h2>
            <button @click="addClick(subject), (subjectModalShow = true)">
              Tilføj nyt emne
            </button>
          </div>
          <table>
            <thead>
              <tr>
                <th>Navn</th>
                <th>Hjælpebeskrivelse</th>
                <th>Rediger/slet</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="subject in subjects" :key="subject.subject_id">
                <td>
                  <p>{{ subject.name }}</p>
                </td>
                <td>
                  <p>{{ subject.description }}</p>
                </td>
                <td class="edit_save">
                  <button
                    @click="editSubject(subject), (subjectModalShow = true)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="b21743bd27446b402537e815c62aa968"
                          d="M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z"
                          transform="translate(1216.246 610.243)"
                          fill="#153943"
                        />
                      </g>
                    </svg>
                  </button>
                  <button class="delete" @click="deleteSubject(subject.subject_id)">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="da086273b974cb595139babd4da17772"
                          d="M21.015,10.466l-.328,9.75a3.245,3.245,0,0,1-3.281,3.106H11.172a3.245,3.245,0,0,1-3.281-3.1l-.328-9.753A.821.821,0,0,1,9.2,10.413l.328,9.752a1.627,1.627,0,0,0,1.641,1.549h6.234a1.627,1.627,0,0,0,1.641-1.552l.328-9.749a.821.821,0,0,1,1.641.053ZM22.1,7.221a.813.813,0,0,1-.82.805H7.3a.805.805,0,1,1,0-1.611H9.841a1.04,1.04,0,0,0,1.044-.925,2.437,2.437,0,0,1,2.448-2.17h1.911a2.437,2.437,0,0,1,2.448,2.17,1.04,1.04,0,0,0,1.044.925h2.543a.813.813,0,0,1,.82.805Zm-9.791-.805h3.96a2.619,2.619,0,0,1-.209-.76.815.815,0,0,0-.815-.725H13.334a.815.815,0,0,0-.815.725,2.62,2.62,0,0,1-.21.76Zm.826,12.2V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Zm3.949,0V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Z"
                          transform="translate(1256.167 608.678)"
                          fill="#eb0000"
                        />
                      </g>
                    </svg>
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <template v-slot:tabPanel-3>
          <div class="header">
            <h2>Lokationer</h2>
            <button>Tilføj ny lokation</button>
          </div>
          <table>
            <thead>
              <tr>
                <th>Navn</th>
                <th>Rediger/slet</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="location in locations" :key="location.location_id">
                <td>
                  <p>{{ location.name }}</p>
                </td>
                <td class="edit_save">
                  <button
                    class="save save-editlocation"
                    @click="editLocation(location.location_id, location.name)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="19.996"
                      height="19.996"
                      viewBox="0 0 19.996 19.996"
                    >
                      <g
                        id="Group_515"
                        data-name="Group 515"
                        transform="translate(-1210.069 -497.5)"
                      >
                        <path
                          id="_2228276036f5689efb63c251f173c8b0"
                          data-name="2228276036f5689efb63c251f173c8b0"
                          d="M23.007,10.32,16.341,3.655a1.111,1.111,0,0,0-.355-.233,1.211,1.211,0,0,0-.433-.089H6.665A3.333,3.333,0,0,0,3.333,6.665V20a3.333,3.333,0,0,0,3.333,3.333H20A3.333,3.333,0,0,0,23.329,20V11.109A1.111,1.111,0,0,0,23.007,10.32ZM10,5.554h4.444V7.776H10Zm6.665,15.553H10V17.774a1.111,1.111,0,0,1,1.111-1.111h4.444a1.111,1.111,0,0,1,1.111,1.111ZM21.107,20A1.111,1.111,0,0,1,20,21.107H18.885V17.774a3.333,3.333,0,0,0-3.333-3.333H11.109a3.333,3.333,0,0,0-3.333,3.333v3.333H6.665A1.111,1.111,0,0,1,5.554,20V6.665A1.111,1.111,0,0,1,6.665,5.554H7.776V8.887A1.111,1.111,0,0,0,8.887,10h6.665a1.111,1.111,0,0,0,1.111-1.111V7.121l4.444,4.444Z"
                          transform="translate(1206.736 494.167)"
                          fill="#198754"
                        />
                      </g>
                    </svg>
                  </button>
                  <button
                    class="edit-editlocation"
                    @click="toggleEditMode(location.location_id)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="b21743bd27446b402537e815c62aa968"
                          d="M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z"
                          transform="translate(1216.246 610.243)"
                          fill="#153943"
                        />
                      </g>
                    </svg>
                  </button>
                  <button
                    class="delete"
                    @click="deleteLocation(location.location_id)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="da086273b974cb595139babd4da17772"
                          d="M21.015,10.466l-.328,9.75a3.245,3.245,0,0,1-3.281,3.106H11.172a3.245,3.245,0,0,1-3.281-3.1l-.328-9.753A.821.821,0,0,1,9.2,10.413l.328,9.752a1.627,1.627,0,0,0,1.641,1.549h6.234a1.627,1.627,0,0,0,1.641-1.552l.328-9.749a.821.821,0,0,1,1.641.053ZM22.1,7.221a.813.813,0,0,1-.82.805H7.3a.805.805,0,1,1,0-1.611H9.841a1.04,1.04,0,0,0,1.044-.925,2.437,2.437,0,0,1,2.448-2.17h1.911a2.437,2.437,0,0,1,2.448,2.17,1.04,1.04,0,0,0,1.044.925h2.543a.813.813,0,0,1,.82.805Zm-9.791-.805h3.96a2.619,2.619,0,0,1-.209-.76.815.815,0,0,0-.815-.725H13.334a.815.815,0,0,0-.815.725,2.62,2.62,0,0,1-.21.76Zm.826,12.2V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Zm3.949,0V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Z"
                          transform="translate(1256.167 608.678)"
                          fill="#eb0000"
                        />
                      </g>
                    </svg>
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <template v-slot:tabPanel-4>
          <div class="header">
            <h2>Uddannelse</h2>
            <button>Tilføj ny uddannelse</button>
          </div>
          <table>
            <thead>
              <tr>
                <th>Navn</th>
                <th>Sted</th>
                <th>Rediger/slet</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="education in educations" :key="education.edu_id">
                <td>
                  <p>{{ education.name }}</p>
                </td>
                <td>
                  <p>{{ education.location }}</p>
                </td>
                <td class="edit_save">
                  <button
                    class="save save-editeducation"
                    @click="
                      editEducation(
                        education.edu_id,
                        education.name,
                        education.location
                      )
                    "
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="19.996"
                      height="19.996"
                      viewBox="0 0 19.996 19.996"
                    >
                      <g
                        id="Group_515"
                        data-name="Group 515"
                        transform="translate(-1210.069 -497.5)"
                      >
                        <path
                          id="_2228276036f5689efb63c251f173c8b0"
                          data-name="2228276036f5689efb63c251f173c8b0"
                          d="M23.007,10.32,16.341,3.655a1.111,1.111,0,0,0-.355-.233,1.211,1.211,0,0,0-.433-.089H6.665A3.333,3.333,0,0,0,3.333,6.665V20a3.333,3.333,0,0,0,3.333,3.333H20A3.333,3.333,0,0,0,23.329,20V11.109A1.111,1.111,0,0,0,23.007,10.32ZM10,5.554h4.444V7.776H10Zm6.665,15.553H10V17.774a1.111,1.111,0,0,1,1.111-1.111h4.444a1.111,1.111,0,0,1,1.111,1.111ZM21.107,20A1.111,1.111,0,0,1,20,21.107H18.885V17.774a3.333,3.333,0,0,0-3.333-3.333H11.109a3.333,3.333,0,0,0-3.333,3.333v3.333H6.665A1.111,1.111,0,0,1,5.554,20V6.665A1.111,1.111,0,0,1,6.665,5.554H7.776V8.887A1.111,1.111,0,0,0,8.887,10h6.665a1.111,1.111,0,0,0,1.111-1.111V7.121l4.444,4.444Z"
                          transform="translate(1206.736 494.167)"
                          fill="#198754"
                        />
                      </g>
                    </svg>
                  </button>
                  <button
                    class="edit-editeducation"
                    @click="toggleEditMode(education.edu_id)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="b21743bd27446b402537e815c62aa968"
                          d="M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z"
                          transform="translate(1216.246 610.243)"
                          fill="#153943"
                        />
                      </g>
                    </svg>
                  </button>
                  <button
                    class="delete"
                    @click="deleteEducation(education.edu_id)"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="59.825"
                      height="20"
                      viewBox="0 0 59.825 20"
                    >
                      <g
                        id="Group_478"
                        data-name="Group 478"
                        transform="translate(-1218.442 -612)"
                      >
                        <path
                          id="da086273b974cb595139babd4da17772"
                          d="M21.015,10.466l-.328,9.75a3.245,3.245,0,0,1-3.281,3.106H11.172a3.245,3.245,0,0,1-3.281-3.1l-.328-9.753A.821.821,0,0,1,9.2,10.413l.328,9.752a1.627,1.627,0,0,0,1.641,1.549h6.234a1.627,1.627,0,0,0,1.641-1.552l.328-9.749a.821.821,0,0,1,1.641.053ZM22.1,7.221a.813.813,0,0,1-.82.805H7.3a.805.805,0,1,1,0-1.611H9.841a1.04,1.04,0,0,0,1.044-.925,2.437,2.437,0,0,1,2.448-2.17h1.911a2.437,2.437,0,0,1,2.448,2.17,1.04,1.04,0,0,0,1.044.925h2.543a.813.813,0,0,1,.82.805Zm-9.791-.805h3.96a2.619,2.619,0,0,1-.209-.76.815.815,0,0,0-.815-.725H13.334a.815.815,0,0,0-.815.725,2.62,2.62,0,0,1-.21.76Zm.826,12.2V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Zm3.949,0V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Z"
                          transform="translate(1256.167 608.678)"
                          fill="#eb0000"
                        />
                      </g>
                    </svg>
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <template v-slot:tabPanel-5> Content 5 </template>
        <template v-slot:tabPanel-6> Content 6 </template>
      </tab>
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

.settings {
  @include mainWrap;

  .modal {
    height: 100%;
    width: 100%;
    background-color: rgba($color: #000000, $alpha: 0.5);
    position: fixed;
    top: 0;
    left: 0;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    color: $Midnight-Green;
    
    &-container {
      background-color: #ffffff;
      padding: 24px;
      display: flex;
      flex-direction: column;
      border-radius: 10px;
      .modal-title {
        margin: 0;
        padding-bottom: 32px;
      }

      .modal-content {
        display: flex;
        flex-direction: row;
        .input-container {
          display: flex;
          flex-direction: column;
          justify-content: center;
          align-items: flex-start;
          
          span {
            font-weight: bold;
            font-size: 16px;
          }
          input {
            color: $Midnight-Green;
            font-size: 16px;
            padding: 8px;
            margin-right:32px;
            border: 1px solid $Midnight-Green;
            &:focus-visible {
              padding: 7px;
              outline: none;
              border: 2px solid $Midnight-Green;
            }
          }
        }
      }
      .action-container {
        display: flex;
        flex-direction: row;
        padding-top: 32px;
        justify-content: space-between
      }
    }
  }
  .settings-container {
    @include flowDesign;
    padding: 40px;

    .header {
      display: flex;
      justify-content: space-between;
    }

    table {
      border-collapse: collapse;
      padding: 40px;
      width: 100%;
      background: #ffffff;
      border-radius: 5px;
      border: none;
      color: $Midnight-Green;

      tr {
        border: solid 1px $Midnight-Green;

        &:nth-child(even) {
          background-color: #f2f2f2;
        }

        &:hover {
          background-color: $Maize;
        }

        td {
          padding: 0 16px;

          input {
            color: $Midnight-Green;
            font-size: 16px;
            border: solid 1px $Midnight-Green;
            border-radius: 5px;
            background-color: transparent;

            &:focus-visible {
              outline: none;
            }

            &:disabled {
              border: none;
              background-color: transparent;
            }
          }

          textarea {
            width: 350px;
            resize: none;
            font-size: 16px;
            font-family: inherit;
            color: inherit;
            border: solid 1px $Midnight-Green;
            border-radius: 5px;
            background-color: transparent;
            vertical-align: middle;

            &:disabled {
              border: none;
              background: transparent;
            }
          }
        }
        th {
          padding: 0 16px;
          height: 50px;
          text-align: left;
        }
        .edit_save {
          display: flex;
          flex-direction: row;

          button {
            cursor: pointer;
            background: none;
            width: 30px !important;
          }

          .save {
            display: none;
          }
        }
      }
    }
  }
}
</style>
