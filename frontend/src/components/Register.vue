<template>
  <div id="app">
    <!-- <form form @submit.prevent="register" action="action_page.php" class="register" style="border:1px solid #ccc">
      <div class="container">
        <h1>Sign Up</h1>
        <hr>
        <label for="username"><b>username</b></label>
        <input type="text" id="username" v-model="registerForm.username" required>
        <label for="email"><b>Email</b></label>
        <input type="text" id="username" v-model="registerForm.email" required>

        <label for="psw"><b>Password</b></label>
        <input type="password" id="password" v-model="registerForm.password" required pattern=".{6,}"
          title="Mật khẩu phải chứa ít nhất 6 ký tự">


        <label for="psw-repeat"><b>Repeat Password</b></label>
        <input type="password" id="retypePassword" v-model="registerForm.retypePassword" required>
        <div>
          <span v-if="passwordMismatch" class="error-message">Mật khẩu và mật khẩu nhập lại không khớp.</span>
        </div>

        <label>
          <input type="checkbox" checked="checked" name="remember" style="margin-bottom:15px"> Remember me
        </label>

        <div class="clearfix">

          <button type="button" class="cancelbtn">Cancel</button>
          <button type="submit" class="signupbtn">Đăng Ký</button>
          <router-link to="/login">Đăng nhập</router-link>|
        </div>
      </div>
    </form> -->
    <section class="vh-100" style="background-color: #1f1815">
      <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col col-xl-10">
            <div class="card" style="border-radius: 1rem">
              <div class="row g-0">
                <div class="col-md-6 col-lg-7 d-flex align-items-center">
                  <div class="card-body p-4 p-lg-5 text-black">
                    <form @submit.prevent="register">
                      <div class="d-flex align-items-center mb-3 pb-1">
                        <i
                          class="fas fa-cubes fa-2x me-3"
                          style="color: #ff6219"
                        ></i>
                        <span
                          class="h1 fw-bold mb-0"
                          style="
                            font-family: 'Roboto', 'Courier New', monospace;
                            font-style: oblique;
                          "
                          >ĐƯỜNG SẮT HẢI MINH</span
                        >
                      </div>

                      <h5
                        class="fw-normal mb-3 pb-3"
                        style="letter-spacing: 1px"
                      >
                        Register
                      </h5>

                      <div data-mdb-input-init class="form-outline">
                        <label class="form-label" for="form2Example17"
                          >Username</label
                        >
                        <input
                          type="text"
                          id="form2Example17"
                          class="form-control form-control-lg"
                          v-model="registerForm.username"
                          required
                        />
                      </div>

                      <div data-mdb-input-init class="form-outline">
                        <label class="form-label" for="form2Example17"
                          >Email</label
                        >
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
                        <label class="form-label" for="form2Example27"
                          >Password</label
                        >
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
                          >Repeat Password</label
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
                          Submit
                        </button>
                      </div>
                    </form>
                  </div>
                </div>
                <div class="col-md-6 col-lg-5 d-none d-md-block">
                  <img
                    src="https://halotravel.vn/wp-content/uploads/2019/10/duong-tau-ha-noi-08.jpg"
                    alt="login form"
                    class="img-fluid h-100"
                    style="border-radius: 0 1rem 1rem 0"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
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
