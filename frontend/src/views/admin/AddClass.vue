<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Class />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import Class from '@/components/admin/AddClass.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name


export default {
    name: 'AddClass',
    components: {
        Class,
        Headers,  // Corrected the component name
        // Footer
    }
}
</script>
