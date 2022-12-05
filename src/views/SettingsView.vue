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
      users: [],
      disabled: true,
    };
  },
  methods: {
    //GET, UPDATE, DELETE (POST)
    getUsers() {
      fetch("https://uclssapitest.azurewebsites.net/api/user")
        .then((response) => response.json())
        .then((data) => (this.users = data));
    },
    toggleEditMode(user_id) {
      this.disabled = false
      document.getElementsByClassName('edit-editUser')[0].style.display = 'none';
      document.getElementsByClassName('save-editUser')[0].style.display = 'block';
    },
    editUser(user_id, firstName, lastName, email, password, title, edu_id) {
      fetch("https://uclssapitest.azurewebsites.net/api/user/" + user_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: user_id,
          firstName: firstName,
          lastName: lastName,
          email: email,
          password: password,
          title: title,
          edu_id: edu_id,
        }),
      })
        .then((response) => response.json())
        .then((data) => console.log(data));
        this.disabled = true
        document.getElementsByClassName('edit-editUser')[0].style.display = 'block';
        document.getElementsByClassName('save-editUser')[0].style.display = 'none';
      },
    deleteUser(user_id) {
      fetch("https://uclssapitest.azurewebsites.net/api/user/" + user_id, { method: 'DELETE' })
        .then(() => this.status = 'Delete successful');
    },
    getSubjects() {
      fetch("https://uclssapitest.azurewebsites.net/api/subject")
        .then((response) => response.json())
        .then((data) => (this.subjects = data));
    },
    toggleEditMode(subject_id) {
      this.disabled = false
      document.getElementsByClassName('edit-editsubject')[0].style.display = 'none';
      document.getElementsByClassName('save-editsubject')[0].style.display = 'block';
    },
    editSubject(subject_id, name, description) {
      fetch("https://uclssapitest.azurewebsites.net/api/subject/" + subject_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          subject_id: subject_id,
          name: name,
          description: description
        }),
      })
        .then((response) => response.json())
        .then((data) => console.log(data));
        this.disabled = true
        document.getElementsByClassName('edit-editsubject')[0].style.display = 'block';
        document.getElementsByClassName('save-editsubject')[0].style.display = 'none';
    },
    deleteSubject(subject_id) {
    fetch("https://uclssapitest.azurewebsites.net/api/subject/" + subject_id, { method: 'DELETE' })
      .then(() => this.status = 'Delete successful');
    },
    //post, delete, edit subjects
    getLocations() {
      fetch("https://uclssapitest.azurewebsites.net/api/location")
        .then((response) => response.json())
        .then((data) => (this.locations = data));
    },
    //post, delete, edit locations
    getEducations() {
      fetch("https://uclssapitest.azurewebsites.net/api/education")
        .then((response) => response.json())
        .then((data) => (this.educations = data));
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
    <div class="settings-container">
      <tab :tabList="tabList">
        <template v-slot:tabPanel-1>
          <div class="header">
            <h2>Brugere</h2>
            <button>Tilføj ny bruger</button>
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
                  <input type="text" v-model="user.firstName" :disabled="(disabled == true)"/>
                </td>
                <td>
                  <input type="text" v-model="user.lastName" :disabled="(disabled == true)"/>
                </td>
                <td>
                  <input type="text" v-model="user.email" :disabled="(disabled == true)" />
                </td>
                <td>{{ user.title }}</td>
                <td class="edit_save">
                  <button
                    class="save save-editUser"
                    @click="
                      editUser(
                        user.user_id,
                        user.firstName,
                        user.lastName,
                        user.email,
                        user.password,
                        user.title,
                        user.edu_id
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
                    class="edit-editUser" 
                    @click="toggleEditMode(user.user_id,)"
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
                    @click="
                      deleteUser(
                        user.user_id
                      )
                    "
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
        <template v-slot:tabPanel-2>
          <div class="header">
            <h2>Emner</h2>
            <button>Tilføj nyt emne</button>
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
                  <input type="text" v-model="subject.name" :disabled="(disabled == true)"/>
                </td>
                <td>
                  <textarea type="text" v-model="subject.description" :disabled="(disabled == true)"/>
                </td>
                <td class="edit_save">
                  <button
                    class="save save-editsubject"
                    @click="
                      editSubject(
                        subject.subject_id,
                        subject.name,
                        subject.description
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
                    class="edit-editsubject" 
                    @click="toggleEditMode(subject.subject_id,)"
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
                    @click="
                      deleteSubject(
                        subject.subject_id
                      )
                    "
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
        <template v-slot:tabPanel-3>
          <div class="header">
            <h2>Lokationer</h2>
            <button>Tilføj ny lokation</button>
          </div>
          <table>
            <thead>
              <tr>
                <th>Navn</th>
                <th></th>
                <th>Rediger/slet</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="location in locations" :key="location.location_id">
                <td>{{ location.name }}</td>
                <td></td>
                <td>
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
                      <path
                        id="b21743bd27446b402537e815c62aa968"
                        d="M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z"
                        transform="translate(1216.246 610.243)"
                        fill="#153943"
                      />
                    </g>
                  </svg>
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
                <td>{{ education.name }}</td>
                <td>
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
                      <path
                        id="b21743bd27446b402537e815c62aa968"
                        d="M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z"
                        transform="translate(1216.246 610.243)"
                        fill="#153943"
                      />
                    </g>
                  </svg>
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
          
          input{
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
