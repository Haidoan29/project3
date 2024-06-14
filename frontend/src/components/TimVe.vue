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
                <template v-if="searchResult.length > 0">
                  <div class="detail-tour-list" style="background: #eeeeee" v-for="ticket in searchResult"
                    :key="ticket.id">
                    <div class="img-tour">
                      <a href="ve-tau-chang-di-vinh-ha-noi/index.html">
                        <img src="https://phongveadamviet.com/wp-content/uploads/2019/01/ve-tau-300x200.jpg"
                          alt="Vé tàu chặng đi Vinh &#8211; Hà Nội" />
                      </a>
                    </div>
                    <div class="info-tour" style="padding: 15px">
                      <h4>
                        <a href="" style="text-decoration: none; font-size: 15px"> Vé tàu chặng đi
                          {{ ticket.startStationID }} – {{ ticket.endStationID }}</a>
                      </h4>
                      <p class="price" style="
                          color: #e00;
                          font: 400 18px / normal Utm-Avo-bold, sans-serif;
                          font-weight: bold;
                          padding-top: 10px;
                        ">
                        tên tàu
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
                </template>
                <template v-else>
                  <div>
                    <p>Không có kết quả tìm kiếm nào.</p>
                  </div>
                </template>
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
import axios from 'axios';
export default {
  name: 'TimVe',
  props: ['startStationID', 'endStationID'],
  data() {
    return {
      searchResult: []
    }
  },

  created() {
    //Gọi API FullFilter để tìm kiếm vé
    const { startStationID, endStationID } = this.$router.currentRoute._rawValue.params;
    console.log(`this.startStationID = ${startStationID}, this.endStationID = ${endStationID}`);

    //console.log(JSON.stringify(this.$router))
    //const params = this.$router.currentRoute._rawValue.params;
    axios.post(process.env.VUE_APP_BASE_URL + 'TrainSchedule/FullFilter', {
      filterRequests: [
        { colName: 'StartStationID', _RightSize: startStationID, _operator: 'like' },
        { colName: 'EndStationID', _RightSize: endStationID, _operator: 'like' },
        //{ colName: 'JourneyDate', _RightSize: this.departureDate.toString(), _operator: 'equal' }
      ],

    }).then((response) => {

      console.log('Kết quả tìm kiếm:', response.data);

      // Lưu kết quả tìm kiếm vào state hoặc biến của component
      this.searchResult = response.data;
      if (this.searchResult && this.searchResult.length > 0) {
        console.log('Dữ liệu searchResult:', this.searchResult);
        // Tiếp tục xử lý dữ liệu nếu cần thiết
      } else {
        console.log('searchResult không có dữ liệu.');
      }



    }).catch((error) => {
      debugger
      console.error('Lỗi khi tìm kiếm vé:', error);
      // Xử lý lỗi nếu cần thiết
    });
  },

  // computed: {
  //   parsedSearchResult() {
  //     return JSON.parse(this.searchResult);
  //   }
  // },
  // created() {
  //   // Kiểm tra dữ liệu đã nhận từ props
  //   console.log('Dữ liệu searchResult:', this.parsedSearchResult);
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
