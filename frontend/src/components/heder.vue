<template>
  <!-- Navbar -->
  <nav
    class="navbar navbar-expand-lg navbar-light text-lg-start bg-body-tertiary text-muted"
    style="height: 75px; background: #fff0f6; border-bottom: 1px solid black"
  >
    <!-- Container wrapper -->
    <div class="container">
      <!-- Navbar brand -->
      <a class="navbar-brand align-items-center me-2" href="">
        <h2
          class="text-uppercase fw-bold mb-4"
          style="
            font-family: 'Roboto', 'Courier New', monospace;
            font-style: oblique;
            color: #e262a8;
            letter-spacing: 2px;
          "
        >
          <i
            ><img
              src="../assets/img/logo3.png"
              class="img-fluid"
              style="height: 20px; width: 40px; margin-right: 10px" /></i
          >ĐƯỜNG SẮT HẢI MINH
        </h2>
      </a>

      <!-- Toggle button -->
      <button
        data-mdb-collapse-init
        class="navbar-toggler"
        type="button"
        data-mdb-target="#navbarButtonsExample"
        aria-controls="navbarButtonsExample"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <i class="fas fa-bars"></i>
      </button>

      <!-- Collapsible wrapper -->
      <div class="collapse navbar-collapse" id="navbarButtonsExample">
        <!-- Left links -->
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <a
              class="nav-link"
              href="/"
              style="
                color: #696969;
                font-weight: bold;
                font-family: Roboto;
                letter-spacing: 2px;
              "
              >Trang chủ</a
            >
          </li>
          <li class="nav-item">
            <a
              class="nav-link"
              href="/timve"
              style="
                color: #696969;
                font-weight: bold;
                font-family: Roboto;
                letter-spacing: 2px;
              "
              >Tìm vé</a
            >
          </li>
          <li class="nav-item">
            <a
              class="nav-link"
              href="/datve"
              style="
                color: #696969;
                font-weight: bold;
                font-family: Roboto;
                letter-spacing: 2px;
              "
              >Đặt vé</a
            >
          </li>
        </ul>

        <!-- Left links -->

        <div class="d-flex align-items-center">
          <!-- <button
            data-mdb-ripple-init
            type="button"
            class="btn btn-link px-3 me-2"
          >
            Login
          </button> -->
          <button
            data-mdb-button-init
            data-mdb-ripple-init
            class="btn btn-info btn-lg btn-block"
            type="submit"
            style="background-color: #26a8bc"
          >
            <i class="fa-regular fa-user" style="margin-right: 5px"></i>
            Đăng nhập
          </button>
        </div>
      </div>
      <!-- Collapsible wrapper -->
    </div>
    <!-- Container wrapper -->
  </nav>
  <!-- Navbar -->
</template>

<script>
export default {
  name: "YourComponentName",
  methods: {
    logout() {
      // Xử lý đăng xuất ở đây
      // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
      localStorage.removeItem("token");
      this.$router.push("/login");
      window.location.reload();
    },
  },
};
</script>
