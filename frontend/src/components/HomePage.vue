<template>
  <section class="banner" id="top" style="margin-top: 75px">
    <div class="container">
      <div class="row">
        <div class="col-md-5" style="margin-left: 80px">
          <div class="left-side"></div>
        </div>
        <div class="col-md-5 col-md-offset-1">
          <section id="first-tab-group" class="tabgroup">
            <div id="tab1" style="box-shadow: 4px 4px 8px #f48fb7">
              <div class="submit-form">
                <h4>Thông tin hành trình:</h4>
                <form id="form-submit" action="#" method="get">
                  <div class="row">
                    <div class="col-md-6">
                      <fieldset>
                        <label for="from">Ga đi:</label>
                        <select required name="from" @change="handleChangeFrom" v-model="selectedFrom"
                          style="border: 1px solid black;">
                          <option value="">Select a location...</option>
                          <option v-for="t in uniqueStartStations" :key="t" :value="t">
                            {{ getStationName(t) }}
                          </option>
                        </select>
                      </fieldset>


                    </div>
                    <div class="col-md-6">
                      <fieldset>
                        <label for="to">Ga đến:</label>
                        <select required name="to" @change="handleChangeTo" v-model="selectedTo"
                          style="border: 1px solid black;">
                          <option value="">Select a location...</option>
                          <option v-for="t in uniqueEndStations" :key="t" :value="t">
                            {{ getStationName(t) }}
                          </option>
                        </select>
                      </fieldset>

                    </div>
                    <div class="col-md-6">
                      <fieldset>
                        <label for="departure">Ngày đi:</label>
                        <input name="deparure" type="date" class="form-control date" id="deparure"
                          placeholder="Select date..." v-model="departureDate" required=""
                          style="border: 1px solid black" />
                      </fieldset>
                    </div>

                    <!-- <div class="col-md-6"></div> -->

                    <div class="col-md-6 mt-5">
                      <fieldset>
                        <button type="submit" id="form-submit" class="btn"
                          style="background-color: #26a8bc; color: white" @click="searchTickets()">
                          <i><img src="../assets/img/service-icon-03.png" class="img-fluid" style="
                                height: 15px;
                                width: 15px;
                                margin-right: 5px;
                              " />
                          </i>
                          Tìm vé
                        </button>
                      </fieldset>
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </section>
        </div>
      </div>
    </div>
  </section>
  <section class="services">
    <div class="container">
      <div class="row">
        <div class="col-md-4">
          <div class="service-item first-service" style="border-radius: 25px; box-shadow: 4px 4px 8px #f48fb7">
            <div class="fa-solid fa-plant-wilt" style="font-size: 70px"></div>
            <h4>LÊN KẾ HOẠCH</h4>
            <p>
              Tìm thấy tuyến đường tốt nhất cho bạn nhờ vào chúng tôi. Giúp bạn
              lên kế hoạch cho những chuyến đi bất cứ khi nào và ở đâu.
            </p>
          </div>
        </div>
        <div class="col-md-4">
          <div class="service-item second-service" style="border-radius: 25px; box-shadow: 4px 4px 8px #f48fb7">
            <div class="fa-solid fa-ticket" style="font-size: 70px"></div>
            <h4>ĐẶT VÉ</h4>
            <p>
              Đặt vé tàu trực tuyến giúp bạn tiết kiệm thời gian và công sức.
              Chọn lịch trình, chỗ ngồi và thanh toán một cách thuận tiện ngay
              trên trang web.
            </p>
          </div>
        </div>
        <div class="col-md-4">
          <div class="service-item third-service" style="border-radius: 25px; box-shadow: 4px 4px 8px #f48fb7">
            <div class="fa-solid fa-train" style="font-size: 70px"></div>
            <h4>SẴN SÀNG LÊN ĐƯỜNG</h4>
            <p>
              Nhận hành trình và vé điện tử qua email. Bạn có thể in vé ra hoặc
              mang theo trên điện thoại di động, sẵn sàng lên xe.
            </p>
          </div>
        </div>
      </div>
    </div>
  </section>


</template>

<script>
import axios from 'axios';

export default {
  name: "TrainS",
  data() {
    return {
      trainSchedule: [],
      stations: [],
      selectedFrom: null,
      selectedTo: null,
      departureDate: ''

    }
  },
  computed: {
    uniqueStartStations() {
      const seen = new Set();
      return this.trainSchedule
        .filter(t => t.startStationID)  // Lọc ra các phần tử có startStationID hợp lệ
        .filter(t => {
          const duplicate = seen.has(t.startStationID);
          seen.add(t.startStationID);
          return !duplicate;
        })
        .map(t => t.startStationID);
    },
    uniqueEndStations() {
      const seen = new Set();
      return this.trainSchedule
        .filter(t => t.endStationID)  // Lọc ra các phần tử có startStationID hợp lệ
        .filter(t => {
          const duplicate = seen.has(t.endStationID);
          seen.add(t.endStationID);
          return !duplicate;
        })
        .map(t => t.endStationID);
    },
  },

  methods: {

    loadtrainData() {
      var url = process.env.VUE_APP_BASE_URL + `TrainSchedule/GetAll`;
      console.log(url)
      axios.get(url)
        .then((response) => {
          console.log('haha')
          console.log('API response:', response); // Log response để kiểm tra dữ liệu nhận được từ API

          if (response && response.data) {
            this.trainSchedule = response.data; // Gán dữ liệu từ API vào mảng trainSchedule
            console.log('h', this.trainSchedule)
            // Các xử lý khác tại đây nếu cần
          } else {
            console.error('Empty response or missing data.'); // Log lỗi nếu dữ liệu trả về từ API không đúng
          }
        })
        .catch((error) => {
          console.error('Error fetching train data:', error); // Log lỗi nếu gọi API thất bại
        });
    },
    handleChangeFrom() {
      // Xử lý khi thay đổi dropdown "Ga đi"
      console.log("Ga đi đã thay đổi", this.selectedFrom);
    },
    handleChangeTo() {
      // Xử lý khi thay đổi dropdown "Ga đến"
      console.log("Ga đến đã thay đổi", this.selectedTo);
    },
    loadStations() {
      var url = process.env.VUE_APP_BASE_URL + 'Station/GetAll';
      axios.get(url).then((response) => {
        console.log("Stations API response:", response);
        this.stations = response.data;
      }).catch((error) => {
        console.log("Error:", error.response);
      });
    },
    getStationName(id) {
      const station = this.stations.find(s => s.id === id);
      return station ? station.stationName : 'Unknown Station';
    },
    searchTickets() {
      try {
        // Chuyển đổi this.selectedFrom và this.selectedTo thành chuỗi
        const selectedFromAsString = this.selectedFrom.toString();
        const selectedToAsString = this.selectedTo.toString();
        const JourneyDateString = this.departureDate.toString();
        console.log(`selectedFromAsString = ${selectedFromAsString},selectedToAsString = ${selectedToAsString} `);
        this.$router.push({
          name: 'TimVe',
          params: { startStationID: selectedFromAsString, endStationID: selectedToAsString, journeyDate: JourneyDateString }
        });



      } catch (error) {
        debugger
        console.error('Lỗi khi tìm kiếm vé:', error);
        // Xử lý lỗi nếu cần thiết
      }
    },
    logout() {
      // Xử lý đăng xuất ở đây
      // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
      localStorage.removeItem("token");
      this.$router.push("/login");
      window.location.reload();
    },
  },
  mounted() {
    this.loadtrainData();
    this.loadStations();
    // console.log(this.totalPages);
    // this.fetchtrains();
    //load Modal
    // this.trainModal = new Modal(this.$refs.trainModal);
    // this.deletModal = new Modal(this.$refs.deletModal);
  }
};
</script>

<style scoped>
@import url("@/assets/css/bootstrap.min.css");
@import url("@/assets/css/bootstrap-theme.min.css");
@import url("@/assets/css/fontAwesome.css");
@import url("@/assets/css/hero-slider.css");
@import url("@/assets/css/owl-carousel.css");
@import url("@/assets/css/datepicker.css");
@import url("@/assets/css/tooplate-style.css");

.home {
  text-align: center;
  margin-top: 50px;
}
</style>
