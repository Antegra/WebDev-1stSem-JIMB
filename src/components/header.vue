<script setup>
import { RouterLink, RouterView } from "vue-router";

function toggleNav() {
  var x = document.getElementById("main-navigation")
  var y = document.getElementById("toggleicon");
  if (x.className === "main-navigation" || y.className === "toggleicon") {
    x.className += "-responsive ";
    y.className += "-active ";
  } else {
    x.className = "main-navigation";
    y.className += "toggleicon";
  }
  console.log('menuen virker')
}
</script>

<template>
  <header>
    <div class="wrapper">
      <nav class="nav" id="nav">
        <RouterLink to="/">
          <img class="logo" src="../assets/img/ucl-logo.png" alt="UCLs logo" />
        </RouterLink>
        <div class="main-navigation" id="main-navigation">
          <a href="javascript:void(0);" @click="toggleNav" >
            <span class="material-symbols-outlined toggleicon" id="toggleicon">
              menu
            </span>
          </a>
          <RouterLink class="navigation-link" to="/">Hjem</RouterLink>
          <RouterLink class="navigation-link" to="/newcase">Ny sag</RouterLink>
          <RouterLink class="navigation-link" to="/oldcases">Gamle sager</RouterLink>
          <RouterLink class="navigation-link" to="/data">Data</RouterLink>
          <RouterLink class="navigation-link" to="/settings">
            <span class="material-symbols-outlined">
              settings
            </span>
          </RouterLink>
        </div>  
      </nav>
    </div>
  </header>
  <RouterView />
</template>

<style lang="scss" scoped>
@import "../assets/colors.scss";
header {
  display: flex;
  flex: row;
  justify-content: center;
  .wrapper {
    width: 100%;
    nav {
      display: flex;
      align-items: baseline;
      justify-content: space-evenly;
      padding-top: 2rem;
  
      .logo {
        max-width: 143px;
      }
      .main-navigation {
        overflow: hidden;
        a {
          color: $Midnight-Green;
          margin: 0 20px;
          text-decoration: none;
  
          .material-symbols-outlined {
            position: relative;
            top: 5px;
            font-variation-settings:
            'FILL' 0,
            'wght' 400,
            'GRAD' 0,
            'opsz' 100
          }
        }
        .toggleicon {
            display: none;
          }
      }
    }
    
    //Mobileview
    @media screen and (max-width: 620px) {

      nav {
        padding: 2rem;
        justify-content: space-between;
        
        .main-navigation {
          .navigation-link {
            display: none;
          }

          .toggleicon {
            display: inline;
        }
      }
      .main-navigation-responsive {
        position: absolute;
        top: 0;
        right: 0;
        height: 100vh;
        width: 50vw;
        background-color: $Columbia-blue;
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        align-items: center;

        .navigation-link {
          padding: 1rem 0;
          color: $Midnight-Green;
          text-decoration: none;
        }
      }
    }
    }
  }
}


  

</style>
