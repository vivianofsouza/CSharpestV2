import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./Checkout.css";
import Card from 'react-bootstrap/Card';

function Checkout() {
  const [cartList, setCartList] = useState<any>([]);
  const [total, setTotal] = useState(0);

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

  const getCartTotal = () => {
    axios
      .get("https://localhost:7150/Checkout/CalculateTotal")
      .then((response: { data: React.SetStateAction<number> }) => {
        setTotal(response.data);
      })
      .catch((error: any) => console.log(error));
  };

  useEffect(() => {
    getCartItems();
    getCartTotal();
  }, []);

  return (
    <div>
      <h1 id="checkout_header">Checkout</h1>

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
      <h4>Subtotal: $</h4>
      <h4>Discounts: $</h4>
      <h4>Taxes: $</h4>
      <h4>Shipping: $</h4>
      <h4>Total: ${total}</h4>

      <Card id="payment_card">
            <Card.Header id="payment_card_header">Enter Payment Details</Card.Header>
            <Card.Body id="payment_card_body">
              <Card.Text id="payment_card_text">
                <form id="payment_form">
                  <label id="label">Card number</label>
                  <br></br>
                  <input id="input"></input>
                  <br></br>

                  <label id="label">Expiration Month</label>
                  <br></br>
                  <input id="input"></input>
                  <br></br>

                  <label id="label">Expiration Year</label>
                  <br></br>
                  <input id="input"></input>
                  <br></br>

                  <label id="label">CVV</label>
                  <br></br>
                  <input id="input"></input>
                  <br></br>

                  <label id="label">Cardholder Name</label>
                  <br></br>
                  <input id="input"></input>
                  <br></br>

                  <label id="label">Billing Address</label>
                  <br></br>
                  <input id="input"></input>
                  <br></br>

                  <button type="submit" id="confirm_payment_button">Purchase</button>
                </form>        
              </Card.Text>
            </Card.Body>
          </Card>

    </div>
  );
}

export default Checkout;
