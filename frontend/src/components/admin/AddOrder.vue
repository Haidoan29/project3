<template>
    <div id="login">
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Thêm vé mới</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/order" title="Thêm"><i
                                            class="fa fa-chevron-left"></i>Quay lại</a>
                                    <!-- <button class="btn btn-success" @click="onCreateClick()">Quay lại</button> -->
                                </div>

                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Tàu:</label>
                                        <select class="form-select form-select-lg mb-3" v-model="currentOrder.TrainID">
                                            <option value="" disabled selected>Chọn Tàu</option>
                                            <option v-for="t in trains" :key="t.id" :value="t.id">
                                                {{ t.trainName }}
                                            </option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Tên khách hàng:</label>
                                        <select class="form-select form-select-lg mb-3"
                                            v-model="currentOrder.CustomerID">
                                            <option value="" disabled selected>Chọn Tên Khách Hàng</option>
                                            <option v-for="c in customer" :key="c.id" :value="c.id">
                                                {{ c.name }}
                                            </option>
                                        </select>
                                    </div>

                                    <button type="button" style=" width: 100px;height: 30px; font-size: 15px;"
                                        class="btn btn-primary" @click="onSaveClick()">Thêm tàu</button>
                                </form>
                            </div>



                        </div>

                    </div>
                </div>
            </div>
        </main>
    </div>
</template>
<script>
import axios from 'axios';
// import { Modal } from 'bootstrap';
import { toast } from 'vue3-toastify';

import 'vue3-toastify/dist/index.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
export default {
    name: 'EmployeeCustomer',


    setup() {
        const success = () => {
            toast("Success !", {
                autoClose: 1000,
                type: "success"
            });
        }
        return { success };
    },
    data() {
        return {
            orderData: [],
            stations: [],
            trains: [],
            customer: [],
            seat: [],
            fareRule: [],
            currentOrder: {
                id: 0,
                TrainID: "",
                CustomerID: "",
                JourneyDate: "",
                FromStationID: "",
                ToStationID: "",
                SeatID: "",
                FareRuleID: "",

            },

        }
    },
    methods: {
        fetchStations() {
            const stationApiUrl = process.env.VUE_APP_BASE_URL + `Station/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(stationApiUrl)
                .then(response => response.json())
                .then(data => {
                    this.stations = data;


                })
                .catch(error => {
                    console.error('Error fetching stations:', error);
                });
        },
        fetchTrain() {
            const url = process.env.VUE_APP_BASE_URL + `Train/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.trains = data;
                })
                .catch(error => {
                    console.error('Error fetching train:', error);
                });
        },
        fetchCustomer() {
            const url = process.env.VUE_APP_BASE_URL + `Customer/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.customer = data;
                })
                .catch(error => {
                    console.error('Error fetching customer:', error);
                });
        },
        fetchSeat() {
            const url = process.env.VUE_APP_BASE_URL + `Seat/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.seat = data;
                })
                .catch(error => {
                    console.error('Error fetching seat:', error);
                });
        },
        fetchFareRule() {
            const url = process.env.VUE_APP_BASE_URL + `FareRule/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.fareRule = data;
                })
                .catch(error => {
                    console.error('Error fetching fareRule:', error);
                });
        },
        onSaveClick() {
            if (this.currentOrder.id == 0) {
                var url = process.env.VUE_APP_BASE_URL + `Station/Create`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');

                axios.post(url, this.currentOrder, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                })
                    .then((response) => {
                        console.log(response.data);

                        // Hiển thị thông báo thành công
                        this.success();
                        setTimeout(() => {
                            window.location.href = '/admin/station'; // Thay đổi URL chuyển hướng tùy ý
                        }, 2000); // Đợi 3 giây trước khi chuyển hướng

                        // // Ẩn modal
                        // this.ProductModal.hide();

                        // Tải lại dữ liệu sản phẩm
                        this.loadProductData();
                    })
                    .catch((error) => {
                        if (error.response && error.response.data) {
                            console.log(error.response.data);
                            // Xử lý lỗi ở đây
                        } else {
                            console.log('Lỗi không xác định:', error);
                        }
                    });
            }

        },
        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },


    },
    mounted() {
        // this.loadProductData();
        console.log(this.totalPages);
        this.fetchStations();
        this.fetchTrain();
        this.fetchCustomer();
        this.fetchSeat();
        this.fetchFareRule();


    }
}
</script>
