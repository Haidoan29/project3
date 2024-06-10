<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <AddCustomer />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import AddCustomer from '@/components/admin/AddCustomer.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name


export default {
    name: 'AddStation',
    components: {
        AddCustomer,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
