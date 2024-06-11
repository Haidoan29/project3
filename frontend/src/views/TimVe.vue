<template>
  <div class="home">
    <header>
      <Headers></Headers>
    </header>
    <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
    <TimVe />
    <footer>
      <Footer></Footer>
    </footer>
    <!--msg="Welcome to Your Vue.js App"-->
  </div>
</template>

<script>
// @ is an alias to /src
import TimVe from "@/components/TimVe.vue";
import Headers from "@/components/heder.vue"; // Corrected the component name
import Footer from "@/components/footer.vue"; // Corrected the component name

export default {
  name: "HomePage",
  components: {
    TimVe,
    Headers,
    Footer,
  },
};
</script>
