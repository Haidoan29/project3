<!-- <template>
    <h1>Đây là trang quên mật khẩu</h1>

    <div class="card text-center containers" style="width: 300px;">
        <div class="card-header h5 text-white bg-primary">Password Reset</div>
        <div class="card-body px-5">
            <form @submit.prevent="submitForm">
                <label for="email">Email:</label>
                <input type="email" v-model="email" required>
                <button type="submit">Gửi yêu cầu</button>
            </form>
            <div class="d-flex justify-content-between mt-4">
                <a class="" href="/login">Login</a>
                <a class="" href="/register">Register</a>
            </div>
        </div>
    </div>


</template> -->
<template>
  <div class="" style="background-color: #1f1815">
    <div id="layoutAuthentication">
      <div id="layoutAuthentication_content">
        <main>
          <div class="container">
            <div class="row justify-content-center">
              <div class="col-lg-5">
                <div class="card shadow-lg border-0 rounded-lg mt-5">
                  <div class="card-header">
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
                    <h3 class="fw-normal mb-5" style="letter-spacing: 1px">
                      KHÔI PHỤC MẬT KHẨU
                    </h3>
                  </div>
                  <div class="card-body">
                    <div
                      v-if="!showCodeInput && !showPasswordInput"
                      class="small mb-3 text-muted"
                    >
                      Nhập địa chỉ email của bạn và chúng tôi sẽ gửi cho bạn một
                      liên kết để đặt lại mật khẩu của bạn.
                    </div>
                    <div
                      v-if="showCodeInput && !showPasswordInput"
                      class="small mb-3 text-muted"
                    >
                      Nhập mã xác nhận được gửi tới email của bạn.
                    </div>
                    <div v-if="showPasswordInput" class="small mb-3 text-muted">
                      Nhập mật khẩu mới của bạn.
                    </div>
                    <form @submit.prevent="submitForm">
                      <div
                        v-if="!showCodeInput && !showPasswordInput"
                        class="form-floating mb-3"
                      >
                        <input
                          class="form-control"
                          id="inputEmail"
                          type="email"
                          v-model="email"
                          placeholder="name@example.com"
                        />
                        <label for="inputEmail"></label>
                      </div>
                      <div
                        v-if="showCodeInput && !showPasswordInput"
                        class="form-floating mb-3"
                      >
                        <input
                          class="form-control"
                          id="inputCode"
                          type="text"
                          v-model="code"
                          placeholder="Confirmation code"
                        />
                        <label for="inputCode">Mã xác nhận</label>
                      </div>
                      <div v-if="showPasswordInput" class="form-floating mb-3">
                        <input
                          class="form-control"
                          id="inputPassword"
                          type="password"
                          v-model="newPassword"
                          placeholder="New Password"
                        />
                        <label for="inputPassword">Mật khẩu mới</label>
                      </div>
                      <div
                        class="d-flex align-items-center justify-content-between mt-4 mb-0"
                      >
                        <router-link
                          v-if="showCodeInput || showPasswordInput"
                          class="small"
                          to="/login"
                          >Trở về trang đăng nhập</router-link
                        >
                        <button
                          type="submit"
                          class="btn btn-info btn-lg ms-2"
                          style="background-color: #26a8bc"
                        >
                          {{
                            showCodeInput ? "Confirm Code" : "Reset Password"
                          }}
                        </button>
                      </div>
                    </form>
                  </div>
                  <div class="card-footer text-center py-3">
                    <div class="small">
                      <a href="register.html">Cần một tài khoản? Đăng ký!</a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </main>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "ForgotPassword",
  data() {
    return {
      email: "",
      code: "",
      newPassword: "",
      showCodeInput: false,
      showPasswordInput: false,
    };
  },
  methods: {
    async submitForm() {
      try {
        if (!this.showCodeInput && !this.showPasswordInput) {
          var url = `${process.env.VUE_APP_BASE_URL}ForgotPassword/forgotpassword`;
          await axios.post(url, { email: this.email });
          this.showCodeInput = true;
          alert("Email reset password đã được gửi.");
        } else if (this.showCodeInput && !this.showPasswordInput) {
          var confirmUrl = `${process.env.VUE_APP_BASE_URL}ForgotPassword/confirmcode`;
          await axios.post(confirmUrl, { email: this.email, code: this.code });
          this.showPasswordInput = true;
        } else {
          var resetUrl = `${process.env.VUE_APP_BASE_URL}ForgotPassword/resetpassword`;
          await axios.post(resetUrl, {
            email: this.email,
            newPassword: this.newPassword,
          });
          this.$router.push("/login");
          alert("Đặt lại mật khẩu thành công.");
        }
      } catch (error) {
        console.error("Lỗi:", error);
        alert("Đã có lỗi xảy ra. Vui lòng thử lại sau.");
      }
    },
  },
};
</script>

<style scoped>
/* .containers {
    margin: 0 auto;
    width: 100%;
    max-width: 400px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
} */
@import "@/assets/css/style.css";
</style>
