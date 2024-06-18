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

                                    <a class="btn btn-add btn-sm" href="/admin/train/add-train" title="Thêm"><i
                                            class="fas fa-plus"></i>
                                        Tạo mới tàu</a>
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
                                        <th width="200">Số lượng ghế hạng AC3 </th>
                                        <th width="200">Số lượng ghế hạng First Class</th>
                                        <th width="200">Số lượng ghế hạng Sleeper</th>

                                        <th width="200">Tuyến đường</th>

                                        <th width="200">Tính năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="t in trainData" :key="t.id">
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <td>{{ t.id }}</td>
                                        <td>{{ t.trainName }}</td>
                                        <td>{{ t.numCoachesAC3 }}</td>
                                        <td>{{ t.numCoachesFirstClass }}</td>
                                        <td>{{ t.numCoachesSleeper }}</td>
                                        <td>{{ getRouteName(t.routeID) }}</td>
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
                                <label for="recipient-name" class="col-form-label">Tên tàu:</label>
                                <input type="text" class="form-control" id="recipient-name"
                                    v-model="currentTrain.trainName">
                            </div>

                            <div class="form-group">
                                <label for="recipient-name" class="col-form-label">Số lượng ghế hạng AC3:</label>
                                <input type="number" class="form-control" id="recipient-name"
                                    v-model="currentTrain.numCoachesAC3">
                            </div>
                            <div class="form-group">
                                <label for="recipient-name" class="col-form-label">Số lượng ghế hạng First Class</label>
                                <input type="number" class="form-control" id="recipient-name"
                                    v-model="currentTrain.numCoachesFirstClass">
                            </div>
                            <div class="form-group">
                                <label for="recipient-name" class="col-form-label">Số lượng ghế hạng Sleeper</label>
                                <input type="number" class="form-control" id="recipient-name"
                                    v-model="currentTrain.numCoachesSleeper">
                            </div>
                            <div class="form-group">
                                <div>
                                    <label for="startStationID" class="col-form-label">Tuyến đường:</label>
                                </div>
                                <div>
                                    <select class="form-select form-select-lg mb-3 col-form-label"
                                        v-model="currentTrain.routeID" required>
                                        <option disabled value="">Chọn tuyến đường</option>
                                        <option v-for="r in routes" :key="r.id" :value="r.id">{{ r.routeName }}
                                        </option>
                                    </select>
                                </div>
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

    data() {
        return {
            trainData: [],
            trainModal: null,
            deleteModal: null,

            routes: [],
            currentTrain: {
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
        fetchtrains() {
            const stationApiUrl = process.env.VUE_APP_BASE_URL + `Routes/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(stationApiUrl)
                .then(response => response.json())
                .then(data => {
                    this.routes = data;
                })
                .catch(error => {
                    console.error('Error fetching trains:', error);
                });
        },
        loadtrainData() {
            var url = process.env.VUE_APP_BASE_URL + `Train/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.trainData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát trainData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.trainData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Train/Update`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.put(url, this.currentTrain, {
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
                    if (typeof this.loadtrainData === 'function') {
                        this.loadtrainData();
                    } else {
                        console.log('Hàm loadtrainData không tồn tại.');
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

        getRouteName(id) {
            if (!this.routes) return 'Unknown';
            const route = this.routes.find(r => r.id === id);
            return route ? route.routeName : 'Unknown';
        },


        changePage(page) {
            this.currentPage = page;
            this.loadtrainData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadtrainData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadtrainData();
            }
        },
        onDeleteClick() {

            var url = process.env.VUE_APP_BASE_URL + `Train/Delete/${this.delete}`; // Thay đổi đường dẫn API delete và thêm id của trạm cần xóa

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
                        this.loadtrainData();
                    } else {
                        console.log('DeleteModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu trạm
                    if (typeof this.loadtrainData === 'function') {
                        this.loadtrainData();
                    } else {
                        console.log('Hàm loadtrainData không tồn tại.');
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
            this.currentTrain = Object.assign({}, t);// clone d
            this.trainModal.show();
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadProductData();
            } else {
                var url = process.env.VUE_APP_BASE_URL + `Train/FullFilter`;
                var requestData = {
                    filterRequests: [
                        {
                            colName: "name",
                            _operator: "like",
                            _RightSize: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.productData = response.data;
                        this.totalItems = this.productData.length;
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
        this.loadtrainData();
        console.log(this.totalPages);
        this.fetchtrains();
        //load Modal
        this.trainModal = new Modal(this.$refs.trainModal);
        this.deleteModal = new Modal(this.$refs.deleteModal);
    }

}
</script>