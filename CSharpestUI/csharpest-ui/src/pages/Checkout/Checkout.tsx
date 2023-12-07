import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./Checkout.css";
import Card from "react-bootstrap/Card";
import NavBar from "../../components/Navbar";
import UserConstants from "../../UserConstants";
import Col from "react-bootstrap/esm/Col";

function Checkout() {
  const [cartList, setCartList] = useState<any>([]);
  const [tax, setTax] = useState(0);
  const [preSubTotal, setPreSubTotal] = useState(0);
  const [postSubTotal, setPostSubTotal] = useState(0);
  const [subTotal, setSubTotal] = useState(0);
  const [total, setTotal] = useState(0);

  const getCartItems = () => {
    axios
      .get("https://localhost:7150/Cart/GetCartItems", {
        params: {
          userId: UserConstants.getLocalStorage("userId", ""),
        },
      })
      .then((response) => {
        if (response.data != null) {
          setCartList(response.data);
        }
      })
      .catch((error) => console.log(error));
  };

  const getCartTotals = () => {
    axios
      .get("https://localhost:7150/Cart/GetCartTotals", {
        params: {
          userId: UserConstants.getLocalStorage("userId", ""),
        },
      })
      .then((response) => {
        setTotal(response.data.totalPrice);
        setTax(response.data.tax);
        setPreSubTotal(response.data.preSubTotal);
        setPostSubTotal(response.data.postSubTotal);
      })
      .catch((error: any) => console.log(error));
  };

  useEffect(() => {
    getCartItems();
    getCartTotals();
  }, []);

  return (
    <div>
      <NavBar></NavBar>

      <h1 id="checkout_header">Checkout</h1>

      {cartList.map(
        (cartItem: {
          id: string;
          name: string;
          imageURL: string;
          unitPrice: number;
          quantity: number;
          totalPrice: number;
        }) => (
          <>
            <Col ls="2">
              <Card>
                <div id={`itemId-${cartItem.id}`}>
                  <Card.Header id="card_header">{cartItem.name}</Card.Header>
                  <Card.Body id="card_body">
                    <img src={cartItem.imageURL} width="200" height="200"></img>
                    <br></br>
                    Price by oz: {cartItem.unitPrice}
                    <br></br>
                    Quantity: {cartItem.quantity} oz
                    <br></br>
                    Total Price: {cartItem.totalPrice}
                    <br></br>
                  </Card.Body>
                </div>
              </Card>
            </Col>
          </>
        )
      )}

      <h4>Subtotal: ${preSubTotal}</h4>
      <h4>Discounts: ${postSubTotal}</h4>
      <h4>Taxes: ${tax}</h4>
      <h4>Shipping: ${5.99}</h4>
      <h4>Total: ${total}</h4>

      <Card id="payment_card">
        <Card.Header id="payment_card_header">
          Enter Payment Details
        </Card.Header>
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

              <button type="submit" id="confirm_payment_button">
                Purchase
              </button>
            </form>
          </Card.Text>
        </Card.Body>
      </Card>
    </div>
  );
}

export default Checkout;
