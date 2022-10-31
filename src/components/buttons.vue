
<template>
    <button v-on="$listeners" 
    @click="handleClick" 
    :class="[arrowFront ? 'next' : 'prev']" 
    :style="{ background, color}">
    
        {{ buttonText }}
    </button>
</template>
  

<script>
export default {
    props: {
        buttonText: {
            type: String,
            default: () => "Label",
        },
        arrowFront: {
            type: Boolean,
            default: () => false,
        }
    },
    // methods: {
    //     handleClick() {
    //         console.log("HEJ");
    //     }
    // }
}
</script>


<style lang="scss" scoped>

button {
    background: green;
    color: #fff;
    border: none;
    border-radius: 5px;
    padding: 10px 30px;
    position: relative;
    cursor: pointer;
    margin: 20px;
 
    &.next {
        &:hover {
            &:after {
                right: 10px;
                transition: 0.2s; 
            }
         }
        &:after {
        transition: 0.2s;
        position: absolute;
        right: 15px;
        top: 55%;
        transform: translateY(-50%);
        content: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='8' height='13.665' viewBox='0 0 8 13.665'%3E%3Cg id='up-arrow-svgrepo-com' transform='translate(18.293) rotate(90)'%3E%3Cpath id='Path_2' data-name='Path 2' d='M14.3,18.151l-.778.778L7.857,13.264,2.192,18.929l-.778-.778,6.443-6.444Z' transform='translate(-1.025 -1.025)' fill='%23153943'/%3E%3Cpath id='Path_3' data-name='Path 3' d='M12.5,18.293,6.833,12.628,1.167,18.293,0,17.126l6.833-6.833,6.833,6.833ZM6.833,11.85,12.5,17.515l.389-.389L6.833,11.071.778,17.126l.389.389Z' fill='%23153943'/%3E%3C/g%3E%3C/svg%3E%0A");
        }
    }
    &.prev {
        &:hover {
            &:after {
                left: 10px;
                transition: 0.2s; 
            }
         }
        &:after {
        transition: 0.2s;
        position: absolute;
        left: 15px;
        top: 55%;
        transform: translateY(-50%);
        content: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='8' height='13.665' viewBox='0 0 8 13.665'%3E%3Cg id='up-arrow-svgrepo-com' transform='translate(18.293) rotate(90)'%3E%3Cpath id='Path_2' data-name='Path 2' d='M14.3,18.151l-.778.778L7.857,13.264,2.192,18.929l-.778-.778,6.443-6.444Z' transform='translate(-1.025 -1.025)' fill='%23153943'/%3E%3Cpath id='Path_3' data-name='Path 3' d='M12.5,18.293,6.833,12.628,1.167,18.293,0,17.126l6.833-6.833,6.833,6.833ZM6.833,11.85,12.5,17.515l.389-.389L6.833,11.071.778,17.126l.389.389Z' fill='%23153943'/%3E%3C/g%3E%3C/svg%3E%0A");
        }
    }
}

</style>
