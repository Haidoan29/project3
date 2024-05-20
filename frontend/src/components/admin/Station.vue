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
                            <table class="table table-hover table-bordered" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <th>Mã nhà ga</th>
                                        <th>Tên nhà ga</th>
                                        <th>Khu vực</th>
                                        <th>Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <!-- <tr v-for="p in productData" :key="p.id">
                                        <td>{{ p.id }}</td>
                                        <td>{{ p.productName }}</td>
                                        <td><img :src="p.imageProduct" width="80"></td>
                                        <td>{{ p.price }}</td>
                                        <td>{{ p.barCode }}</td>
                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-warning"
                                                    @click="onUpdateClick(p)">Update</button>
                                                <button type="button" class="btn btn-danger">Delete</button>
                                            </div>
                                        </td>
                                    </tr> -->
                                    <tr>
                                        <td width="10"><input type="checkbox" name="check1" value="1"></td>
                                        <td>HNO</td>
                                        <td>Hà Nội</td>
                                        <td>Northern Division</td>
                                        <td><button class="btn btn-primary btn-sm trash" type="button" title="Xóa"
                                                onclick="myFunction(this)"><i class="fas fa-trash-alt"></i>
                                            </button>
                                            <button class="btn btn-primary btn-sm edit" type="button" title="Sửa"
                                                id="show-emp" data-toggle="modal" data-target="#ModalUP"
                                                @click="onCreateClick()"><i class="fas fa-edit"></i></button>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10"><input type="checkbox" name="check1" value="1"></td>
                                        <td>DNG</td>
                                        <td>Đà Nẵng</td>
                                        <td>Central Division</td>
                                        <td><button class="btn btn-primary btn-sm trash" type="button" title="Xóa"
                                                onclick="myFunction(this)"><i class="fas fa-trash-alt"></i>
                                            </button>
                                            <button class="btn btn-primary btn-sm edit" type="button" title="Sửa"
                                                id="show-emp" data-toggle="modal" data-target="#ModalUP"><i
                                                    class="fas fa-edit"></i></button>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10"><input type="checkbox" name="check1" value="1"></td>
                                        <td>SGN</td>
                                        <td>Sài Gòn</td>
                                        <td>Southern Division</td>
                                        <td><button class="btn btn-primary btn-sm trash" type="button" title="Xóa"
                                                onclick="myFunction(this)"><i class="fas fa-trash-alt"></i>
                                            </button>
                                            <button class="btn btn-primary btn-sm edit" type="button" title="Sửa"
                                                id="show-emp" data-toggle="modal" data-target="#ModalUP"><i
                                                    class="fas fa-edit"></i></button>

                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Button trigger modal -->
            <!-- <div class="control-box">
                <button class="btn btn-success" @click="onCreateClick()">Create</button>
            </div> -->

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
                                    <label for="recipient-name" class="col-form-label">Product Name:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentProduct.productName">
                                </div>
                                <div class="form-group">
                                    <label for="imageProduct" class="col-form-label">Product Image:</label>
                                    <input type="file" class="form-control" id="imageProduct" @change="onFileChange">
                                </div>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Price:</label>
                                    <input type="number" class="form-control" id="recipient-name"
                                        v-model="currentProduct.price">
                                </div>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Bar Code:</label>
                                    <input type="text" class="form-control" id="recipient-name"
                                        v-model="currentProduct.barCode">
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </div>
</template>

<script>
// import axios from 'axios';
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
            productData: [],
            stationModal: null,
            currentProduct: {
                id: 0,
                productName: "Name",
                imageProduct: "Image",
                price: 0,
                barCode: "Bar Code"
            },

        }
    },
    methods: {
        onCreateClick() {
            this.currentProduct = {
                id: 0,
                productName: "Name",
                imageProduct: "",
                price: 0,
                barCode: "Bar Code"
            }
            if (this.stationModal && this.stationModal.show) {
                this.stationModal.show();
            } else {
                console.error("someObject không tồn tại hoặc thuộc tính show không tồn tại");
            }
        },
        onUpdateClick(p) {
            this.currentProduct = Object.assign({}, p);// clone d
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
        // this.loadProductData();
        console.log(this.totalPages);
        //load Modal
        this.stationModal = new Modal(this.$refs.stationModal);
    }

}
</script>