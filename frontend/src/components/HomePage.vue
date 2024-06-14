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
                          <option v-for="t in trainSchedule" :key="t.id" :value="t.startStationID">
                            {{ getStationName(t.startStationID) }}
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
                          <option v-for=" t in trainSchedule" :key="t.id" :value="t.endStationID">
                            {{ getStationName(t.endStationID) }}
                          </option>
                        </select>
                      </fieldset>

                    </div>
                    <div class="col-md-6">
                      <fieldset>
                        <label for="departure">Ngày đi:</label>
                        <input name="deparure" type="date" class="form-control date" id="deparure"
                          placeholder="Select date..." required="" onchange="this.form.()"
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

  <!-- <div class="tabs-content" id="recommended-hotel">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-heading">
                        <h2>Recommended Hotel For You</h2>
                    </div>
                </div>
                <div class="wrapper">
                    <div class="col-md-4">
                        <ul class="tabs clearfix" data-tabgroup="third-tab-group">
                            <li><a href="#livingroom" class="active">Living Room <i class="fa fa-angle-right"></i></a>
                            </li>
                            <li><a href="#suitroom">Suit Room <i class="fa fa-angle-right"></i></a></li>
                            <li><a href="#swimingpool">Swiming Pool <i class="fa fa-angle-right"></i></a></li>
                            <li><a href="#massage">Massage Service <i class="fa fa-angle-right"></i></a></li>
                            <li><a href="#fitness">Fitness Life <i class="fa fa-angle-right"></i></a></li>
                            <li><a href="#event">Evening Event <i class="fa fa-angle-right"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-8">
                    <section id="third-tab-group" class="recommendedgroup">
                        <div id="livingroom">
                            <div class="text-content">
                                <iframe width="100%" height="400px" src="https://www.youtube.com/embed/rMxTreSFMgE">
                                </iframe>
                            </div>
                        </div>
                        <div id="suitroom">
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="owl-suiteroom" class="owl-carousel owl-theme">
                                        <div class="item">
                                            <div class="suiteroom-item">
                                                <img src="img/suite-02.jpg" alt="">
                                                <div class="text-content">
                                                    <h4>Clean And Relaxing Room</h4>
                                                    <span>Aurora Resort</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="suiteroom-item">
                                                <img src="img/suite-01.jpg" alt="">
                                                <div class="text-content">
                                                    <h4>Special Suite Room TV</h4>
                                                    <span>Khao Yai Hotel</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="suiteroom-item">
                                                <img src="img/suite-03.jpg" alt="">
                                                <div class="text-content">
                                                    <h4>The Best Sitting</h4>
                                                    <span>Hotel Grand</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="swimingpool">
                            <img src="img/swiming-pool.jpg" alt="">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-content">
                                        <h4>Lovely View Swiming Pool For Special Guests</h4>
                                        <span>Victoria Resort and Spa</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="massage">
                            <img src="img/massage-service.jpg" alt="">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-content">
                                        <h4>Perfect Place For Relaxation</h4>
                                        <span>Napali Beach</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="fitness">
                            <img src="img/fitness-service.jpg" alt="">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-content">
                                        <h4>Insane Street Workout</h4>
                                        <span>Hua Hin Beach</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="event">
                            <img src="img/evening-event.jpg" alt="">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="text-content">
                                        <h4>Finest Winery Night</h4>
                                        <span>Queen Restaurant</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>





    <section id="most-visited">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-heading">
                        <h2>Most Visited Places</h2>
                    </div>
                </div>
                <div class="col-md-12">
                    <div id="owl-mostvisited" class="owl-carousel owl-theme">
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-01.jpg" alt="">
                                <div class="text-content">
                                    <h4>River Views</h4>
                                    <span>New York</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-02.jpg" alt="">
                                <div class="text-content">
                                    <h4>Lorem ipsum dolor</h4>
                                    <span>Tokyo</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-03.jpg" alt="">
                                <div class="text-content">
                                    <h4>Proin dignissim</h4>
                                    <span>Paris</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-04.jpg" alt="">
                                <div class="text-content">
                                    <h4>Fusce sed ipsum</h4>
                                    <span>Hollywood</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-02.jpg" alt="">
                                <div class="text-content">
                                    <h4>Vivamus egestas</h4>
                                    <span>Tokyo</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-01.jpg" alt="">
                                <div class="text-content">
                                    <h4>Aliquam elit metus</h4>
                                    <span>New York</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-03.jpg" alt="">
                                <div class="text-content">
                                    <h4>Phasellus pharetra</h4>
                                    <span>Paris</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-04.jpg" alt="">
                                <div class="text-content">
                                    <h4>In in quam efficitur</h4>
                                    <span>Hollywood</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-01.jpg" alt="">
                                <div class="text-content">
                                    <h4>Sed faucibus odio</h4>
                                    <span>NEW YORK</span>
                                </div>
                            </div>
                        </div>
                        <div class="item col-md-12">
                            <div class="visited-item">
                                <img src="img/place-02.jpg" alt="">
                                <div class="text-content">
                                    <h4>Donec varius porttitor</h4>
                                    <span>Tokyo</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>



    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="primary-button">
                        <a href="#" class="scroll-top">Back To Top</a>
                    </div>
                </div>
                <div class="col-md-12">
                    <ul class="social-icons">
                        <li><a href="https://www.facebook.com/Share-Source-Code-Website-189970988225280/"><i
                                    class="fa fa-facebook"></i></a></li>
                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                        <li><a href="#"><i class="fa fa-rss"></i></a></li>
                        <li><a href="#"><i class="fa fa-behance"></i></a></li>
                    </ul>
                </div>
                <div class="col-md-12">
                    <p>Copyright &copy; 2018 Flight Tour and Travel Company</p>
                </div>
            </div>
        </div>
    </footer> -->
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
      selectedTo: null

    }
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

        // Gọi API FullFilter để tìm kiếm vé
        axios.post(process.env.VUE_APP_BASE_URL + 'TrainSchedule/FullFilter', {
          filterRequests: [
            { colName: 'StartStationID', _RightSize: selectedFromAsString, _operator: 'like' },
            { colName: 'EndStationID', _RightSize: selectedToAsString, _operator: 'like' },
            //{ colName: 'JourneyDate', _RightSize: this.departureDate.toString(), _operator: 'equal' }
          ],

        }).then((response) => {
          debugger
          console.log('Kết quả tìm kiếm:', response.data);

          // Lưu kết quả tìm kiếm vào state hoặc biến của component
          this.searchResult = response.data;

          // Điều hướng sang trang tìm vé và truyền dữ liệu tìm kiếm    
          //console.log('truyen di:' + JSON.stringify)
          this.$router.push({ name: 'TimVe', params: { searchResult: this.searchResult } });
          // this.$router.push({ name: 'TimVe', params: { x: "haha" } });

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
