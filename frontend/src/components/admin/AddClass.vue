<template>
    <div id="login">
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Thêm mới hạng ghế</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/class" title="Thêm"><i
                                            class="fa fa-chevron-left"></i>Quay lại</a>
                                    <!-- <button class="btn btn-success" @click="onCreateClick()">Quay lại</button> -->
                                </div>

                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">tên hạng ghế:</label>
                                        <input type="text" class="form-control" id="recipient-name"
                                            v-model="currentClass.ClassName">
                                    </div>



                                    <button type="button" style="width: 125px; height: 30px; font-size: 15px;"
                                        class="btn btn-primary" @click="onSaveClick()">Thêm hạng ghế</button>
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
    name: 'AddClass',


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

            currentClass: {
                ClassName: '',
            },
        }
    },
    methods: {

        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Class/Create`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');

            axios.post(url, this.currentClass, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                }
            })
                .then((response) => {
                    console.log(response.data);

                    // Hiển thị thông báo thành công
                    this.success();
                    setTimeout(() => {
                        window.location.href = '/admin/seat'; // Thay đổi URL chuyển hướng tùy ý
                    }, 2000); // Đợi 3 giây trước khi chuyển hướng
                })
                .catch((error) => {
                    if (error.response && error.response.data) {
                        console.log(error.response.data);
                        // Xử lý lỗi ở đây
                    } else {
                        console.log('Lỗi không xác định:', error);
                    }
                });
        },
        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },


    },

}
</script>
