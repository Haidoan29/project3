<template>
    <div id="login">
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Thêm mới tuyến đường</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/seat" title="Thêm"><i
                                            class="fa fa-chevron-left"></i>Quay lại</a>
                                    <!-- <button class="btn btn-success" @click="onCreateClick()">Quay lại</button> -->
                                </div>

                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Số ghế:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentSeat.SeatNo">
                                    </div>

                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Tàu:</label>
                                        <select class="form-select form-select-lg mb-3" v-model="currentSeat.TrainID">
                                            <option value="" disabled selected>Chọn Tàu</option>
                                            <option v-for="t in train" :key="t.id" :value="t.id">
                                                {{ t.trainName }}
                                            </option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Hạng:</label>
                                        <select class="form-select form-select-lg mb-3" v-model="currentSeat.ClassID">
                                            <option value="" disabled selected>Chọn hạng ghế</option>
                                            <option v-for="c in Class" :key="c.id" :value="c.id">
                                                {{ c.className }}
                                            </option>
                                        </select>
                                    </div>
                                    <button type="button" style="width: 100px; height: 30px; font-size: 15px;"
                                        class="btn btn-primary" @click="onSaveClick()">Thêm ghế</button>
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
    name: 'AddSeat',


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

            currentSeat: {
                TrainID: 0,
                SeatNo: '',
                ClassID: 0,
                IsAvailable: true

            },
            train: [],
            Class: [],


        }
    },
    methods: {
        fetchTrain() {
            // Thay thế URL dưới đây bằng API thực tế của bạn
            const apiUrl = process.env.VUE_APP_BASE_URL + `Train/GetAll`;

            fetch(apiUrl)
                .then(response => response.json())
                .then(data => {
                    this.train = data;
                })
                .catch(error => {
                    console.error('Error fetching stations:', error);
                });
        },
        fetchClass() {
            // Thay thế URL dưới đây bằng API thực tế của bạn
            const apiUrl = process.env.VUE_APP_BASE_URL + `Class/GetAll`;

            fetch(apiUrl)
                .then(response => response.json())
                .then(data => {
                    this.Class = data;
                })
                .catch(error => {
                    console.error('Error fetching stations:', error);
                });
        },
        onSaveClick() {
            if (this.currentSeat.TrainID === 0 || this.currentSeat.SeatNo === '' || this.currentSeat.TicketClass === '') {
                alert('Vui lòng điền đầy đủ thông tin.');
                return;
            }

            var url = process.env.VUE_APP_BASE_URL + `Seat/Create`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');

            axios.post(url, this.currentSeat, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                }
            })
                .then((response) => {
                    console.log(response.data);

                    // Hiển thị thông báo thành công
                    this.success();
                    setTimeout(() => {
                        window.location.href = '/admin/seat'; // Thay đổi URL chuyển hướng tùy ý
                    }, 2000); // Đợi 3 giây trước khi chuyển hướng
                })
                .catch((error) => {
                    if (error.response && error.response.data) {
                        console.log(error.response.data);
                        // Xử lý lỗi ở đây
                    } else {
                        console.log('Lỗi không xác định:', error);
                    }
                });
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
        this.fetchTrain();
        this.fetchClass();
        //load Modal
        // this.ProductModal = new Modal(this.$refs.ProductModal);
    }
}
</script>
<style scoped>
/* @import url("/public/login.css"); */
</style>
