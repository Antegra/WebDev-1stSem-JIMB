<script>
export default {
  props: {
    tabList: {
      type: Array,
      required: true,
    },
  },
  data() {
    return {
      activeTab: 1,
      _uid: null,
    };
  },
};
</script>

<template>
  <div class="tab">
    <ul>
      <li
        v-for="(tab, index) in tabList"
        :key="index"
        :class="{
          li_active: index + 1 === activeTab,
        }"
      >
        <label :for="`${_uid}${index}`" v-text="tab"/>
        <input
          :id="`${_uid}${index}`"
          type="radio"
          :name="`${_uid}-tab`"
          :value="index + 1"
          v-model="activeTab"
        />
      </li>
    </ul>
    <template v-for="(tab, index) in tabList">
      <div :key="index" v-if="index + 1 === activeTab">
        <slot :name="`tabPanel-${index + 1}`"/>
      </div>
    </template>
  </div>
</template>

<style lang="scss" scoped>
@import "../assets/scss/colors.scss";
@import "../assets/scss/typography.scss";

@import "../assets/scss/variabler.scss";
@import "../assets/scss/button.scss";
@import "../assets/scss/mixins.scss";
@import "../assets/scss/layout.scss";

ul {
  display: flex;
  justify-content: flex-start;
  margin-top: -64px;
  margin-bottom: 64px;
  margin-left: -40px;
  padding: 0;

  li {
    list-style: none;
    border-radius: 5px;
    background: $Midnight-Green;
    display: flex;
    justify-content: center;
    align-items: center;
    width: 130px;
    height: 40px;
  }
  .li_active {
    background: $Maize;
    color: $Midnight-Green;
    font-weight: bold;
    box-shadow: $stdDropshadow;
  }
  label {
    width: 144px;
    font-size: 16px;
    cursor: pointer;
    padding: 20px;
  }
  input {
    display: none;
  }
}
</style>
