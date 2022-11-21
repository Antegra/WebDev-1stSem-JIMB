<script>
    import { provide, ref } from 'vue'
    export default {
       setup(props, { slots }) {
        const tabNames = ref(slots.default().map((tab) => tab.props.name))
        const selectedName = ref(tabNames.value[0])

        provide ["selectedName", selectedName]
        return {
            selectedName,
            tabNames,
        }
       }
    }
</script>
<template>
    <div>
        <header class="tabs">
            <ul>
                <li 
                    v-for="name in tabNames" 
                    :key="name"
                    @click="selectedName = name"
                >

                    {{ name }}
                </li>
            </ul>
        </header>
        <section class="tabs-details">
            <slot></slot>
        </section>  

    </div>
</template>


<style lang="scss" scoped>

li {
    cursor: pointer;
}

</style>