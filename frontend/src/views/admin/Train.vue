<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Train />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import Train from '@/components/admin/Train.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name



export default {
    name: 'EmployeeStaff',
    components: {
        Train,
        Headers,  // Corrected the component name

    }
}
</script>
