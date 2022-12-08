<script setup>
import { RouterLink, RouterView } from "vue-router";

function toggleNav() {
  var x = document.getElementById("main-navigation")
  var y = document.getElementById("toggleicon");
  if (x.className === "main-navigation") {
    x.className = x.className.replace('main-navigation','main-navigation-responsive');
    y.innerHTML = y.innerHTML.replace( 'menu','close');
  } else {
    y.innerHTML = y.innerHTML.replace( 'close','menu') ;
    x.className = x.className.replace('main-navigation-responsive','main-navigation');
  }
}



document.getElementsByClassName("load")



</script>

<template>
  <header>
    <div class="wrapper">
      <nav class="nav" id="nav">
        <RouterLink to="/">
          <img class="logo" src="../assets/img/ucl-logo.png" alt="UCLs logo" />
        </RouterLink>
        <div class="main-navigation" id="main-navigation">
          <a href="javascript:void(0);">
            <span class="material-symbols-outlined toggleicon" id="toggleicon" @click="toggleNav">
              menu
            </span>
          </a>
          <RouterLink class="navigation-link navigation-middle" to="/">Hjem</RouterLink>
          <RouterLink class="navigation-link navigation-middle" to="/newcase">Ny sag</RouterLink>
          <RouterLink class="navigation-link navigation-middle" to="/oldcases">Gamle sager</RouterLink>
          <RouterLink class="navigation-link navigation-middle" to="/data">Data</RouterLink>
          <RouterLink class="navigation-link navigation-right" to="/settings">
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
@import "../assets/scss/colors.scss";
@import "../assets/scss/typography.scss";

@import "../assets/scss/variabler.scss";
@import "../assets/scss/button.scss";
@import "../assets/scss/mixins.scss";
@import "../assets/scss/layout.scss";
header {
  display: flex;
  flex: row;
  justify-content: center;
  .wrapper {
    width: 100%;
    max-width: 1057px;
    nav {
      display: flex;
      align-items: baseline;
      justify-content: space-between;
      padding-top: 2rem;
  
      .logo {
        max-width: 220px;
      }
      .main-navigation {
        .navigation-middle {
          color: $Midnight-Green;
          margin: 0 20px;
          text-decoration: none;
          font-weight: bold;
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
        .navigation-right {
          color: $Midnight-Green;
          margin-left: 20px;
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
        background-color: $Midnight-Green;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        align-items: center;
        .toggleicon {
          position: absolute;
          right: 2rem;
          top: 2rem;
          color: white;
        }
        .navigation-link {
          padding: 1rem 0;
          color: white;
          text-decoration: none;
        }
        .navigation-right {
          margin-right: 0;
        }
      }
    }
    }
  }
}


  

</style>
