<template>
  <body data-rsssl="1">
    <div id="wrapper">
      <div id="content" style="margin-bottom: 60px; margin-top: 90px">
        <div class="main-content">
          <div class="container">
            <h5
              style="
                margin-bottom: 50px;
                font-size: 12px;
                font-family: Roboto;
                color: #d82d8b;
              "
            >
              <i class="fa-solid fa-arrow-right" style="padding-right: 5px"></i
              >TÌM VÉ
            </h5>
            <div class="row">
              <div
                class="col-xs-12 col-sm-12 col-md-6 col-lg-3"
                v-for="ticket in searchResult"
                :key="ticket.id"
              >
                <div class="detail-tour-list" style="background: #eeeeee">
                  <div class="img-tour">
                    <a href="#" @click="onClick()">
                      <img
                        src="https://phongveadamviet.com/wp-content/uploads/2019/01/ve-tau-300x200.jpg"
                        alt="Vé tàu chặng đi Vinh &#8211; Hà Nội"
                      />
                    </a>
                  </div>
                  <div class="info-tour" style="padding: 15px">
                    <h4>
                      <a
                        href="#"
                        @click.stop="onClick()"
                        style="text-decoration: none; font-size: 15px"
                      >
                        Vé tàu chặng đi
                        {{ getStationName(ticket.startStationID) }} –
                        {{ getStationName(ticket.endStationID) }}</a
                      >
                    </h4>
                    <p
                      class="price"
                      style="
                        color: #e00;
                        font: 400 18px / normal Utm-Avo-bold, sans-serif;
                        font-weight: bold;
                        padding-top: 10px;
                      "
                    >
                      {{ getTrainName(ticket.trainID) }}
                    </p>
                    <p>
                      <i class="fa fa-clock-o" style="color: red"></i>
                      Khởi hành:
                      <span
                        style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        "
                        >{{ formatTime(ticket.departureTime) }}</span
                      >
                    </p>
                    <p>
                      <i class="fa fa-calendar" style="color: red"></i>
                      Khởi hành:
                      <span
                        style="
                          font-weight: 500;
                          font-family: Roboto;
                          color: #000;
                        "
                        >{{ formatDate(ticket.departureTime) }}</span
                      >
                    </p>
                  </div>
                </div>
              </div>
            </div>
            <!-- Modal -->
            <div
              class="modal"
              :class="{ show: showModal }"
              id="Modal"
              tabindex="-1"
              aria-labelledby="exampleModalLabel"
              aria-hidden="true"
            >
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title">Tiêu đề modal</h5>
                    <button
                      type="button"
                      class="btn-close"
                      data-bs-dismiss="modal"
                      aria-label="Đóng"
                      @click.prevent
                    ></button>

                    <!-- <button type="button" class="btn-close" aria-label="Đóng" @click="closeModal"></button> -->
                  </div>
                  <div class="modal-body">
                    <div class="row">
                      <!-- Ví dụ bố trí chỗ ngồi -->
                      <div class="col-12 text-center">
                        <div class="d-flex justify-content-center mb-2">
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            A1
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            A2
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #dc3545;
                              color: white;
                              border: none;
                              cursor: not-allowed;
                            "
                            disabled
                          >
                            A3
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            A4
                          </button>
                        </div>
                        <div class="d-flex justify-content-center mb-2">
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            B1
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            B2
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            B3
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #dc3545;
                              color: white;
                              border: none;
                              cursor: not-allowed;
                            "
                            disabled
                          >
                            B4
                          </button>
                        </div>
                        <div class="d-flex justify-content-center mb-2">
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            C1
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            C2
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            C3
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            C4
                          </button>
                        </div>
                        <div class="d-flex justify-content-center mb-2">
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #dc3545;
                              color: white;
                              border: none;
                              cursor: not-allowed;
                            "
                            disabled
                          >
                            D1
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            D2
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            D3
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            D4
                          </button>
                        </div>
                        <div class="d-flex justify-content-center mb-2">
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            E1
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            E2
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #28a745;
                              color: white;
                              border: none;
                            "
                          >
                            E3
                          </button>
                          <button
                            style="
                              width: 40px;
                              height: 40px;
                              margin: 5px;
                              display: flex;
                              justify-content: center;
                              align-items: center;
                              background-color: #dc3545;
                              color: white;
                              border: none;
                              cursor: not-allowed;
                            "
                            disabled
                          >
                            E4
                          </button>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="modal-footer">
                    <button
                      type="button"
                      class="btn btn-secondary"
                      @click.prevent="closeModal"
                    >
                      Đóng
                    </button>
                    <button
                      type="button"
                      class="btn btn-primary"
                      @click="onSaveClick()"
                    >
                      Tiếp tục
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <!-- Modal -->
          </div>
        </div>
      </div>
    </div>
  </body>
</template>
<script>
import axios from "axios";
import { Modal } from "bootstrap";
export default {
  name: "TimVe",
  components: {
    // eslint-disable-next-line vue/no-unused-components
    Modal,
  },

  props: ["startStationID", "endStationID"],
  data() {
    return {
      searchResult: [],
      stations: [],
      trains: [],
      Modal: null,
      showModal: false, // Trạng thái hiển thị modal
    };
  },

  created() {
    this.loadStations().then(() => {
      // Sau khi tải dữ liệu thành công, bạn có thể gọi API tìm kiếm vé
      const { startStationID, endStationID } =
        this.$router.currentRoute._rawValue.params;
      axios
        .post(process.env.VUE_APP_BASE_URL + "TrainSchedule/FullFilter", {
          filterRequests: [
            {
              colName: "StartStationID",
              _RightSize: startStationID,
              _operator: "equal",
            },
            {
              colName: "EndStationID",
              _RightSize: endStationID,
              _operator: "equal",
            },
            // { colName: 'JourneyDate', _RightSize: this.departureDate.toString(), _operator: 'equal' }
          ],
        })
        .then((response) => {
          console.log("Kết quả tìm kiếm:", response.data);
          this.searchResult = response.data;
        })
        .catch((error) => {
          console.error("Lỗi khi tìm kiếm vé:", error);
        });
    });
    this.loadTrains();
  },

  methods: {
    formatTime(dateTimeString) {
      const date = new Date(dateTimeString);
      const options = {
        // year: 'numeric',
        // month: '2-digit',
        // day: '2-digit',
        hour: "2-digit",
        minute: "2-digit",
      };

      return date.toLocaleString("vi-VN", options);
    },
    formatDate(dateTimeString) {
      const date = new Date(dateTimeString);
      const options = {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
        // hour: '2-digit',
        // minute: '2-digit'
      };

      return date.toLocaleString("vi-VN", options);
    },
    async loadStations() {
      try {
        const url = process.env.VUE_APP_BASE_URL + "Station/GetAll";
        const response = await axios.get(url);
        console.log("Stations API response:", response);
        this.stations = response.data;
      } catch (error) {
        console.error("Error loading stations:", error.response || error);
      }
    },
    getStationName(id) {
      const station = this.stations.find((s) => s.id === id);
      return station ? station.stationName : "Unknown Station";
    },
    async loadTrains() {
      try {
        const url = process.env.VUE_APP_BASE_URL + "Train/GetAll"; // Thay đổi URL API tương ứng
        const response = await axios.get(url);
        this.trains = response.data; // Lưu thông tin tàu từ API vào mảng trains
        console.log("Trains API response:", this.trains);
      } catch (error) {
        console.error("Error loading trains:", error.response || error);
      }
    },
    getTrainName(trainID) {
      const train = this.trains.find((t) => t.id === trainID);
      return train ? train.trainName : "Unknown Train"; // Trả về tên của tàu hoặc thông báo "Unknown Train" nếu không tìm thấy
    },
    onClick() {
      // this.currentTrain = Object.assign({}, p);// clone d
      this.showModal = true; // Mở modal
    },
    closeModal() {
      this.showModal = false; // Đóng modal
    },
    logout() {
      // Xử lý đăng xuất ở đây
      // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
      localStorage.removeItem("token");
      this.$router.push("/login");
      window.location.reload();
    },
  },
  // mounted() {
  //   this.Modal = new Modal(this.$refs.Modal);
  // }
};
</script>
