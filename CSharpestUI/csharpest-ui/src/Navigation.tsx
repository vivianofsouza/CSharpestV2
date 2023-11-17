import React from "react";
import { BrowserRouter, Route, Link } from "react-router-dom";
function Navbar() {
  return (
    <nav>
      {" "}
      <ul>
        {" "}
        <li>
          {" "}
          <Link to="/">Login</Link>{" "}
        </li>{" "}
        <li>
          {" "}
          <Link to="/storeHome">Store Home</Link>{" "}
        </li>{" "}
        <li>
          {" "}
          <Link to="/cart">Your Cart</Link>{" "}
        </li>{" "}
        <li>
          {" "}
          <Link to="/checkout">Checkout</Link>{" "}
        </li>{" "}
      </ul>{" "}
    </nav>
  );
}
export default Navbar;
