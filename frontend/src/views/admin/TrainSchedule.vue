<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <TrainSchedule />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>

</template>

<script>
// @ is an alias to /src
import TrainSchedule from '@/components/admin/TrainSchedule.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name



export default {
    name: 'EmployeeStaff',
    components: {
        TrainSchedule,
        Headers,  // Corrected the component name

    }
}
</script>
