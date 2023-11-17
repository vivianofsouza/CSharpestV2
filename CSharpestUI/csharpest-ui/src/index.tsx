import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Layout";
import StoreHome from "./pages/StoreHome";
import Cart from "./pages/Cart";
import Checkout from "./pages/Checkout";
import Login from "./pages/Login";
export default function App() {
  return (
    <BrowserRouter>
      {" "}
      <Routes>
        {" "}
        <Route path="/" element={<Layout />}>
          {" "}
          <Route index element={<Login />} />{" "}
          <Route path="storeHome" element={<StoreHome />} />{" "}
          <Route path="cart" element={<Cart />} />{" "}
          <Route path="checkout" element={<Checkout />} />{" "}
          {/* <Route path="*" element={<NoPage />} />{" "} */}
        </Route>{" "}
      </Routes>{" "}
    </BrowserRouter>
  );
}
ReactDOM.render(<App />, document.getElementById("root"));
