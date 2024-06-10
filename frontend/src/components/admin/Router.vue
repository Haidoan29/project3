<template>
    <div>



        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="/admin/router"><b>Danh sách tuyến đường</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/router/add-router" title="Thêm"><i
                                            class="fas fa-plus"></i>
                                        Tạo mới tuyến đường</a>
                                </div>

                                <div class="col-sm-2">
                                    <a class="btn btn-delete btn-sm" type="button" title="Xóa"
                                        onclick="myFunction(this)"><i class="fas fa-trash-alt"></i> Xóa tất cả </a>
                                </div>
                            </div>
                            <table class="table table-hover table-bordered" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <th>Id</th>
                                        <th>Tên thuyến đường</th>
                                        <th>Ga xuất phát</th>
                                        <th>Ga kết thúc</th>
                                        <th>Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="p in routerData" :key="p.id">
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <td>{{ p.id }}</td>
                                        <td>{{ p.routeName }}</td>

                                        <td>{{ getStationName(p.startStationID) }}</td>
                                        <td>{{ getStationName(p.endStation) }}</td>
                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-warning"
                                                    @click="onUpdateClick(p)">Update</button>
                                                <button type="button" class="btn btn-danger"
                                                    @click="onDelete()">Delete</button>
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


            <!-- Modal -->
            <div class="modal" ref="stationModal" id="stationModal" tabindex="-1" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modal title</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <form>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Mã nhà ga:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentRouter.stationCode">
                                </div>

                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Tên nhà ga:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentRouter.stationName">
                                </div>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Khu vực:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentRouter.divisionName">
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
            <!--modal delete-->
            <div class="modal" ref="deleteModal" id="deleteModal" tabindex="-1" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modal title</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <p>Modal body text goes here.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--End modal delete-->
        </main>
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
    name: "StationS",
    components: {
        // eslint-disable-next-line vue/no-unused-components
        Modal, toast
    },

    data() {
        return {
            routerData: [],
            stationModal: null,
            deleteModal: null,
            stationData: [],
            stations: [],
            currentRouter: {
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
        loadrouterData() {
            var url = process.env.VUE_APP_BASE_URL + `Routes/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.routerData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát routerData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.routerData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Station/Update`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.put(url, this.currentRouter, {
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
                    if (this.stationModal && typeof this.stationModal.hide === 'function') {
                        this.stationModal.hide();
                    } else {
                        console.log('stationModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu sản phẩm
                    if (typeof this.loadrouterData === 'function') {
                        this.loadrouterData();
                    } else {
                        console.log('Hàm loadrouterData không tồn tại.');
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

        getStationName(id) {
            const station = this.stations.find(station => station.id === id);
            return station ? station.stationName : 'Unknown';
        },
        changePage(page) {
            this.currentPage = page;
            this.loadrouterData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadrouterData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadrouterData();
            }
        },
        onDeleteClick() {
            var url = process.env.VUE_APP_BASE_URL + `Station/Delete/${this.currentStation.id}`; // Thay đổi đường dẫn API delete và thêm id của trạm cần xóa

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
                    } else {
                        console.log('DeleteModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu trạm
                    if (typeof this.loadstationData === 'function') {
                        this.loadstationData();
                    } else {
                        console.log('Hàm loadstationData không tồn tại.');
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
        onDelete() {
            this.deleteModal.show();
        },

        onUpdateClick(p) {
            this.currentRouter = Object.assign({}, p);// clone d
            this.stationModal.show();
        },

        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },
    },
    mounted() {
        this.loadrouterData();
        console.log(this.totalPages);
        this.fetchStations();
        //load Modal
        this.stationModal = new Modal(this.$refs.stationModal);
        this.deleteModal = new Modal(this.$refs.deleteModal);
    }

}
</script>