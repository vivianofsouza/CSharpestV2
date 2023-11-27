import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "../App.css";

function Cart() {
  const [cartList, setCartList] = useState<any>([]);

  const getCartItems = () => {
    axios
      .get(
        "https://localhost:7150/Cart/GetCartItems?UserID=c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1"
      )
      .then((response) => {
        setCartList(response.data);
      })
      .catch((error) => console.log(error));
  };

  useEffect(() => {
    getCartItems();
  }, []);

  return (
    <div>
      <h1>Cart</h1>

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
      <h4>Subtotal</h4>
    </div>
  );
}

export default Cart;
