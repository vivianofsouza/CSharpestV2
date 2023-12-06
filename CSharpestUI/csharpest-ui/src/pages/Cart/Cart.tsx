import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./Cart.css";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";

function Cart() {
  const [cartList, setCartList] = useState<any>([]);

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
    // getCartItems();
  }, []);

  return (
    <div>
      <NavBar></NavBar>
      <h1 id="cart_header">Cart</h1>

      {cartList.map(
        (cartItem: {
          item: {
            name: string;
            price: number;
            bogo: boolean;
          };
          quantity: number;
          totalPrice: number;
        }) => (
          <>
            <li>{cartItem.item.name}</li>
            <li>{cartItem.item.price}</li>
            <li>{cartItem.item.bogo}</li>
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
