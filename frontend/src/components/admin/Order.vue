<template>
    <div>
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Danh sách vé</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">
                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <a class="btn btn-add btn-sm" href="/admin/order/add-order" title="Thêm"><i
                                            class="fas fa-plus"></i>
                                        Tạo mới vé</a>
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
                                        <th>Mã Đặt Vé (PRNNo)</th>
                                        <th>Tàu</th>
                                        <th>Khách Hàng</th>

                                        <th>Số Ghế</th>
                                        <th>Phí Đặt Vé</th>
                                        <th>Tính năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="o in orderData" :key="o.id">
                                        <td width="10"><input type="checkbox" name="check1" value="1"></td>
                                        <td>{{ o.id }}</td>
                                        <td>{{ o.prnNo }}</td>
                                        <td>{{ getTrainName(o.trainID) }}</td>
                                        <td>{{ getCustomerName(o.customerID) }}</td>
                                        <td>{{ getSeatName(o.seatID) }}</td>
                                        <td>{{ getFareRuleName(o.fareRuleID) }}</td>


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
            <div class="modal" ref="orderModal" id="orderModal" tabindex="-1" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modal title</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <form>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Tàu</label>
                                    <div>
                                        <select class="form-select form-select-lg mb-3" v-model="currentOrder.trainID"
                                            required>
                                            <option disabled value="">Chọn ga xuất phát</option>
                                            <option v-for="t in trains" :key="t.id" :value="t.id">{{ t.trainName }}
                                            </option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Số ghế :</label>
                                    <div>
                                        <select class="form-select form-select-lg mb-3" v-model="currentOrder.seatID"
                                            required>
                                            <option disabled value="">Chọn ga xuất phát</option>
                                            <option v-for="s in seat" :key="s.id" :value="s.id">{{ s.seatNo }}
                                            </option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="recipient-name" class="col-form-label">Giá vé :</label>
                                    <div>
                                        <select class="form-select form-select-lg mb-3"
                                            v-model="currentOrder.fareRuleID" required>
                                            <option disabled value="">Chọn ga xuất phát</option>
                                            <option v-for="f in fareRule" :key="f.id" :value="f.id">{{ f.fare }}
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
            orderData: [],
            orderModal: null,
            stations: [],
            trains: [],
            customer: [],
            seat: [],
            fareRule: [],
            currentOrder: {
                id: 0,
                prnNo: "",
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
        fetchTrain() {
            const url = process.env.VUE_APP_BASE_URL + `Train/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.trains = data;
                })
                .catch(error => {
                    console.error('Error fetching train:', error);
                });
        },
        fetchCustomer() {
            const url = process.env.VUE_APP_BASE_URL + `Customer/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.customer = data;
                })
                .catch(error => {
                    console.error('Error fetching customer:', error);
                });
        },
        fetchSeat() {
            const url = process.env.VUE_APP_BASE_URL + `Seat/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.seat = data;
                })
                .catch(error => {
                    console.error('Error fetching seat:', error);
                });
        },
        fetchFareRule() {
            const url = process.env.VUE_APP_BASE_URL + `FareRule/GetAll`; // Thay thế bằng API thực tế của bạn

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.fareRule = data;
                })
                .catch(error => {
                    console.error('Error fetching fareRule:', error);
                });
        },
        loadorderData() {
            var url = process.env.VUE_APP_BASE_URL + `Transaction/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.orderData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát orderData để chỉ lấy số lượng sản   phẩm tương ứng với pageSize
                this.orderData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSaveClick() {
            var url = process.env.VUE_APP_BASE_URL + `Transaction/Update`;

            // Lấy token từ local storage
            const token = localStorage.getItem('token');
            axios.put(url, this.currentOrder, {
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
                    if (this.orderModal && typeof this.orderModal.hide === 'function') {
                        this.orderModal.hide();
                    } else {
                        console.log('orderModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu sản phẩm
                    if (typeof this.loadorderData === 'function') {
                        this.loadorderData();
                    } else {
                        console.log('Hàm loadorderData không tồn tại.');
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
        getTrainName(id) {
            const train = this.trains.find(train => train.id === id);

            return train ? train.trainName : 'Unknown';
        },
        getCustomerName(id) {
            const customers = this.customer.find(customers => customers.id === id);

            return customers ? customers.name : 'Unknown';
        },
        getSeatName(id) {
            const seats = this.seat.find(seats => seats.id === id);

            return seats ? seats.seatNo : 'Unknown';
        },
        getFareRuleName(id) {
            const fareRules = this.fareRule.find(fareRules => fareRules.id === id);

            return fareRules ? fareRules.fare : 'Unknown';
        },
        changePage(page) {
            this.currentPage = page;
            this.loadorderData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadorderData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadorderData();
            }
        },
        onDeleteClick() {
            var url = process.env.VUE_APP_BASE_URL + `Transaction/Delete/${this.delete}`; // Thay đổi đường dẫn API delete và thêm id của trạm cần xóa

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
                        this.loadorderData();
                    } else {
                        console.log('DeleteModal hoặc hàm hide không tồn tại.');
                    }
                    // Tải lại dữ liệu trạm
                    if (typeof this.loadorderData === 'function') {
                        this.loadorderData();
                    } else {
                        console.log('Hàm loadorderData không tồn tại.');
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
                this.loadorderData();
            } else {
                var url = process.env.VUE_APP_BASE_URL + `Transaction/FullFilter`;
                var requestData = {
                    filterRequests: [
                        {
                            colName: "prnNo",
                            _operator: "like",
                            _RightSize: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.orderData = response.data;
                        this.totalItems = this.orderData.length;
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
            this.currentOrder = Object.assign({}, o);// clone d
            this.orderModal.show();
        },

        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },
    },
    mounted() {
        this.loadorderData();
        console.log(this.totalPages);
        this.fetchStations();
        this.fetchTrain();
        this.fetchCustomer();
        this.fetchSeat();
        this.fetchFareRule();
        //load Modal
        this.orderModal = new Modal(this.$refs.orderModal);
        this.deleteModal = new Modal(this.$refs.deleteModal);
    }

}
</script>