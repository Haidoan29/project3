<template>
    <div>
        <!-- <h1>footers</h1> -->
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Danh sách khách hàng</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">

                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/customer/add-customer" title="Thêm"><i
                                            class="fas fa-plus"></i>
                                        Tạo mới khách hàng</a>
                                </div>

                                <div class="col-sm-2">
                                    <a class="btn btn-delete btn-sm" type="button" title="Xóa"
                                        onclick="myFunction(this)"><i class="fas fa-trash-alt"></i> Xóa tất cả </a>
                                </div>
                                <div class=" d-flex">
                                    <form @submit.prevent="onSearchClick" class="form-input d-flex">
                                        <input class="form-control" style="margin-right: 5px;" type="search"
                                            placeholder="Search..." v-model="searchKeyword">
                                        <button type="submit" class="btn" style="background-color: #27ad15;"
                                            @click="onSearchClick()"><i class="fa fa-search"></i></button>
                                    </form>
                                </div>

                            </div>

                            <table class="table table-hover table-bordered js-copytextarea" cellpadding="0"
                                cellspacing="0" border="0" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th width="10"><input width="10" type="checkbox" id="all"></th>
                                        <th with="10">Mã khách hàng</th>
                                        <th width="150">Họ và tên</th>
                                        <th width="20">email</th>
                                        <th width="30">phone</th>
                                        <th with="40">cccd</th>
                                        <th with="150">address</th>

                                        <th width="200">Tính năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="p in productData" :key="p.id">
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <td>{{ p.id }}</td>
                                        <td>{{ p.name }}</td>

                                        <td>{{ p.email }}</td>
                                        <td>{{ p.phone }}</td>
                                        <td>{{ p.cccd }}</td>
                                        <td>{{ p.address }}</td>

                                        <!-- <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-warning"
                                                    @click="onUpdateClick(p)">Update</button>
                                                <button type="button" class="btn btn-danger">Delete</button>
                                            </div>
                                        </td> -->
                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">

                                                <button type="button" class="btn btn-warning" title="Sửa" id="show-emp"
                                                    data-toggle="modal" data-target="#ModalUP"
                                                    style="margin-right: 5px ; width: 75px"
                                                    @click=" onUpdateClick(p)"><i class="fas fa-edit"></i></button>
                                                <button type="button" title="Xóa" class="btn btn-danger"
                                                    style="width: 75px;" @click="onDelete(p.id)"> <i
                                                        class="fas fa-trash-alt"></i>
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
                        <!-- Modal -->
                        <div class="modal" ref="customerModal" id="customerModal" tabindex="-1"
                            aria-labelledby="exampleModalLabel">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Modal title</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal"
                                            aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <form>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">Họ và tên</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.name">
                                            </div>
                                            <!-- <div class="form-group">
                                <label for="imageProduct" class="col-form-label">Product Image:</label>
                                <input type="file" class="form-control" id="imageProduct" @change="onFileChange">
                            </div> -->
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">email:</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.email">
                                            </div>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">phone:</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.phone">
                                            </div>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">CCCD:</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.cccd">
                                            </div>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">address:</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.address">
                                            </div>

                                        </form>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary"
                                            data-bs-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-primary" @click="onSaveClick()">Save
                                            changes</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--MODAL-->
                        <!--modal delete-->
                        <div class="modal" ref="deleteModal" id="deleteModal" tabindex="-1"
                            aria-labelledby="exampleModalLabel">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Modal title</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal"
                                            aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <p>Bạn có chắc chắn muốn xóa ?</p>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary"
                                            data-bs-dismiss="modal">Đóng</button>
                                        <button type="button" class="btn btn-primary" @click="onDeleteClick()">Đồng
                                            ý</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--End modal delete-->
                    </div>
                </div>
            </div>
        </main>

    </div>
</template>

<script>
import axios from 'axios';
import { Modal } from 'bootstrap';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
export default {
    name: 'EmployeeCustomer',

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
            productData: [],
            customerModal: null,
            deleteModal: null,
            currentProduct: {
                id: 0,
                name: "Name",

            },
            searchKeyword: '',
            currentPage: 1, // Trang hiện tại
            pageSize: 6,   // Kích thước trang (số lượng sản phẩm trên mỗi trang)
            totalItems: 0,  // Tổng số sản phẩm
            totalPages: 0,
        }
    },
    methods: {
        loadProductData() {
            var url = process.env.VUE_APP_BASE_URL + `Customer/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.productData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát productData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.productData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Customer/Update`;

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
            this.loadProductData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadProductData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadProductData();
            }
        },
        onCreateClick() {
            this.currentProduct = {
                id: 0,
                className: "Name",

            }
            if (this.customerModal && this.customerModal.show) {
                this.customerModal.show();
            } else {
                console.error("someObject không tồn tại hoặc thuộc tính show không tồn tại");
            }
        },
        onUpdateClick(p) {
            this.currentProduct = Object.assign({}, p);// clone d
            this.customerModal.show();
        },

        onDeleteClick() {
            var url = process.env.VUE_APP_BASE_URL + `Customer/Delete/${this.delete}`; // Thay đổi đường dẫn API delete và thêm id của trạm cần xóa

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
                        this.loadProductData();
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
        onDelete(id) {
            this.delete = id
            console.log(this.delete)
            this.deleteModal.show();
        },
        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },


        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadProductData();
            } else {
                var url = process.env.VUE_APP_BASE_URL + `Customer/FullFilter`;
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



    },
    mounted() {
        this.loadProductData();
        console.log(this.totalPages);
        //load Modal
        this.customerModal = new Modal(this.$refs.customerModal);
        this.deleteModal = new Modal(this.$refs.deleteModal);
    }
}
</script>