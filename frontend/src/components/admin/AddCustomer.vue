<template>
    <div id="login">
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Thêm khách mới</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/customer" title="Thêm"><i
                                            class="fa fa-chevron-left"></i>Quay lại</a>
                                    <!-- <button class="btn btn-success" @click="onCreateClick()">Quay lại</button> -->
                                </div>

                            </div>
                            <div class="modal-body">
                                <form>
                                    <!-- <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Mã khách hàng:</label>
                                        <input type="text" class="form-control" id="recipient-name">
                                    </div> -->

                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Họ và tên:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentProduct.name">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label"> email:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentProduct.email">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label"> phone:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentProduct.phone">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label"> cccd:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentProduct.cccd">
                                    </div>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label"> address:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentProduct.address">
                                    </div>


                                    <button type="button" style=" width: 100px;height: 30px; font-size: 15px;"
                                        class="btn btn-primary" @click="onSaveClick()">Thêm Khách hàng</button>
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
            customerData: [],
            currentProduct: {
                id: 0,
                name: "Name",
                email: "abc@gmail.com",
                phone: "phone",
                cccd: "cccd",
                address: "address"
            },

        }
    },
    methods: {
        onSaveClick() {
            if (this.currentProduct.id == 0) {
                var url = process.env.VUE_APP_BASE_URL + `Customer/Create`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');
                if (!token) {
                    console.error('Token không tồn tại.');
                    return;
                }

                console.log('Dữ liệu gửi lên:', this.currentProduct);

                axios.post(url, this.currentProduct, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                })
                    .then((response) => {
                        console.log(response.data);

                        // Hiển thị thông báo thành công
                        this.success();
                        setTimeout(() => {
                            window.location.href = '/admin/customer'; // Thay đổi URL chuyển hướng tùy ý
                        }, 2000); // Đợi 3 giây trước khi chuyển hướng

                        // // Ẩn modal
                        // this.ProductModal.hide();

                        // Tải lại dữ liệu sản phẩm
                        this.loadProductData();
                    })
                    .catch((error) => {
                        if (error.response && error.response.data) {
                            console.log('Lỗi từ server:', error.response.data);
                            // Xử lý lỗi ở đây
                        } else {
                            console.log('Lỗi không xác định:', error);
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
        //             this.customerData.imageProduct = e.target.result;
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
