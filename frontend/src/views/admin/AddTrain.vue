<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <AddTrainComponent />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <!-- <footer>
        <Footer></Footer>
    </footer> -->
</template>

<script>
// @ is an alias to /src
import AddTrainComponent from '@/components/admin/AddTrain.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
// import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'AddTrain',
    components: {
        AddTrainComponent,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
