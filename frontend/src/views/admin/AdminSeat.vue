<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <AdminSeat />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <!-- <footer>
        <Footer></Footer>
    </footer> -->
</template>

<script>
// @ is an alias to /src
import AdminSeat from '@/components/admin/AdminSeat.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
// import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'SeatManagement',
    components: {
        AdminSeat,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
