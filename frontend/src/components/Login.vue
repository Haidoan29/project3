<template>
  <div class="row g-0 vh-100">
    <div class="col-md-6 col-lg-6 d-none d-md-block vh-100">
      <img src="https://halotravel.vn/wp-content/uploads/2019/10/duong-tau-ha-noi-08.jpg" alt="login form"
        class="img-fluid h-100 w-100" />
    </div>
    <div class="col-md-6 col-lg-6 d-flex align-items-center"
      style="background-color: #fbfbfb; border-radius: 0 1rem 1rem 0">
      <div class="card-body p-4 p-lg-5 text-black w-100">
        <form @submit.prevent="login">
          <div class="d-flex align-items-center mb-3 pb-1">
            <i><img src="../assets/img/logo3.png" class="img-fluid"
                style="height: 35px; width: 70px; margin-right: 10px" />
            </i>
            <span class="h1 fw-bold mb-0" style="
                font-family: 'Roboto', 'Courier New', monospace;
                font-style: oblique;
              ">ĐƯỜNG SẮT HẢI MINH</span>
          </div>

          <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px">
            ĐĂNG NHẬP
          </h5>

          <div data-mdb-input-init class="form-outline mb-4">
            <label class="form-label" for="form2Example17">Tên tài khoản</label>
            <input type="text" id="form2Example17" class="form-control form-control-lg" v-model="loginForm.username"
              required />
          </div>

          <div data-mdb-input-init class="form-outline mb-4">
            <label class="form-label" for="form2Example27">Mật khẩu</label>
            <input type="password" id="form2Example27" class="form-control form-control-lg" v-model="loginForm.password"
              required />
          </div>

          <div class="pt-1 mb-4">
            <button data-mdb-button-init data-mdb-ripple-init class="btn btn-info btn-lg btn-block" type="submit">
              Đăng nhập
            </button>
          </div>

          <a class="text-muted" href="/forgotpassword" @click="goToForgotpassword">Quên mật khẩu ?</a>
          <p class="mb-5 pb-lg-2" style="color: #393f81">
            Bạn chưa có tài khoản ?
            <a href="/register" @click="goToRegister" class="link-info">Đăng kí tại đây</a>
          </p>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Login_Register",
  props: {
    msg: String,
  },
  data() {
    return {
      // registerForm: {
      //     username: '',
      //     password: ''
      // },
      loginForm: {
        username: "",
        password: "",
      },
      token: "", // Lưu trữ token sau khi đăng nhập thành công
      errorMessage: "", // Thêm biến này để lưu trữ thông báo lỗi
      errorKey: 0, // Thêm key để cập nhật DOM
    };
  },
  methods: {
    async login() {
      try {
        var url = `${process.env.VUE_APP_BASE_URL}Auth/Login`;

        const response = await axios.post(url, {
          username: this.loginForm.username,
          password: this.loginForm.password,
        });

        // Kiểm tra kết quả từ phản hồi
        if (response.status === 200) {
          console.log("Đăng nhập thành công:", response.data);
          // Lưu token vào local storage để sử dụng trong các yêu cầu tiếp theo
          localStorage.setItem("token", response.data.token);

          // Chuyển hướng người dùng đến trang khác
          // Chuyển hướng người dùng đến trang khác
          this.$router.push("/").then(() => {
            // Load lại trang sau khi chuyển hướng
            window.location.reload();
            // console.log('Đăng nhập thành công:', response.data.token);
          });
          // // Load lại trang sau khi chuyển hướng
          // this.$router.go(0);
        } else {
          console.error("Đăng nhập không thành công:", response.data);
          this.errorMessage =
            "Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.";
          this.errorKey++; // Cập nhật key để cập nhật DOM

          // Hiển thị thông báo lỗi cho người dùng
        }
      } catch (error) {
        console.error("Đã xảy ra lỗi khi đăng nhập:", error);
        this.errorMessage = "Đã xảy ra lỗi khi đăng nhập. Vui lòng thử lại.";
        this.errorKey++; // Cập nhật key để cập nhật DOM

        // Hiển thị thông báo lỗi cho người dùng
      }
    },
    goToRegister() {
      // Chuyển hướng đến trang đăng ký
      this.$router.push("/register");
      // Load lại trang
      this.$router.go(0);
    },
    goToForgotpassword() {
      // Chuyển hướng đến trang đăng ký
      this.$router.push("/register");
      // Load lại trang
      this.$router.go(0);
    },
    // login() {
    //     var url = "https://localhost:7074/api/Auth/Login";
    //     axios.post(url).then(response => {
    //         console.log(response);

    //     }).catch(error => {
    //         console.error('Đã xảy ra lỗi khi tải dữ liệu:', error);
    //     })
    // },
  },
  created() {
    //debugger
    console.log("Component created");
    this.titlePage = "Component Setting in created";
    //this.login();
  },
};
</script>
