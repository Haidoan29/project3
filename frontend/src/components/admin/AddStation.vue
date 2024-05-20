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
                                        <label for="recipient-name" class="col-form-label">Mã nhà ga:</label>
                                        <input type="text" class="form-control" id="recipient-name">
                                    </div>
                                    <!-- <div class="form-group">
                                        <label for="imageProduct" class="col-form-label">Product Image:</label>
                                        <input type="file" class="form-control" id="imageProduct"
                                            @change="onFileChange">
                                    </div> -->
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Tên nhà ga:</label>
                                        <input type="text" class="form-control" id="recipient-name">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Tên Khu vực:</label>
                                        <input type="text" class="form-control" id="recipient-name">
                                    </div>
                                    <button type="button" style=" width: 100px;height: 30px; font-size: 15px;"
                                        class="btn btn-primary">Thêm tàu</button>
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
            currentProduct: {
                id: 0,
                className: "Name",

            },

        }
    },
    methods: {
        onSaveClick() {
            if (this.currentProduct.id == 0) {
                var url = process.env.VUE_APP_BASE_URL + `Class/Create`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');

                axios.post(url, this.currentProduct, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                })
                    .then((response) => {
                        console.log(response.data);

                        // Hiển thị thông báo thành công
                        this.success();

                        // Ẩn modal
                        this.ProductModal.hide();

                        // Tải lại dữ liệu sản phẩm
                        this.loadProductData();
                    })
                    .catch((error) => {
                        if (error.response && error.response.data) {
                            console.log(error.response.data);
                            // Xử lý lỗi ở đây
                        } else {
                            console.log('Lỗi không xác định:', error);
                        }
                    });
            }
            // else {
            //     var url1 = process.env.VUE_APP_BASE_URL + `Class/Update`;

            //     // Lấy token từ local storage
            //     const token = localStorage.getItem('token');
            //     axios.put(url1, this.currentProduct, {
            //         headers: {
            //             'Authorization': `Bearer ${token}`
            //         }
            //     })
            //         .then((response) => {
            //             console.log(response.data);
            //             // Hiển thị thông báo thành công
            //             this.success();
            //             // Ẩn modal
            //             this.ProductModal.hide();
            //             // Tải lại dữ liệu sản phẩm
            //             this.loadProductData();
            //         })
            //         .catch((error) => {
            //             console.log('Lỗi Axios:', error);
            //             if (error.response) {
            //                 console.log('Phản hồi từ server:', error.response.data);
            //                 if (error.response.status === 401) {
            //                     console.log('Token hết hạn hoặc không hợp lệ.');
            //                     // Xử lý token hết hạn ở đây
            //                 }
            //             }
            //         });

            // }

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
        //             this.currentProduct.imageProduct = e.target.result;
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
        //load Modal
        // this.ProductModal = new Modal(this.$refs.ProductModal);
    }
}
</script>
<style scoped>
/* @import url("/public/login.css"); */
</style>
