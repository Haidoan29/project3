<template>
    <div class="home">
        <header>
            <Headers></Headers>
        </header>
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <HommePage />
        <footer>
            <Footer></Footer>
        </footer>
        <!--msg="Welcome to Your Vue.js App"-->
    </div>
</template>

<script>
// @ is an alias to /src
import HommePage from '@/components/HomePage.vue'
import Headers from '@/components/heder.vue'; // Corrected the component name
import Footer from '@/components/footer.vue';  // Corrected the component name

export default {
    name: 'HomePage',
    components: {
        HommePage,
        Headers,
        Footer
    }
}
</script>