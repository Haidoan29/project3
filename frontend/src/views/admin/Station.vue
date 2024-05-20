<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Station />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import Station from '@/components/admin/Station.vue';
import Headers from '@/components/admin/Header.vue';


export default {
    name: 'StationList',
    components: {
        Station,
        Headers,  // Corrected the component name

    }
}
</script>
