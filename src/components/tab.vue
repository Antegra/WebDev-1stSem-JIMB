<script>
    import { inject } from 'vue'
    export default {
    props: ['name'],
    setup() {
        const selectedName = inject("selectedName")

        return {
            selectedName
        }
    }
    };
</script>
<template>
  <div v-show="name == selectedName">
    <slot/>
  </div>
</template>
