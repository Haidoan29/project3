<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Class />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <!-- <footer>
        <Footer></Footer>
    </footer> -->
</template>

<script>
// @ is an alias to /src
import Class from '@/components/admin/Class.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
// import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'ClassManagement',
    components: {
        Class,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
