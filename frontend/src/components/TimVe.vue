<template>

  <body data-rsssl="1">
    <div id="wrapper">
      <div id="content" style="margin-bottom: 60px; margin-top: 90px">
        <div class="main-content">
          <div class="container">
            <h5 style="
                margin-bottom: 50px;
                font-size: 12px;
                font-family: Roboto;
                color: #d82d8b;
              ">
              <i class="fa-solid fa-arrow-right" style="padding-right: 5px"></i>TÌM VÉ
            </h5>
            <div class="row">
              <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
                <div class="detail-tour-list" style="background: #eeeeee">
                  <div class="img-tour">
                    <a href="ve-tau-chang-di-vinh-ha-noi/index.html">
                      <img src="https://phongveadamviet.com/wp-content/uploads/2019/01/ve-tau-300x200.jpg"
                        alt="Vé tàu chặng đi Vinh &#8211; Hà Nội" />
                    </a>
                  </div>
                  <div class="info-tour" style="padding: 15px" v-for="ticket in searchResult" :key="ticket.id">
                    <h4>
                      <a href="" style="text-decoration: none; font-size: 15px">Vé
                        tàu chặng đi Vinh &#8211; Hà Nội Mã tàu: {{ ticket.trainID }}</a>
                    </h4>
                    <p class="price" style="
                        color: #e00;
                        font: 400 18px / normal Utm-Avo-bold, sans-serif;
                        font-weight: bold;
                        padding-top: 10px;
                      ">
                      253.000 VNĐ
                    </p>
                    <p>
                      <i class="fa fa-clock-o" style="color: red"></i>
                      Khởi hành:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">9:28 AM</span>
                    </p>
                    <p>
                      <i class="fa fa-star" style="color: red"></i> Hạng vé:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">Ngồi mềm điều hòa</span>
                    </p>
                  </div>
                </div>
              </div>
              <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
                <div class="detail-tour-list" style="background: #eeeeee">
                  <div class="img-tour">
                    <a href="ve-tau-chang-di-vinh-ha-noi/index.html">
                      <img src="https://phongveadamviet.com/wp-content/uploads/2019/01/ve-tau-300x200.jpg"
                        alt="Vé tàu chặng đi Vinh &#8211; Hà Nội" />
                    </a>
                  </div>
                  <div class="info-tour" style="padding: 15px">
                    <h4>
                      <a href="ve-tau-chang-di-vinh-ha-noi/index.html" style="text-decoration: none; font-size: 15px">Vé
                        tàu chặng đi Vinh &#8211; Hà Nội</a>
                    </h4>
                    <p class="price" style="
                        color: #e00;
                        font: 400 18px / normal Utm-Avo-bold, sans-serif;
                        font-weight: bold;
                        padding-top: 10px;
                      ">
                      253.000 VNĐ
                    </p>
                    <p>
                      <i class="fa fa-clock-o" style="color: red"></i>
                      Khởi hành:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">9:28 AM</span>
                    </p>
                    <p>
                      <i class="fa fa-star" style="color: red"></i> Hạng vé:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">Ngồi mềm điều hòa</span>
                    </p>
                  </div>
                </div>
              </div>
              <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
                <div class="detail-tour-list" style="background: #eeeeee">
                  <div class="img-tour">
                    <a href="ve-tau-chang-di-vinh-ha-noi/index.html">
                      <img src="https://phongveadamviet.com/wp-content/uploads/2019/01/ve-tau-300x200.jpg"
                        alt="Vé tàu chặng đi Vinh &#8211; Hà Nội" />
                    </a>
                  </div>
                  <div class="info-tour" style="padding: 15px">
                    <h4>
                      <a href="" style="text-decoration: none; font-size: 15px">Vé
                        tàu chặng đi Vinh &#8211; Hà Nội</a>
                    </h4>
                    <p class="price" style="
                        color: #e00;
                        font: 400 18px / normal Utm-Avo-bold, sans-serif;
                        font-weight: bold;
                        padding-top: 10px;
                      ">
                      253.000 VNĐ
                    </p>
                    <p>
                      <i class="fa fa-clock-o" style="color: red"></i>
                      Khởi hành:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">9:28 AM</span>
                    </p>
                    <p>
                      <i class="fa fa-star" style="color: red"></i> Hạng vé:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">Ngồi mềm điều hòa</span>
                    </p>
                  </div>
                </div>
              </div>
              <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
                <div class="detail-tour-list" style="background: #eeeeee">
                  <div class="img-tour">
                    <a href="ve-tau-chang-di-vinh-ha-noi/index.html">
                      <img src="https://phongveadamviet.com/wp-content/uploads/2019/01/ve-tau-300x200.jpg"
                        alt="Vé tàu chặng đi Vinh &#8211; Hà Nội" />
                    </a>
                  </div>
                  <div class="info-tour" style="padding: 15px">
                    <h4>
                      <a href="" style="text-decoration: none; font-size: 15px">Vé
                        tàu chặng đi Vinh &#8211; Hà Nội</a>
                    </h4>
                    <p class="price" style="
                        color: #e00;
                        font: 400 18px / normal Utm-Avo-bold, sans-serif;
                        font-weight: bold;
                        padding-top: 10px;
                      ">
                      253.000 VNĐ
                    </p>
                    <p>
                      <i class="fa fa-clock-o" style="color: red"></i>
                      Khởi hành:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">9:28 AM</span>
                    </p>
                    <p>
                      <i class="fa fa-star" style="color: red"></i> Hạng vé:
                      <span style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        ">Ngồi mềm điều hòa</span>
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </body>
</template>
<script>
export default {
  name: 'TimVe',
  props: ['searchResult'],
  created() {
    console.log('Params trên TimVe:', this.$route.params);
    if (this.$route.params.searchResult) {
      const xValue = this.$route.params.searchResult;
      console.log('Dữ liệu x:', xValue);
    } else {
      console.log('Không tìm thấy x trong params');
    }
  },

  //props: ['searchResult'], // Đảm bảo props searchResult đã được khai báo đúng
  // mounted() {
  //   debugger
  //   console.log('Props trên TimVe:', JSON.stringify(this.$route));
  //   // Kiểm tra xem có dữ liệu trong this.searchResult không
  //   if (this.searchResult && this.searchResult.length > 0) {
  //     console.log('Dữ liệu searchResult:', this.searchResult[0]);
  //     // Tiếp tục xử lý dữ liệu ở đây nếu cần
  //   }
  // },
  // created() {
  //   console.log('Params trên TimVe:', this.$route.params);

  //   if (this.$route.params.searchResult) {
  //     this.searchResult = this.$route.params.searchResult;
  //     console.log('Kết quả tìm kiếm trên trang TimVe:', this.searchResult);
  //   } else {
  //     console.warn('Không tìm thấy searchResult trong params');
  //   }
  // },
  // data() {
  //   return {
  //     searchResult: null, // Khởi tạo biến searchResult
  //   };
  // },

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
