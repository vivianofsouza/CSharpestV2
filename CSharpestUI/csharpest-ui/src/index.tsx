import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Layout";
import StoreHome from "./pages/StoreHome/StoreHome";
import Cart from "./pages/Cart/Cart";
import Checkout from "./pages/Checkout/Checkout";
import Login from "./pages/Login/Login";
import { useState } from "react";
import UserConstants from "./UserConstants";

export default function App() {
  const [showNav, setShowNav] = useState(true);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="storeHome" element={<StoreHome />} />{" "}
        <Route path="cart" element={<Cart />} />{" "}
        <Route path="checkout" element={<Checkout />} />{" "}
      </Routes>
    </BrowserRouter>
  );
}
ReactDOM.render(<App />, document.getElementById("root"));
