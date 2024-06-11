<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <AddRouters />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import AddRouters from '@/components/admin/AddRouter.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name


export default {
    name: 'AddRouter',
    components: {
        AddRouters,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
