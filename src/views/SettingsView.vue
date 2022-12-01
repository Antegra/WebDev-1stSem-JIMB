<script>
    import tab from '../components/tabs.vue';
    export default {
    components: {
        tab,
    },

    data() {
        return {
        tabList: ["Tab 1", "Tab 2", "Tab 3", "Tab 4"],
        };
    },
    };
</script>
<template>
    <div class="settings">
        <div class="settings-container">
            <tab :tabList="tabList">
            <template v-slot:tabPanel-1> Content 1 </template>
            <template v-slot:tabPanel-2> Content 2 </template>
            <template v-slot:tabPanel-3> Content 3 </template>
            <template v-slot:tabPanel-4> Content 4 </template>
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
  height: 100vh;
  margin-top:unset;
.settings-container {
  @include flowDesign;
  
}
}

</style>