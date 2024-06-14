import { createRouter, createWebHistory } from "vue-router";
import Register from "@/views/Register.vue";
import Home from "@/views/HomePage.vue";
import Forgotpassword from "@/views/ForgotpasswordView.vue";
import ResetPassword from "@/views/ResetPassword.vue";
import Train from "@/views/admin/Train.vue";
import Station from "@/views/admin/Station.vue";
import Dashboard from "@/views/admin/Dashboard.vue";
import Customer from "@/views/admin/Customer.vue";
import Order from "@/views/admin/Order.vue";
import Singinsss from "@/views/admin/singinsss.vue";
import AddTrain from "@/views/admin/AddTrain.vue";
import AddStations from "@/views/admin/AddStation.vue";
import AddCustomer from "@/views/admin/AddCustomer.vue";
import AddOrder from "@/views/admin/AddOrder.vue";
import Router from "@/views/admin/Router.vue";
import AddRouter from "@/views/admin/AddRouter.vue";
import DatVe from "@/views/DatVe.vue";
import TimVe from "@/views/TimVe.vue";

const routes = [
  {
    path: "/register",
    name: "Register",
    component: Register,
  },
  {
    path: "/ResetPassword",
    name: "ResetPassword",
    component: ResetPassword,
  },
  {
    path: "/datve",
    name: "DatVe",
    component: DatVe,
  },
  {
    path: "/timve/:startStationID/:endStationID",
    name: "TimVe",
    component: TimVe,
    props: true
  },
  {
    path: "/login",
    name: "Login",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import("@/views/login.vue"),
  },
  {
    path: "/forgotpassword",
    name: "Forgotpassword",
    component: Forgotpassword,
  },
  {
    path: "/",
    name: "HomePage",
    component: Home,
    meta: { requiresAuth: true }, // Thêm meta data để chỉ định rằng trang cần đăng nhập
  },
  {
    path: "/admin/train",
    name: "EmployeeStaff",
    component: Train,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/station",
    name: "StationList",
    component: Station,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin",
    name: "DashBoard",
    component: Dashboard,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/customer",
    name: "customer",
    component: Customer,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/order",
    name: "OrderManagement",
    component: Order,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/order/add-order",
    name: "AddOrder",
    component: AddOrder,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/router",
    name: "RouterManagement",
    component: Router,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/router/add-router",
    name: "AddRouter",
    component: AddRouter,
    meta: { requiresAuth: true },
  },
  {
    path: "/admin/singin",
    name: "singin",
    component: Singinsss,
  },
  {
    path: "/admin/train/add-train",
    name: "AddTrain",
    component: AddTrain,
  },
  {
    path: "/admin/station/add-station",
    name: "AddStation",
    component: AddStations,
  },
  {
    path: "/admin/customer/add-customer",
    name: "AddCustomer",
    component: AddCustomer,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

// router.beforeEach((to, from, next) => {
//   // Kiểm tra meta data của trang khach hang
//   if (to.meta.requiresAuth && to.path !== '/login') {
//     const token = localStorage.getItem('token');
//     if (!token) {
//       // Chưa đăng nhập, chuyển hướng đến trang đăng nhập
//       next('/login');
//     } else {
//       // Đã đăng nhập, cho phép truy cập vào trang
//       next();
//     }
//   } else {
//     // Trang không yêu cầu đăng nhập, cho phép truy cập
//     next();
//   }

// });
// router.beforeEach((to, from, next) => {
//   // Kiểm tra meta data của trang yêu cầu đăng nhập
//   if (to.meta.requiresAuth && to.path !== '/singin') {
//     const token = localStorage.getItem('token');
//     if (!token) {
//       // Chưa đăng nhập, chuyển hướng đến trang đăng nhập
//       next('/admin/singin');
//     } else {
//       // Đã đăng nhập, cho phép truy cập vào trang
//       next();
//     }
//   } else {
//     // Trang không yêu cầu đăng nhập, cho phép truy cập
//     next();
//   }
// });
router.beforeEach((to, from, next) => {
  const token = localStorage.getItem("token");

  // Kiểm tra meta data của trang yêu cầu đăng nhập
  if (to.meta.requiresAuth) {
    if (!token) {
      // Chưa đăng nhập, chuyển hướng đến trang đăng nhập phù hợp
      if (to.path.startsWith("/admin")) {
        next("/admin/singin");
      } else {
        next("/login");
      }
    } else {
      // Đã đăng nhập, cho phép truy cập vào trang
      next();
    }
  } else {
    // Trang không yêu cầu đăng nhập, cho phép truy cập
    next();
  }
});

export default router;
