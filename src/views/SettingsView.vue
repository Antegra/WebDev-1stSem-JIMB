<script>
import JsonCSV from 'vue-json-csv'
import tab from "../components/tabs.vue";
import { onBeforeMount, ref } from "vue";
import { API_URL } from '../connection';
export default {
  components: {
    tab,
    'downloadCsv': JsonCSV
  },
  data() {
    let user = localStorage.getItem('user-token');
    let jsonUser = JSON.parse(user);



    return {
      allCases: [],
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
      user: {
        userModalShow: false,
        modalTitle: "",
        user_id: 0,
        firstName: "",
        lastName: "",
        email: "",
        title: "",
        location: "",
        location_id: 0,
        edu_id: "",
        role_id: 0,
        edu_name: ""
      },
      //subject tab
      subjects: [],
      subject: {
        subjectModalShow: false,
        modalTitle: "",
        subject_id: "",
        name: "",
        description: ""
      },
      //location tab
      locations: [],
      location: {
        locationModalShow: false,
        modalTitle: "",
        location_id: 0,
        name: ""
      },
      //education tab
      educations: [],
      education: {
        educationModalShow: false,
        modalTitle: "",
        edu_id: 0,
        name: "",
        location: "",
      },
      //profil tab
      profileUsers: [],
      profileUser: {
        edu_id: [],
        edu_name: jsonUser[0].edu_name,
        selectedEducations: [],
        location_id: [],
        selectedLocations: [],
        //newPassword: "",
        firstName: jsonUser[0].firstName,
        lastName: jsonUser[0].lastName,
        email: jsonUser[0].email,
        role_id: jsonUser[0].role_id,
        user_id: jsonUser[0].user_id,
        location: jsonUser[0].location
      },
      SVUserid: jsonUser[0].user_id,
      SVFirstName: jsonUser[0].firstName,
      SVLastName: jsonUser[0].lastName,
      SVEmail: jsonUser[0].email,
      SVRoleId: jsonUser[0].role_id,
      SVEduid: jsonUser[0].edu_id,
      SVEduname: jsonUser[0].edu_name,
      SVLocationid: jsonUser[0].location_id,
      SVLocation: jsonUser[0].location,
    };
  },
  methods: {
    //Methodes for the user tab
    getUsers() {
      fetch(API_URL + "user")
        .then((response) => response.json())
        .then((data) => (this.users = data));
    },



    addUser() {
      this.user.modalTitle = "Tilføj en ny bruger";
      this.user.user_id = 0;
      this.user.firstName = "";
      this.user.lastName = "";
      this.user.email = "";
      this.user.password = "";
      this.user.title = "";
      this.user.location = "";
      this.user.location_id = 0;
      this.user.role_id = 0;
      this.user.edu_id = "";
      this.user.edu_name = "";
    },
    editUser(u) {
      this.user.modalTitle = "Rediger bruger";
      this.user.user_id = u.user_id;
      this.user.firstName = u.firstName;
      this.user.lastName = u.lastName;
      this.user.email = u.email;
      this.user.password = u.password;
      this.user.title = u.title;
      this.user.location = u.location;
      this.user.location_id = u.location_id;
      this.user.role_id = u.role_id;
      this.user.edu_id = u.edu_id;
      this.user.edu_name = u.edu_name;
    },
    async createUser() {
      let id = 0;
      let educationList = this.user.edu_id.split(",");
      let realEducationList = [];
      for (let i = 0; i < educationList.length; i++) {
        realEducationList.push(Number(educationList[i]))
      }
      await fetch(API_URL + "User/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: this.user.user_id,
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          email: this.user.email,
          password: this.user.password,
          title: this.user.title,
          location: "string",
          location_id: "string",
          role_id: this.user.role_id,
          edu_id: "string",
          edu_name: "string"
        }),
      })
        .then(response => response.json())
        .then(response => {
          id = response.user_id;
        });
      //EduUser
      for (let i = 0; i < educationList.length; i++) {
        fetch(API_URL + "EduUser/", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            user_id: id,
            edu_id: realEducationList[i]
          }),
        })
          .then(response => response.json());
      };
      //LocationUser
      fetch(API_URL + "LocationUser/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: id,
          location_id: this.user.location_id
        }),
      })
        .then(response => response.json());
    },
    updateUser(user_id) {
      fetch(API_URL + "user/" + user_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: this.user.user_id,
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          email: this.user.email,
          password: this.user.password,
          title: this.user.title,
          location: this.user.location,
          location_id: this.user.location_id,
          role_id: this.user.role_id,
          edu_id: this.user.edu_id,
          edu_name: this.user.edu_name,
        }),
      })
        .then((response) => {
          response.json()
          this.getUsers();
        });
    },
    deleteUser(user_id) {
      if (!confirm("Er du sikker på at du vil slette brugeren?")) {
        return;
      }
      fetch(API_URL + "user/" + user_id, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => {
          response.json()
          this.getUsers();
        });
    },
    //Methodes for the subject tab
    getSubjects() {
      fetch(API_URL + "subject")
        .then((response) => response.json())
        .then((data) => (this.subjects = data));
    },
    addSubject() {
      this.subject.modalTitle = "Tilføj et nyt emne";
      this.subject.subject_id = 0;
      this.subject.name = "";
      this.subject.description = "";
    },
    editSubject(s) {
      this.subject.modalTitle = "Rediger emne";
      this.subject.subject_id = s.subject_id;
      this.subject.name = s.name;
      this.subject.description = s.description;
    },
    createSubject() {
      fetch(API_URL + "subject/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          subject_id: this.subject.subject_id,
          name: this.subject.name,
          description: this.subject.description
        }),
      })
        .then((response) => {
          response.json()
          this.getSubjects();
        });
    },
    updateSubject(subject_id) {
      fetch(API_URL + "subject/" + subject_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          subject_id: this.subject.subject_id,
          name: this.subject.name,
          description: this.subject.description
        }),
      })
        .then((response) => {
          response.json()
          this.getSubjects();
        });
    },
    deleteSubject(subject_id) {
      if (!confirm("Er du sikker på at du vil slette emnet?")) {
        return;
      }
      fetch(API_URL + "subject/" + subject_id, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => {
          response.json()
          this.getSubjects();
        });
    },
    //Methodes for the location tab
    getLocations() {
      fetch(API_URL + "location")
        .then((response) => response.json())
        .then((data) => (this.locations = data));
    },
    addLocation() {
      this.location.modalTitle = "Tilføj en ny lokation";
      this.location.location_id = 0;
      this.location.name = "";
    },
    editLocation(l) {
      this.location.modalTitle = "Rediger lokation";
      this.location.location_id = l.location_id;
      this.location.name = l.name;
    },
    createLocation() {
      fetch(API_URL + "location/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          location_id: this.location.location_id,
          name: this.location.name
        }),
      })
        .then((response) => {
          response.json()
          this.getLocations();
        });
    },
    updateLocation(location_id) {
      fetch(API_URL + "location/" + location_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          location_id: this.location.location_id,
          name: this.location.name
        }),
      })
        .then((response) => {
          response.json()
          this.getLocations();
        });
    },
    deleteLocation(location_id) {
      if (!confirm("Er du sikker på at du vil slette lokationen?")) {
        return;
      }
      fetch(API_URL + "location/" + location_id, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => {
          response.json()
          this.getLocations();
        });
    },
    //Methodes for the education tab
    getEducations() {
      fetch(API_URL + "education")
        .then((response) => response.json())
        .then((data) => (this.educations = data));
    },
    addEducation() {
      this.education.modalTitle = "Tilføj en ny uddannelse";
      this.education.edu_id = 0;
      this.education.name = "";
      this.education.location = "";
    },
    editEducation(e) {
      this.education.modalTitle = "Rediger uddannelse";
      this.education.edu_id = e.edu_id;
      this.education.name = e.name;
      this.education.location = e.location;
    },
    createEducation() {
      fetch(API_URL + "education/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          edu_id: this.education.edu_id,
          name: this.education.name,
          location: this.education.location
        }),
      })
        .then((response) => {
          response.json()
          this.getEducations();
        });
    },
    updateEducation(edu_id) {
      fetch(API_URL + "education/" + edu_id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          edu_id: this.education.edu_id,
          name: this.education.name,
          location: this.education.location
        }),
      })
        .then((response) => {
          response.json()
          this.getEducations();
        });
    },
    deleteEducation(edu_id) {
      if (!confirm("Er du sikker på at du vil slette uddannelsen?")) {
        return;
      }
      fetch(API_URL + "education/" + edu_id, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => {
          response.json()
          this.getEducations();
        });
    },
    logOut() {
      localStorage.removeItem("user-token");
      window.location.href = '/';
    },
    getFavEducation() {
      //split the string and pushs the values to the profilUser 
      let educationList = this.SVEduid;
      for (let i = 0; i < educationList.length; i++) {
        this.profileUser.edu_id.push(Number(educationList[i]))
      }
    },
    setFavEducation(e) {
      if (this.profileUser.edu_id.includes(e.edu_id)) {
        let selectedEdu = this.profileUser.selectedEducations;
        selectedEdu.push(e.edu_id);
        let id = this.SVUserid;
        let urlEducationParams = e.edu_id + ", " + id
        //for (let i = 0; i < selectedEdu.length; i++) {
        fetch(API_URL + "EduUser/" + urlEducationParams, {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        })
          .then((response) => {
            response.json();

            this.profileUser.edu_id = this.profileUser.edu_id.filter(function (item) {
              return item != e.edu_id
            })

            this.profileUser.edu_name = this.profileUser.edu_name.filter(function (item) {
              return item != e.name
            })

            console.log("Fjern uddannelse ", this.profileUser)



            if (this.profileUsers = [])
              this.profileUsers.push(this.profileUser)


            window.localStorage.setItem("user-token", JSON.stringify(this.profileUsers))

          });
        //}


      } else {
        let selectedEdu = this.profileUser.selectedEducations;
        selectedEdu.push(e.edu_id);
        let id = this.SVUserid;

        //for (let i = 0; i < selectedEdu.length; i++) {
        fetch(API_URL + "EduUser", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            edu_id: e.edu_id,
            user_id: id
          }),
        })
          .then((response) => {
            response.json();

            this.profileUser.edu_id.push(e.edu_id);

            this.profileUser.edu_name.push(e.name);


            //this.getEducations();
            if (this.profileUsers = [])
              this.profileUsers.push(this.profileUser)

            /*       let stringEdu = this.profileUsers[0].edu_id.toString();
                  this.profileUsers.edu_id = stringEdu; */
            console.log("Tilføj ", this.profileUsers);


            window.localStorage.setItem("user-token", JSON.stringify(this.profileUsers))

            /*               if (confirm("Du har nu ændret din din favorrit uddannelse og skal logge ind igen."))
                          this.logOut(); */
          });


        //}
      }




    },
    getFavLocation() {
      //split the string and pushs the values to the profilUser 
      let locationList = this.SVLocationid;
      for (let i = 0; i < locationList.length; i++) {
        this.profileUser.location_id.push(Number(locationList[i]))
      }
    },
    setFavLocation(location_id) {
      let profilLocation = document.getElementById("profilLocation");
      let isprofilLocationPresent = profilLocation.classList.contains("selected");

      if (isprofilLocationPresent) {
        let selectedLocation = this.profileUser.selectedLocations;
        selectedLocation.push(location_id);
        let id = this.SVUserid;
        let urlLocationParams = location_id + ", " + id;

        for (let i = 0; i < selectedLocation.length; i++) {
          fetch(API_URL + "LocationUser/" + urlLocationParams, {
            method: "DELETE",
            headers: {
              "Content-Type": "application/json",
            },
          })
            .then((response) => {
              response.json();
              this.getLocations();
              if (confirm("Du har nu ændret din din lokation og skal logge ind igen."))
                this.logOut();
            });
        }
      } else {
        let selectedLocation = this.profileUser.selectedLocations;
        selectedLocation.push(location_id);
        let id = this.SVUserid;

        for (let i = 0; i < selectedLocation.length; i++) {
          fetch(API_URL + "api/LocationUser", {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              user_id: id,
              location_id: selectedLocation[0]
            }),
          })
            .then((response) => {
              response.json();
              this.getLocations();
              if (confirm("Du har nu ændret din lokation og skal logge ind igen."))
                this.logOut();
            });
        }
      }
    },
    updatePassword(id) {
      fetch(API_URL + "user/" + id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          user_id: id,
          firstName: this.SVFirstName,
          lastName: this.SVLastName,
          email: this.SVEmail,
          password: this.newPassword,
          title: "",
          location: this.SVLocation,
          location_id: this.SVLocationid,
          role_id: this.SVRoleId,
          edu_id: this.SVEduid,
          edu_name: this.SVEduname,
        }),
      })
        .then((response) => {
          response.json();
          this.getUsers();
          if (confirm("Du har nu ændret din adgangskode og skal logge ind igen."))
            this.logOut();
        });
    },
    getAllCases() {
      fetch(API_URL + '/case')
        .then((response) => response.json())
        .then((data) => (this.allCases = data));
    },
  },
  beforeMount() {
    this.getUsers();
    this.getSubjects();
    this.getLocations();
    this.getEducations();
    this.getFavEducation();
    this.getFavLocation();
    this.getAllCases();
  },



};
</script>
<template>
  <div class="settings">
    <!--Modal for the users-->
    <div class="modal" v-if="user.userModalShow">
      <div class="modal-container">
        <h2 class="modal-title">{{ user.modalTitle }}</h2>
        <div class="modal-content">
          <div class="input-container">
            <span>Fornavn</span>
            <input type="text" v-model="user.firstName" />
          </div>
          <div class="input-container">
            <span>Efternavn</span>
            <input type="text" v-model="user.lastName" />
          </div>
          <div class="input-container">
            <span>Email</span>
            <input type="text" v-model="user.email" />
          </div>
          <div class="input-container">
            <span>Role id</span>
            <input type="text" v-model="user.role_id" />
          </div>
          <div class="input-container">
            <span>Password</span>
            <input type="text" v-model="user.password" />
          </div>
          <div class="input-container">
            <span>Education id</span>
            <input type="text" v-model="user.edu_id" />
          </div>
          <div class="input-container">
            <span>Location id</span>
            <input type="number" v-model="user.location_id" />
          </div>
        </div>
        <div class="action-container">
          <button class="yellow-button" v-if="user.user_id == 0" @click="createUser(), (user.userModalShow = false)">
            Opret
          </button>
          <button class="yellow-button" v-if="user.user_id != 0"
            @click="updateUser(user.user_id), (user.userModalShow = false)">
            Opdater
          </button>
          <button @click="user.userModalShow = false">Luk</button>
        </div>
      </div>
    </div>
    <!--Modal for the subjects-->
    <div class="modal" v-if="subject.subjectModalShow">
      <div class="modal-container">
        <h2 class="modal-title">{{ subject.modalTitle }}</h2>
        <div class="modal-content">
          <div class="input-container">
            <span>Name</span>
            <input type="text" v-model="subject.name" />
          </div>
          <div class="input-container">
            <span>Hjælpebeskrivelse</span>
            <textarea v-model="subject.description" />
          </div>
        </div>
        <div class="action-container">
          <button class="yellow-button" v-if="subject.subject_id == 0"
            @click="createSubject(), (subject.subjectModalShow = false)">
            Opret
          </button>
          <button class="yellow-button" v-if="subject.subject_id != 0"
            @click="updateSubject(subject.subject_id), (subject.subjectModalShow = false)">
            Opdater
          </button>
          <button @click="subject.subjectModalShow = false">Luk</button>
        </div>
      </div>
    </div>
    <!--Modal for the locations-->
    <div class="modal" v-if="location.locationModalShow">
      <div class="modal-container">
        <h2 class="modal-title">{{ location.modalTitle }}</h2>
        <div class="modal-content">
          <div class="input-container">
            <span>Name</span>
            <input type="text" v-model="location.name" />
          </div>
        </div>
        <div class="action-container">
          <button class="yellow-button" v-if="location.location_id == 0"
            @click="createLocation(), (location.locationModalShow = false)">
            Opret
          </button>
          <button class="yellow-button" v-if="location.location_id != 0"
            @click="updateLocation(location.location_id), (location.locationModalShow = false)">
            Opdater
          </button>
          <button @click="location.locationModalShow = false">Luk</button>
        </div>
      </div>
    </div>
    <!--Modal for the educations-->
    <div class="modal" v-if="education.educationModalShow">
      <div class="modal-container">
        <h2 class="modal-title">{{ education.modalTitle }}</h2>
        <div class="modal-content">
          <div class="input-container">
            <span>Name</span>
            <input type="text" v-model="education.name" />
          </div>
          <div class="input-container">
            <span>Sted</span>
            <input type="text" v-model="education.location" />
          </div>
        </div>
        <div class="action-container">
          <button class="yellow-button" v-if="education.edu_id == 0"
            @click="createEducation(), (education.educationModalShow = false)">
            Opret
          </button>
          <button class="yellow-button" v-if="education.edu_id != 0"
            @click="updateEducation(education.edu_id), (education.educationModalShow = false)">
            Opdater
          </button>
          <button @click="education.educationModalShow = false">Luk</button>
        </div>
      </div>
    </div>
    <div class="settings-container">
      <!--Tab for the users-->
      <tab :tabList="tabList">
        <template v-slot:tabPanel-1>
          <div class="header">
            <h2>Brugere</h2>
            <button class="yellow-button-tab" @click="addUser(user), (user.userModalShow = true)">
              Tilføj en ny bruger
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
              <tr v-for="u in users" :key="u.user_id">
                <td>
                  <p>{{ u.firstName }}</p>
                </td>
                <td>
                  <p>{{ u.lastName }}</p>
                </td>
                <td>
                  <p>{{ u.email }}</p>
                </td>
                <td>{{ u.title }}</td>
                <td class="edit_save">
                  <button class="edit-btn" @click="editUser(u), (user.userModalShow = true)"></button>
                  <button class="delete" @click="deleteUser(user.user_id)"></button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <!--Tab for the subjects-->
        <template v-slot:tabPanel-2>
          <div class="header">
            <h2>Emner</h2>
            <button class="yellow-button-tab" @click="addSubject(s), (subject.subjectModalShow = true)">
              Tilføj et nyt emne
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
              <tr v-for="s in subjects" :key="s.subject_id">
                <td>
                  <p>{{ s.name }}</p>
                </td>
                <td>
                  <p>{{ s.description }}</p>
                </td>
                <td class="edit_save">
                  <button class="edit-btn" @click="editSubject(s), (subject.subjectModalShow = true)"></button>
                  <button class="delete" @click="deleteSubject(subject.subject_id)"></button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <!--Tab for the locations-->
        <template v-slot:tabPanel-3>
          <div class="header">
            <h2>Lokationer</h2>
            <button class="yellow-button-tab" @click="addLocation(location), (location.locationModalShow = true)">
              Tilføj en ny lokation
            </button>
          </div>
          <table>
            <thead>
              <tr>
                <th>Navn</th>
                <th>Rediger/slet</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="l in locations" :key="l.location_id">
                <td>
                  <p>{{ l.name }}</p>
                </td>
                <td class="edit_save">
                  <button class="edit-btn" @click="editLocation(l), (location.locationModalShow = true)"></button>
                  <button class="delete" @click="deleteLocation(location.location_id)"></button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <!--Tab for the educations-->
        <template v-slot:tabPanel-4>
          <div class="header">
            <h2>Uddannelser</h2>
            <button class="yellow-button-tab" @click="addEducation(education), (education.educationModalShow = true)">
              Tilføj en ny uddannelse
            </button>
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
              <tr v-for="e in educations" :key="e.edu_id">
                <td>
                  <p>{{ e.name }}</p>
                </td>
                <td>
                  <p>{{ e.location }}</p>
                </td>
                <td class="edit_save">
                  <button class="edit-btn" @click="editEducation(e), (education.educationModalShow = true)"></button>
                  <button class="delete" @click="deleteEducation(education.edu_id)"></button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>
        <template v-slot:tabPanel-5>
          <button>
            <download-csv :data="allCases" name="Alle sager">
              Hent alle sager
            </download-csv>
          </button>
        </template>
        <!--Tab for the profil-->
        <template v-slot:tabPanel-6>
          <div class="header">
            <h2>Profil</h2>
          </div>
          <div class="educations">
            <h3>Vælg faste uddannelser</h3>
            <div class="education-grid">
              <button v-for="e in educations" id="profilEducation" :key="e.edu_id" @click="setFavEducation(e)"
                :class="{ 'selected': this.profileUser.edu_id.includes(e.edu_id) }">
                {{ e.name }}
              </button>
            </div>
          </div>
          <div class="locations">
            <h3>Vælg primære uddannelsesteder</h3>
            <div class="location-grid">
              <button v-for="l in locations" id="profilLocation" :key="location.location_id"
                @click="setFavLocation(l.location_id)"
                :class="{ 'selected': this.profileUser.location_id.includes(l.location_id) }">
                {{ l.name }}
              </button>
            </div>
          </div>
          <div class="password">
            <h3>Ændre din adgangskode</h3>
            <div class="password-wrapper">
              <input type="text" v-model="newPassword" id="passwordField" />
              <button class="yellow-button-tab" @click="updatePassword(this.SVUserid)">Gem adgangskode</button>
            </div>
          </div>
        </template>
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
      width: 600px;
      background-color: $Midnight-Green;
      ;
      padding: 24px;
      display: flex;
      flex-direction: column;
      border-radius: 10px;

      .modal-title {
        margin: 0;
        padding-bottom: 32px;
        color: #ffffff;
      }

      .modal-content {
        width: 100%;
        display: flex;
        flex-direction: column;
        justify-content: center;

        .input-container {
          display: flex;
          flex-direction: column;

          span {
            font-weight: bold;
            font-size: 16px;
            color: #ffffff;
            margin-bottom: 2px;
          }

          input {
            color: $Midnight-Green;
            font-size: 16px;
            height: 32px;
            padding: 8px;
            margin-bottom: 24px;

            &:focus-visible {
              height: 32px;
              outline: none;
            }
          }

          textarea {
            height: 64px;
            font-size: 16px;
            font-family: inherit;
            color: inherit;
            padding: 8px 0 0 8px;
            resize: none;

            &:focus-visible {
              height: 32px;
              outline: none;
              height: 64px;
            }
          }
        }
      }

      .action-container {
        display: flex;
        flex-direction: row;
        padding-top: 32px;
        justify-content: space-between;

        button {
          font-weight: bold;
        }
      }
    }
  }

  .settings-container {
    @include flowDesign;

    padding: 40px;
    flex-direction: unset;
    justify-content: unset;

    .tab {
      max-width: 861px;
      width: 100%;
    }

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

          p {
            margin: 0;
          }
        }

        th {
          padding: 0 16px;
          height: 50px;
          text-align: left;

          &:last-child {
            text-align: right;
          }
        }

        .edit_save {
          display: flex;
          flex-direction: row;
          justify-content: flex-end;
          gap: 16px;

          .delete {
            position: relative;

            &:after {
              content: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='15.622' height='20' viewBox='0 0 15.622 20'%3E%3Cpath id='da086273b974cb595139babd4da17772' d='M21.015,10.466l-.328,9.75a3.245,3.245,0,0,1-3.281,3.106H11.172a3.245,3.245,0,0,1-3.281-3.1l-.328-9.753A.821.821,0,0,1,9.2,10.413l.328,9.752a1.627,1.627,0,0,0,1.641,1.549h6.234a1.627,1.627,0,0,0,1.641-1.552l.328-9.749a.821.821,0,0,1,1.641.053ZM22.1,7.221a.813.813,0,0,1-.82.805H7.3a.805.805,0,1,1,0-1.611H9.841a1.04,1.04,0,0,0,1.044-.925,2.437,2.437,0,0,1,2.448-2.17h1.911a2.437,2.437,0,0,1,2.448,2.17,1.04,1.04,0,0,0,1.044.925h2.543a.813.813,0,0,1,.82.805Zm-9.791-.805h3.96a2.619,2.619,0,0,1-.209-.76.815.815,0,0,0-.815-.725H13.334a.815.815,0,0,0-.815.725,2.62,2.62,0,0,1-.21.76Zm.826,12.2V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Zm3.949,0V11.76a.82.82,0,0,0-1.641,0v6.86a.82.82,0,0,0,1.641,0Z' transform='translate(-6.478 -3.322)' fill='%23eb0000'/%3E%3C/svg%3E%0A");
            }
          }

          .edit-btn {
            position: relative;

            &:after {
              content: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='20' height='19.996' viewBox='0 0 20 19.996'%3E%3Cpath id='b21743bd27446b402537e815c62aa968' d='M21.224,2.73a3.319,3.319,0,0,1,0,4.695L8.96,19.686a4.151,4.151,0,0,1-1.928,1.092l-3.8.951a.83.83,0,0,1-1.007-1.006l.951-3.8a4.15,4.15,0,0,1,1.092-1.928L16.528,2.73A3.321,3.321,0,0,1,21.224,2.73Zm-5.87,3.521L5.438,16.164a2.49,2.49,0,0,0-.655,1.157l-.615,2.461,2.461-.615a2.49,2.49,0,0,0,1.157-.655L17.7,8.6ZM17.7,3.9,16.528,5.077l2.348,2.347L20.05,6.251A1.66,1.66,0,0,0,17.7,3.9Z' transform='translate(-2.196 -1.757)' fill='%23153943'/%3E%3C/svg%3E%0A");
            }
          }

          button {
            cursor: pointer;
            background: none;
            width: 30px !important;
          }
        }

      }
    }

    .educations {
      .education-grid {
        width: 100%;
        display: flex;
        justify-content: flex-start;
        gap: 16px;
        flex-wrap: wrap;
        margin-bottom: 64px;

        button {
          &:nth-child(n + 10) {
            display: block;
          }
        }
      }
    }

    .locations {
      .location-grid {
        width: 100%;
        display: flex;
        justify-content: flex-start;
        gap: 16px;
        flex-wrap: wrap;
        margin-bottom: 64px;
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

    .password {
      .password-wrapper {
        display: flex;
        gap: 16px;

        input {
          color: $Midnight-Green;
          padding: 8px;
          min-width: 300px;
          font-size: 16px;
          border: none;

          &:focus-visible {
            outline: none;
            border: none;
          }
        }
      }
    }
  }
}
</style>