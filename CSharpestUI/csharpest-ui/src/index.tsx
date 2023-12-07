import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import StoreHome from "./pages/StoreHome/StoreHome";
import Cart from "./pages/Cart/Cart";
import Checkout from "./pages/Checkout/Checkout";
import Login from "./pages/Login/Login";
import StoreManager from "./pages/StoreManager/StoreManager";
import Profile from "./pages/Profile/Profile";
import { useState } from "react";
import Grid from "./Grid";

// sets the navigation for the app
export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="storeHome" element={<StoreHome />} />{" "}
        <Route path="cart" element={<Cart />} />{" "}
        <Route path="checkout" element={<Checkout />} />{" "}
        <Route path="storeManager" element={<StoreManager />} />{" "}
        <Route path="grid" element={<Grid />} />{" "}
        <Route path="profile" element={<Profile />} />{" "}
      </Routes>
    </BrowserRouter>
  );
}
ReactDOM.render(<App />, document.getElementById("root"));
