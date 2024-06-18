<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <AddSeats />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import AddSeats from '@/components/admin/AddSeat.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name


export default {
    name: 'AddSeat',
    components: {
        AddSeats,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
