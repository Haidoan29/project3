<template>
    <div>
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Danh sách hạng ghế</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/class/add-class" title="Thêm"><i
                                            class="fas fa-plus"></i>
                                        Tạo hạng ghế</a>
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
                                        <th>ID</th>
                                        <th>Hạng ghế</th>
                                        <th>Tính năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="o in classData" :key="o.id">
                                        <td width="10"><input type="checkbox" name="check1" value="1"></td>
                                        <td>{{ o.id }}</td>

                                        <td>{{ o.className }}</td>



                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button class="btn btn-primary btn-sm edit" type="button" title="Sửa"
                                                    id="show-emp" data-toggle="modal" data-target="#ModalUP"
                                                    style="margin-right: 5px ;" @click="onUpdateClick(o)"><i
                                                        class="fas fa-edit"></i></button>
                                                <button class="btn btn-primary btn-sm trash" type="button" title="Xóa"
                                                    @click="onDelete(o.id)"><i class="fas fa-trash-alt"></i>
                                                </button>

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
            <div class="modal" ref="seatModal" id="seatModal" tabindex="-1" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modal title</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <form>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Hạng Ghế
                                    </label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentClass.className">
                                </div>


                            </form>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" @click="onSaveClick()">Save
                                changes</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--MODAL-->
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
    name: "OrDer",
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
            classData: [],
            seatModal: null,

            trains: [],
            Class: [],

            currentClass: {
                id: 0,
            },
            searchKeyword: '',
            currentPage: 1, // Trang hiện tại
            pageSize: 3,   // Kích thước trang (số lượng sản phẩm trên mỗi trang)
            totalItems: 0,  // Tổng số sản phẩm
            totalPages: 0,

        }
    },
    methods: {

        loadclassData() {
            var url = process.env.VUE_APP_BASE_URL + `Class/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.classData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát classData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.classData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Class/Update`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.put(url, this.currentClass, {
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
                    if (this.seatModal && typeof this.seatModal.hide === 'function') {
                        this.seatModal.hide();
                    } else {
                        console.log('seatModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu sản phẩm
                    if (typeof this.loadclassData === 'function') {
                        this.loadclassData();
                    } else {
                        console.log('Hàm loadclassData không tồn tại.');
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
            console.log('ID cần tìm:', id);
            const train = this.trains.find(train => train.id === id);
            console.log('Kết quả tìm kiếm:', train);
            return train ? train.trainName : 'Unknown';
        },
        getClassName(id) {
            console.log('ID cần tìm:', id);
            const classs = this.Class.find(classs => classs.id === id);
            console.log('Kết quả tìm kiếm:', classs);
            return classs ? classs.className : 'Unknown';
        },
        changePage(page) {
            this.currentPage = page;
            this.loadclassData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadclassData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadclassData();
            }
        },
        onDeleteClick() {
            var url = process.env.VUE_APP_BASE_URL + `Seat/Delete/${this.delete}`; // Thay đổi đường dẫn API delete và thêm id của trạm cần xóa

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
                        this.loadclassData();
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
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadclassData();
            } else {
                var url = process.env.VUE_APP_BASE_URL + `Class/FullFilter`;
                var requestData = {
                    filterRequests: [
                        {
                            colName: "className",
                            _operator: "like",
                            _RightSize: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.classData = response.data;
                        this.totalItems = this.classData.length;
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

        onDelete(id) {
            this.delete = id
            console.log(this.delete)
            this.deleteModal.show();
        },

        onUpdateClick(o) {
            this.currentClass = Object.assign({}, o);// clone d
            this.seatModal.show();
        },

        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },
    },
    mounted() {
        this.loadclassData();

        console.log(this.totalPages);
        // this.fetchtrain();
        //load Modal
        this.seatModal = new Modal(this.$refs.seatModal);
        this.deleteModal = new Modal(this.$refs.deleteModal);
    }

}
</script>
