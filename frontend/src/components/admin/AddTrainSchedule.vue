<template>
    <div id="login">
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Thêm lịch trình</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/TrainSchedule" title="Thêm"><i
                                            class="fa fa-chevron-left"></i>Quay lại</a>
                                    <!-- <button class="btn btn-success" @click="onCreateClick()">Quay lại</button> -->
                                </div>

                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="route-select" class="col-form-label">Tuyến tàu:</label>
                                        <select class="form-select form-select-lg mb-3 form-control"
                                            v-model="currentTrainSchedule.TrainID">
                                            <option value="" disabled selected>Chọn tàu</option>
                                            <option v-for="t in train" :key="t.id" :value="t.id">
                                                {{ t.trainName }}

                                            </option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="route-select" class="col-form-label">Ga xuất phát:</label>
                                        <select class="form-select form-select-lg mb-3 form-control"
                                            v-model="currentTrainSchedule.StartStationID">
                                            <option value="" disabled selected>Chọn ga xuất phát</option>
                                            <option v-for="s in station" :key="s.id" :value="s.id">
                                                {{ s.stationName }}

                                            </option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="route-select" class="col-form-label">Ga kết thúc:</label>
                                        <select class="form-select form-select-lg mb-3 form-control"
                                            v-model="currentTrainSchedule.EndStationID">
                                            <option value="" disabled selected>Chọn ga kết thúc</option>
                                            <option v-for="s in station" :key="s.id" :value="s.id">
                                                {{ s.stationName }}

                                            </option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Ngày xuất phát</label>
                                        <input type="datetime-local" class="form-control" id="recipient-name"
                                            v-model="currentTrainSchedule.departureTime">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Ngày Đến</label>
                                        <input type="datetime-local" class="form-control" id="recipient-name"
                                            v-model="currentTrainSchedule.arrivalTime">
                                    </div>

                                    <button type="button" style=" width: 100px;height: 30px; font-size: 15px;"
                                        class="btn btn-primary" @click="onSaveClick()">Thêm lịch trình</button>

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
            train: [],
            station: [],
            currentTrainSchedule: {
                id: 0,

            },

        }
    },
    methods: {
        fetchtrains() {
            const url = process.env.VUE_APP_BASE_URL + `Train/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.train = data;
                })
                .catch(error => {
                    console.error('Error fetching trains:', error);
                });
        },
        fetchStation() {
            const url = process.env.VUE_APP_BASE_URL + `Station/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.station = data;
                })
                .catch(error => {
                    console.error('Error fetching station:', error);
                });
        },
        onSaveClick() {

            if (this.currentTrainSchedule.id == 0) {
                var url = process.env.VUE_APP_BASE_URL + `TrainSchedule/Create`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');
                const requestOptions = {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    }
                };

                axios.post(url, this.currentTrainSchedule, requestOptions)
                    .then((response) => {
                        console.log(response.data);

                        // Hiển thị thông báo thành công
                        this.success();
                        setTimeout(() => {
                            window.location.href = '/admin/TrainSchedule'; // Thay đổi URL chuyển hướng tùy ý
                        }, 2000); // Đợi 2 giây trước khi chuyển hướng

                    })
                    .catch((error) => {
                        if (error.response && error.response.data) {
                            console.log(error.response.data);
                            // Xử lý lỗi ở đây
                            this.errors.push('Có lỗi xảy ra: ' + error.response.data.title);
                            if (error.response.data.errors) {
                                for (let key in error.response.data.errors) {
                                    this.errors.push(error.response.data.errors[key].join(', '));
                                }
                            }
                        } else {
                            console.log('Lỗi không xác định:', error);
                            this.errors.push('Lỗi không xác định: ' + error.message);
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
        this.fetchtrains();
        this.fetchStation();
        //load Modal
        // this.ProductModal = new Modal(this.$refs.ProductModal);
    }
}
</script>
<style scoped>
/* @import url("/public/login.css"); */
</style>
