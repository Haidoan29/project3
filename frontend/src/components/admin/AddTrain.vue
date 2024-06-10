<template>
    <div id="login">
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Thêm tàu mới</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/train" title="Thêm"><i
                                            class="fa fa-chevron-left"></i>Quay lại</a>
                                    <!-- <button class="btn btn-success" @click="onCreateClick()">Quay lại</button> -->
                                </div>

                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Tên Tàu:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentTrain.TrainName">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Số lượng ghế hạng AC3</label>
                                        <input type="number" class="form-control" id="recipient-name"
                                            v-model="currentTrain.NumCoachesAC3">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Số lượng ghế hạng First
                                            Class:</label>
                                        <input type="number" class="form-control" id="recipient-name"
                                            v-model="currentTrain.NumCoachesFirstClass">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Số lượng ghế hạng
                                            Sleeper:</label>
                                        <input type="number" class="form-control" id="recipient-name"
                                            v-model="currentTrain.NumCoachesSleeper">
                                    </div>
                                    <div class="form-group">
                                        <label for="route-select" class="col-form-label">Tuyến đường:</label>
                                        <select class="form-select form-select-lg mb-3 form-control"
                                            v-model="currentTrain.RouteID">
                                            <option value="" disabled selected>Chọn tuyến đường</option>
                                            <option v-for="route in routes" :key="route.id" :value="route.id">
                                                {{ route.routeName }}
                                                <!-- {{ route.startStationID }}-{{ route.startStationID }} -->
                                            </option>
                                        </select>
                                    </div>
                                    <!-- <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">trạng thái:</label>
                                        <select class="form-select form-select-lg mb-3 form-control"
                                            v-model="currentTrain.UpDownStatus">
                                            <option value="" disabled selected>Chọn trạng thái</option>
                                            <option value="1">Up</option>
                                            <option value="2">Down</option>
                                        </select>
                                    </div> -->
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
            trainData: [],
            ProductModal: null,
            currentTrain: {
                id: 0,
                TrainName: '',
                NumCoachesAC3: 0,
                NumCoachesFirstClass: 0,
                NumCoachesSleeper: 0,
                //UpDownStatus: '',  // Kiểm tra giá trị này
                RouteID: ''
            },
            errors: [],
            routes: [],
            selectedRoute: ''
        }
    },
    methods: {
        fetchRoutes() {
            const routeApiUrl = process.env.VUE_APP_BASE_URL + `Routes/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(routeApiUrl)
                .then(response => response.json())
                .then(data => {
                    this.routes = data;
                })
                .catch(error => {
                    console.error('Error fetching routes:', error);
                });
        },
        onSaveClick() {
            // Kiểm tra dữ liệu trước khi gửi lên API
            this.errors = [];

            if (!this.currentTrain.TrainName) {
                this.errors.push('Tên tàu là bắt buộc.');
            }
            if (!this.currentTrain.NumCoachesAC3) {
                this.errors.push('Số lượng ghế hạng AC3 là bắt buộc.');
            }
            if (!this.currentTrain.NumCoachesFirstClass) {
                this.errors.push('Số lượng ghế hạng First Class là bắt buộc.');
            }
            if (!this.currentTrain.NumCoachesSleeper) {
                this.errors.push('Số lượng ghế hạng Sleeper là bắt buộc.');
            }
            if (!this.currentTrain.RouteID) {
                this.errors.push('Tuyến đường là bắt buộc.');
            }
            // if (!['Up', 'Down'].includes(this.currentTrain.UpDownStatus)) {
            //     this.errors.push('Trạng thái là bắt buộc và phải là "Up" hoặc "Down".');
            // }

            if (this.errors.length > 0) {
                return;
            }
            // Chuyển đổi trạng thái thành chuỗi trước khi gửi
            // this.currentTrain.UpDownStatus = this.currentTrain.UpDownStatus.toString();

            if (this.currentTrain.id == 0) {
                var url = process.env.VUE_APP_BASE_URL + `Train/Create`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');
                const requestOptions = {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    }
                };

                axios.post(url, this.currentTrain, requestOptions)
                    .then((response) => {
                        console.log(response.data);

                        // Hiển thị thông báo thành công
                        this.success();
                        setTimeout(() => {
                            window.location.href = '/admin/train'; // Thay đổi URL chuyển hướng tùy ý
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
        // onFileChange(event) {
        //     const file = event.target.files[0];
        //     if (file) {
        //         // Kiểm tra phần mở rộng của file
        //         const validExtensions = ['.png', '.jpg', '.jpeg'];
        //         const fileName = file.name;
        //         const fileExtension = fileName.substring(fileName.lastIndexOf('.')).toLowerCase();

        //         if (!validExtensions.includes(fileExtension)) {
        //             alert('Vui lòng chọn một file ảnh có định dạng .png, .jpg hoặc .jpeg!');
        //             return;
        //         }

        //         const reader = new FileReader();
        //         reader.onload = (e) => {
        //             this.currentTrain.imageProduct = e.target.result;
        //         };
        //         reader.readAsDataURL(file);
        //     }
        // },
        // onSubmit() {
        //     var url = process.env.VUE_APP_BASE_URL + `Class/FullFilter`;

        //     var requestData = {
        //         filterParams: [
        //             {
        //                 colName: "className",
        //                 _operator: "like",
        //                 value: this.searchKeyword
        //             }
        //         ],
        //         index: 1,
        //         size: 10,
        //         sortAsc: true,
        //         sortCol: "className"
        //     };

        //     axios.post(url, requestData)
        //         .then(response => {
        //             this.productData = response.data;
        //             this.totalItems = this.productData.length; // Số lượng sản phẩm trong dữ liệu nhận được
        //             this.totalPages = Math.ceil(this.totalItems / this.pageSize);
        //             console.log(this.productData);
        //         })
        //         .catch(error => {
        //             console.error('Lỗi khi tìm kiếm sản phẩm:', error);
        //         });
        // }



    },
    mounted() {
        // this.loadProductData();
        console.log(this.totalPages);
        this.fetchRoutes();
        //load Modal
        // this.ProductModal = new Modal(this.$refs.ProductModal);
    }
}
</script>
<style scoped>
/* @import url("/public/login.css"); */
</style>
