<template>
    <div>



        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="/admin/station"><b>Danh sách nhà ga</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/station/add-station" title="Thêm"><i
                                            class="fas fa-plus"></i>
                                        Tạo mới nhà ga</a>
                                </div>

                                <div class="col-sm-2">
                                    <a class="btn btn-delete btn-sm" type="button" title="Xóa"
                                        onclick="myFunction(this)"><i class="fas fa-trash-alt"></i> Xóa tất cả </a>
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
                            <table class="table table-hover table-bordered" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <th>Id</th>
                                        <th>Mã nhà ga</th>
                                        <th>Tên nhà ga</th>
                                        <th>Khu vực</th>
                                        <th>Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="p in stationData" :key="p.id">
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <td>{{ p.id }}</td>
                                        <td>{{ p.stationCode }}</td>

                                        <td>{{ p.stationName }}</td>
                                        <td>{{ p.divisionName }}</td>
                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-warning"
                                                    style="margin-right: 5px ;" @click="onUpdateClick(p)"><i class="fas
                                                    fa-edit"></i>Update</button>
                                                <button type="button" class="btn btn-danger" @click="onDelete(p.id)"><i
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
                                        v-model="currentStation.stationCode">
                                </div>

                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Tên nhà ga:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentStation.stationName">
                                </div>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Khu vực:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentStation.divisionName">
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
                            <p>Bạn có chắc chắn muốn xóa ?</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Đóng</button>
                            <button type="button" class="btn btn-primary" @click="confirmDelete()">Đồng ý</button>
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
            stationData: [],
            stationModal: null,
            deleteModal: null,
            currentStation: {
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
        loadstationData() {
            var url = process.env.VUE_APP_BASE_URL + `Station/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.stationData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát stationData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.stationData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Station/Update`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.put(url, this.currentStation, {
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


        changePage(page) {
            this.currentPage = page;
            this.loadstationData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadstationData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadstationData();
            }
        },


        onDelete(id) {
            this.deleteid = id,
                console.log("id sp" + this.deleteid)
            this.deleteModal.show();
        },
        onUpdateClick(p) {
            this.currentStation = Object.assign({}, p);// clone truyền dữ liệu
            this.stationModal.show();
        },
        confirmDelete() {
            // Kiểm tra nếu deleteid hợp lệ
            if (this.deleteid) {
                console.log('ID đối tượng để xóa ' + this.deleteid);

            }

            // Gọi API để xóa đối tượng
            const url = process.env.VUE_APP_BASE_URL + `Station/Delete/${this.deleteid}`;
            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.delete(url, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
                .then((response) => {
                    console.log('Xóa thành công:', response.data);
                    this.deleteModal.hide();
                    // Tải lại dữ liệu sau khi xóa thành công
                    this.loadstationData();
                })
                .catch((error) => {
                    // Xử lý lỗi khi gọi API
                    if (error.response) {
                        console.error('Lỗi khi xóa đối tượng:', error.response);
                        if (error.response.status === 404) {
                            console.error('Không tìm thấy đối tượng để xóa.');
                        }
                    } else {
                        console.error('Lỗi khi xóa đối tượng:', error);
                    }
                });
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadstationData();
            } else {
                var url = process.env.VUE_APP_BASE_URL + `Station/FullFilter`;
                var requestData = {
                    filterRequests: [
                        {
                            colName: "stationName",
                            _operator: "like",
                            _RightSize: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.stationData = response.data;
                        this.totalItems = this.stationData.length;
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
        this.loadstationData();
        console.log(this.totalPages);
        //load Modal
        this.stationModal = new Modal(this.$refs.stationModal);
        this.deleteModal = new Modal(this.$refs.deleteModal)
    }

}
</script>