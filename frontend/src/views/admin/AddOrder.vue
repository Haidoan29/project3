<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <AddOrderComponent />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <!-- <footer>
        <Footer></Footer>
    </footer> -->
</template>

<script>
// @ is an alias to /src
import AddOrderComponent from '@/components/admin/AddOrder.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
// import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'AddOrder',
    components: {
        AddOrderComponent,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
