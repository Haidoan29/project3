<template>
    <header class="app-header">
        <!-- Sidebar toggle button--><a class="app-sidebar__toggle" href="#" data-toggle="sidebar"
            aria-label="Hide Sidebar"></a>
        <!-- Navbar Right Menu-->
        <ul class="app-nav">


            <!-- User Menu-->

            <li style="color: aliceblue;" @click="logouts">
                <i class="fas fa-sign-out-alt"></i>
                Logout
            </li>
        </ul>
        ``

    </header>
    <!-- Sidebar menu-->
    <div class="app-sidebar__overlay" data-toggle="sidebar"></div>
    <aside class="app-sidebar">
        <div class="app-sidebar__user"><img class="app-sidebar__user-avatar" src="../../assets/img/team.jpg"
                width="50px" alt="User Image">
            <div>
                <p class="app-sidebar__user-name"><b>Admin </b></p>
                <p class="app-sidebar__user-designation">Chào mừng bạn trở lại</p>
            </div>
        </div>
        <hr>
        <ul class="app-menu">

            <li><a class="app-menu__item" href="/admin"><i class='app-menu__icon bx bx-user-voice'></i><span
                        class="app-menu__label">Quản lý khách hàng</span></a></li>
            <li><a class="app-menu__item " href="/admin/train"><i class='app-menu__icon bx bx-train  '></i>
                    <span class="app-menu__label">Quản lý Tàu</span></a></li>

            <li><a class="app-menu__item" href="/admin/station"><i
                        class='app-menu__icon bx bx-purchase-tag-alt'></i><span class="app-menu__label">Quản lý nhà
                        Ga</span></a>
            </li>
            <li><a class="app-menu__item" href="/admin/order"><i class='app-menu__icon bx bx-task'></i><span
                        class="app-menu__label">Quản lý Vé</span></a></li>
            <li><a class="app-menu__item" href="/admin/router"><i class='app-menu__icon bx bx-run'></i><span
                        class="app-menu__label">Quản lý tuyến đường
                    </span></a></li>
            <li><a class="app-menu__item" href="/admin/seat"><i class='app-menu__icon bx bx-dollar'></i><span
                        class="app-menu__label"> Quản Lý Ghế</span></a></li>
            <li><a class="app-menu__item" href="/admin/class"><i class='app-menu__icon bx bx-dollar'></i><span
                        class="app-menu__label"> Quản Lý Hạng Vé</span></a></li>

        </ul>
    </aside>
</template>

<script>
export default {
    name: 'YourComponentName',
    methods: {
        logouts() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/admin/singin');
            console.log('đã xóa token');
            // window.location.reload();
        }
    }
}
</script>
<style scoped>
@import '@/assets/css/main.css';
</style>
