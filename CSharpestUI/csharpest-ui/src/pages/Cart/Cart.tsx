import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./Cart.css";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";

function Cart() {
  const [cartList, setCartList] = useState<any>([]);

  console.log(UserConstants.getLocalStorage("userId", ""));
  const getCartItems = () => {
    const params = {
      userID: UserConstants.getLocalStorage("userId", ""),
    };
    axios
      .get("https://localhost:7150/Cart/GetCartItems", { params })
      .then((response) => {
        setCartList(response.data);
        console.log("success!");
      })
      .catch((error) => console.log(error));
  };

  useEffect(() => {
    getCartItems();
  }, []);

  return (
    <div>
      <NavBar></NavBar>
      <h1 id="cart_header">Cart</h1>

      {cartList.map(
        (cartItem: {
          name: string;
          unitPrice: number;
          quantity: number;
          totalPrice: number;
        }) => (
          <>
            <li>{cartItem.name}</li>
            <li>{cartItem.unitPrice}</li>
            <li>{cartItem.quantity}</li>
            <li>{cartItem.totalPrice}</li>
            <br></br>
          </>
        )
      )}
      <h4 id="subtotal_header">Subtotal:</h4>
    </div>
  );
}

export default Cart;
