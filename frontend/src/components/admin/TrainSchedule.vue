<template>
    <div>
        <!-- <h1>footers</h1> -->
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="/admin/train"><b>Danh sách tàu</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">

                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/TrainSchedule/add-AddTrainSchedule"
                                        title="Thêm"><i class="fas fa-plus"></i>
                                        Tạo lịch mới</a>
                                </div>
                            </div>
                            <div class=" d-flex">
                                <form @submit.prevent="onSearchClick" class="form-input d-flex">
                                    <input class="form-control" style="margin-right: 5px;" type="search"
                                        placeholder="Search..." v-model="searchKeyword">
                                    <button type="submit" class="btn" style="background-color: #27ad15;"
                                        @click="onSearchClick()"><i class="fa fa-search"></i></button>
                                </form>
                            </div>
                            <table class="table table-hover table-bordered js-copytextarea" cellpadding="0"
                                cellspacing="0" border="0" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <th with="50">ID</th>
                                        <th with="50">Tên tàu</th>
                                        <th width="200">Ga bắt đầu </th>
                                        <th width="200">Ga kết thúc</th>
                                        <th width="200">Thời gian đi </th>
                                        <th width="200">Thời gian đến </th>


                                        <th width="200">Tính năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="t in trainScheduleData" :key="t.id">
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <td>{{ t.id }}</td>
                                        <td>{{ getTrainName(t.trainID) }}</td>
                                        <td>{{ getStationName(t.startStationID) }}</td>
                                        <td>{{ getStationName(t.endStationID) }}</td>
                                        <td>{{ formatDate(t.departureTime) }}</td>
                                        <td>{{ formatDate(t.arrivalTime) }}</td>

                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-warning"
                                                    style="margin-right: 5px ;" @click=" onUpdateClick(t)"><i class="fas
                                                    fa-edit"></i>Update</button>
                                                <button type="button" class="btn btn-danger" @click="onDelete(t.id)"><i
                                                        class="fas fa-trash-alt"></i>Delete</button>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                                <div class="khoi-phan-trang">
                                    <nav aria-label="Page navigation example">
                                        <ul class="pagination">
                                            <li class="page-item">
                                                <a class="page-link" href="#" aria-label="Previous"
                                                    @click="previousPage">
                                                    <span aria-hidden="true">&laquo;</span>
                                                </a>
                                            </li>
                                            <li class="page-item" v-for="page in totalPages" :key="page">
                                                <a class="page-link" href="#" @click="changePage(page)">{{ page }}</a>
                                            </li>
                                            <li class="page-item">
                                                <a class="page-link" href="#" aria-label="Next" @click="nextPage">
                                                    <span aria-hidden="true">&raquo;</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <!-- Modal -->
        <div class="modal" ref="trainModal" id="trainModal" tabindex="-1" aria-labelledby="exampleModalLabel">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Modal title</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <div>
                                    <label for="startStationID" class="col-form-label">Tàu:</label>
                                </div>
                                <div>
                                    <select class="form-select form-select-lg mb-3 col-form-label"
                                        v-model="currentTrainSchedule.trainID" required>
                                        <option disabled value="">Chọn tàu</option>
                                        <option v-for="r in train" :key="r.id" :value="r.id">{{ r.trainName }}
                                        </option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <div>
                                    <label for="startStationID" class="col-form-label">Ga xuất phát:</label>
                                </div>
                                <div>
                                    <select class="form-select form-select-lg mb-3 col-form-label"
                                        v-model="currentTrainSchedule.startStationID" required>
                                        <option disabled value="">Chọn ga xuất phát</option>
                                        <option v-for="r in station" :key="r.id" :value="r.id">{{ r.stationName }}
                                        </option>
                                    </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <div>
                                    <label for="startStationID" class="col-form-label">Ga kết thúc:</label>
                                </div>
                                <div>
                                    <select class="form-select form-select-lg mb-3 col-form-label"
                                        v-model="currentTrainSchedule.endStationID" required>
                                        <option disabled value="">Chọn ga kết thúc</option>
                                        <option v-for="r in station" :key="r.id" :value="r.id">{{ r.stationName }}
                                        </option>
                                    </select>
                                </div>
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

                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" @click="onSaveClick()">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <!--modal delete-->
        <div class="modal" ref="deleteModal" id="deleteModal" tabindex="-1" aria-labelledby="exampleModalLabel">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Modal title</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>Bạn có chắc chắn muốn xóa ?</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Đóng</button>
                        <button type="button" class="btn btn-primary" @click="onDeleteClick()">Đồng ý</button>
                    </div>
                </div>
            </div>
        </div>
        <!--End modal delete-->


    </div>
</template>

<script>
import axios from 'axios';
import { Modal } from 'bootstrap';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
// Import JavaScript
// import '@/assets/js/scripts';
// import { RouterLink } from 'vue-router';

export default {
    name: "TrainS",
    components: {
        // eslint-disable-next-line vue/no-unused-components
        Modal, toast
    },
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
            trainScheduleData: [],
            trainModal: null,
            deleteModal: null,

            train: [],
            station: [],
            currentTrainSchedule: {
                id: 0,
                stationCode: "stationCode",
                // stationName: "",
                // divisionName: ""
            },

            searchKeyword: '',
            currentPage: 1, // Trang hiện tại
            pageSize: 3,   // Kích thước trang (số lượng sản phẩm trên mỗi trang)
            totalItems: 0,  // Tổng số sản phẩm
            totalPages: 0,

        }
    },


    methods: {
        formatDate(dateTimeString) {
            const date = new Date(dateTimeString);
            const options = {
                year: "numeric",
                month: "2-digit",
                day: "2-digit",
                // hour: '2-digit',
                // minute: '2-digit',
                hour12: false // Sử dụng định dạng 24 giờ, bạn có thể bỏ nếu muốn dùng định dạng 12 giờ
            };
            const options1 = {
                // year: "numeric",
                // month: "2-digit",
                // day: "2-digit",
                hour: '2-digit',
                minute: '2-digit',
                hour12: false // Sử dụng định dạng 24 giờ, bạn có thể bỏ nếu muốn dùng định dạng 12 giờ
            };

            // Chuyển đổi ngày giờ thành chuỗi theo định dạng vi-VN
            const dateString = date.toLocaleDateString("vi-VN", options);
            const timeString = date.toLocaleTimeString("vi-VN", options1);

            return `${dateString} ${timeString}`;
        },
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
        loadtrainScheduleData() {
            var url = process.env.VUE_APP_BASE_URL + `TrainSchedule/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.trainScheduleData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát trainScheduleData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.trainScheduleData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `TrainSchedule/Update`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.put(url, this.currentTrainSchedule, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
                .then((response) => {
                    console.log(response.data);
                    // Hiển thị thông báo thành công
                    if (typeof this.success === 'function') {
                        this.success();
                    } else {
                        console.log('Hàm success không tồn tại.');
                    }
                    // Ẩn modal
                    if (this.trainModal && typeof this.trainModal.hide === 'function') {
                        this.trainModal.hide();
                    } else {
                        console.log('trainModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu sản phẩm
                    if (typeof this.loadtrainScheduleData === 'function') {
                        this.loadtrainScheduleData();
                    } else {
                        console.log('Hàm loadtrainScheduleData không tồn tại.');
                    }
                })
                .catch((error) => {
                    console.log('Lỗi Axios:', error);
                    if (error.response) {
                        console.log('Phản hồi từ server:', error.response.data);
                        if (error.response.status === 401) {
                            console.log('Token hết hạn hoặc không hợp lệ.');
                            // Xử lý token hết hạn ở đây
                        }
                    }
                });
        },

        getTrainName(id) {
            if (!this.train) return 'Unknown';
            const trains = this.train.find(r => r.id === id);
            return trains ? trains.trainName : 'Unknown';
        },
        getStationName(id) {
            if (!this.station) return 'Unknown';
            const stations = this.station.find(r => r.id === id);
            return stations ? stations.stationName : 'Unknown';
        },


        changePage(page) {
            this.currentPage = page;
            this.loadtrainScheduleData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadtrainScheduleData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadtrainScheduleData();
            }
        },
        onDeleteClick() {

            var url = process.env.VUE_APP_BASE_URL + `TrainSchedule/Delete/${this.delete}`; // Thay đổi đường dẫn API delete và thêm id của trạm cần xóa

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.delete(url, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
                .then((response) => {
                    console.log(response.data);
                    // Hiển thị thông báo thành công
                    if (typeof this.success === 'function') {
                        this.success();
                    } else {
                        console.log('Hàm success không tồn tại.');
                    }
                    // Ẩn modal
                    if (this.deleteModal && typeof this.deleteModal.hide === 'function') {
                        this.deleteModal.hide();
                        this.loadtrainScheduleData();
                    } else {
                        console.log('DeleteModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu trạm
                    if (typeof this.loadtrainScheduleData === 'function') {
                        this.loadtrainScheduleData();
                    } else {
                        console.log('Hàm loadtrainScheduleData không tồn tại.');
                    }
                })
                .catch((error) => {
                    console.log('Lỗi Axios:', error);
                    if (error.response) {
                        console.log('Phản hồi từ server:', error.response.data);
                        if (error.response.status === 401) {
                            console.log('Token hết hạn hoặc không hợp lệ.');
                            // Xử lý token hết hạn ở đây
                        }
                    }
                });
        },
        onDelete(id) {
            this.delete = id;
            console.log(this.delete);
            this.deleteModal.show();
        },

        onUpdateClick(t) {
            this.currentTrainSchedule = Object.assign({}, t);// clone d
            this.trainModal.show();
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadtrainScheduleData();
            } else {
                var url = process.env.VUE_APP_BASE_URL + `Train/FullFilter`;
                var requestData = {
                    filterRequests: [
                        {
                            colName: "trainName",
                            _operator: "like",
                            _RightSize: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.trainScheduleData = response.data;
                        this.totalItems = this.trainScheduleData.length;
                        this.totalPages = Math.floor(this.totalItems / this.pageSize);
                        if (this.totalItems % this.pageSize !== 0) {
                            this.totalPages++;
                        }
                        this.currentPage = 1;
                    })
                    .catch(error => {
                        console.error('Error during search:', error);
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
        this.loadtrainScheduleData();
        console.log(this.totalPages);
        this.fetchtrains();
        this.fetchStation();
        //load Modal
        this.trainModal = new Modal(this.$refs.trainModal);
        this.deleteModal = new Modal(this.$refs.deleteModal);
    }

}
</script>