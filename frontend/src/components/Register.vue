<template>
  <div class="row g-0 vh-100">
    <div class="col-md-6 col-lg-5 d-none d-md-block">
      <img
        src="https://halotravel.vn/wp-content/uploads/2019/10/duong-tau-ha-noi-08.jpg"
        alt="login form"
        class="img-fluid h-100"
        style="border-radius: 0 1rem 1rem 0"
      />
    </div>
    <div class="col-md-6 col-lg-7 d-flex align-items-center">
      <div class="card-body p-4 p-lg-5 text-black">
        <form @submit.prevent="register">
          <div class="d-flex align-items-center mb-3 pb-1">
            <i>
              <img
                src="../assets/img/logo3.png"
                class="img-fluid"
                style="height: 35px; width: 70px; margin-right: 10px"
              />
            </i>
            <span
              class="h1 fw-bold mb-0"
              style="
                font-family: 'Roboto', 'Courier New', monospace;
                font-style: oblique;
              "
              >ĐƯỜNG SẮT HẢI MINH</span
            >
          </div>

          <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px">
            ĐĂNG KÍ
          </h5>

          <div data-mdb-input-init class="form-outline">
            <label class="form-label" for="form2Example17">Tên tài khoản</label>
            <input
              type="text"
              id="form2Example17"
              class="form-control form-control-lg"
              v-model="registerForm.username"
              required
            />
          </div>

          <div data-mdb-input-init class="form-outline mb-4">
            <label class="form-label" for="form2Example17">Email</label>
            <input
              type="email"
              id="form2Example17"
              class="form-control form-control-lg"
              v-model="registerForm.email"
              requiredv-model="registerForm.email"
              required
            />
          </div>

          <div data-mdb-input-init class="form-outline">
            <label class="form-label" for="form2Example27">Mật khẩu</label>
            <input
              type="password"
              id="form2Example27"
              class="form-control form-control-lg"
              v-model="registerForm.password"
              required
              pattern=".{6,}"
              title="Mật khẩu phải chứa ít nhất 6 ký tự"
            />
          </div>

          <div data-mdb-input-init class="form-outline mb-4">
            <label class="form-label" for="form2Example27"
              >Nhập lại mật khẩu</label
            >
            <input
              type="password"
              id="form2Example27"
              class="form-control form-control-lg"
              v-model="registerForm.retypePassword"
              required
            />
          </div>

          <div>
            <span v-if="passwordMismatch" class="error-message"
              >Mật khẩu và mật khẩu nhập lại không khớp.</span
            >
          </div>

          <div class="pt-1">
            <button
              data-mdb-button-init
              data-mdb-ripple-init
              class="btn btn-info btn-lg btn-block"
              type="submit"
              style="background-color: #26a8bc"
            >
              Đăng kí
            </button>
          </div>
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
      registerForm: {
        username: "",
        password: "",
        email: "",
        retypePassword: "", // Thêm trường retypePassword vào form data
      },
      token: "", // Lưu trữ token sau khi đăng nhập thành công
      passwordMismatch: false, // Thêm passwordMismatch vào data để kiểm tra mật khẩu nhập lại
    };
  },
  methods: {
    async register() {
      // Kiểm tra xem mật khẩu và mật khẩu nhập lại có khớp nhau không
      if (this.registerForm.password !== this.registerForm.retypePassword) {
        // Nếu mật khẩu không khớp, hiển thị thông báo lỗi
        this.passwordMismatch = true;
        return;
      }

      try {
        var url = `${process.env.VUE_APP_BASE_URL}Auth/Register`;
        //'https://localhost:7074/api/Auth/Register?role=CUSTOMER'
        const response = await axios.post(url, {
          username: this.registerForm.username,
          email: this.registerForm.email,
          password: this.registerForm.password,
          Role: "CUSTOMER", // Thêm trường Role với giá trị 'CUSTOMER'
        });
        console.log(response.data);

        this.$router.push("/login");
      } catch (error) {
        console.error(
          "Đăng ký không thành công:",
          error.response ? error.response.data : error.message
        );
      }
    },

    // login() {
    //   var url = "https://localhost:7074/api/Auth/Login";
    //   axios.post(url).then(response => {
    //     console.log(response);
    //   }).catch(error => {
    //     console.error('Đã xảy ra lỗi khi tải dữ liệu:', error);
    //   })
    // },
  },
  created() {
    //debugger
    console.log("Component created");
    this.titlePage = "Component Setting in created";
    //this.loadData();
  },
};
</script>
<style scoped>
/* .error-message {
  color: red;
} */
@import url("/public/register.css");
</style>
