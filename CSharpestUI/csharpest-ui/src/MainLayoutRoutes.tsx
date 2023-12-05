import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Layout";
import StoreHome from "./pages/StoreHome/StoreHome";
import Cart from "./pages/Cart/Cart";
import Checkout from "./pages/Checkout/Checkout";
import Login from "./pages/Login/Login";
import { useState } from "react";
import Navbar from "./Navigation";

function MainLayoutRoutes() {
  return (
    <>
      <Navbar></Navbar>
      <Routes>
        {" "}
        <Route path="storeHome" element={<StoreHome />} />{" "}
        <Route path="cart" element={<Cart />} />{" "}
        <Route path="checkout" element={<Checkout />} />{" "}
      </Routes>
    </>
  );
}

export default MainLayoutRoutes;
