<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Router />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import Router from '@/components/admin/Router.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name


export default {
    name: 'EmployeeRouter',
    components: {
        Router,
        Headers,  // Corrected the component name

    }
}
</script>
