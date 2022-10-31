
<template>
    <div class="search-container">
        <input class="searchbar" type="text" placeholder="Søg">
    </div>
    
</template>
  

<script>
export default {
 
}
</script>


<style lang="scss" scoped>
@import "../assets/colors.scss";

.search-container {
    width: 200px;
    position: relative;
    &:before {
        CONTENT: url("data:image/svg+xml,%3Csvg width='15' height='15' viewBox='0 0 15 15' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Cg clip-path='url(%23clip0_227_2)'%3E%3Cpath d='M14.8073 13.911L11.4274 10.528C12.3389 9.41769 12.8834 7.99538 12.8834 6.44766C12.8834 2.89036 9.99898 0.00598145 6.44168 0.00598145C2.88438 0.00598145 0 2.89036 0 6.44766C0 10.005 2.88438 12.8893 6.44168 12.8893C7.99551 12.8893 9.42088 12.3388 10.5343 11.4212L13.9142 14.801C14.3087 15.162 14.6788 14.9295 14.8073 14.801C15.0642 14.5472 15.0642 14.1648 14.8073 13.911ZM1.25714 6.44766C1.25714 3.58469 3.57871 1.26312 6.44168 1.26312C9.30465 1.26312 11.6293 3.58469 11.6293 6.44766C11.6293 9.31063 9.30771 11.6322 6.44474 11.6322C3.58177 11.6322 1.25714 9.31063 1.25714 6.44766Z' fill='%236A6A6A'/%3E%3C/g%3E%3Cdefs%3E%3CclipPath id='clip0_227_2'%3E%3Crect width='15' height='15' fill='white'/%3E%3C/clipPath%3E%3C/defs%3E%3C/svg%3E%0A");
        position: absolute;
        z-index: 2;
        top: 50%;
        margin-top: 2px;
        margin-left: 10px;
        transform: translateY(-50%);
    }
    .searchbar {
    box-shadow: rgba(0, 0, 0, 0.15) 1.95px 1.95px 2.6px;
    border:none;
    outline:none;
    border: 0.5px solid #eee;
    border-radius: 16px;
    padding: 10px 10px 10px 35px;
    color: #000;
    // text-transform: uppercase;
    font-weight: bold;
    position: relative;
  
    
}

}





</style>
