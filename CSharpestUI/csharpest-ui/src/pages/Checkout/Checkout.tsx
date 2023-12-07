import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./Checkout.css";
import Card from "react-bootstrap/Card";
import NavBar from "../../components/Navbar";
import UserConstants from "../../UserConstants";

function Checkout() {

    const [cart, setCart] = useState<any>([]);

    const getCartTotals = () => {
        const params = {
            userID: UserConstants.getLocalStorage("userId", ""),
        };

        axios
            .get("https://localhost:7150/Cart/GetCartTotals", { params })
            .then((response) => {
                if (response.data != null) {
                    setCart(response.data);
                }
                console.log("success!");
            })
            .catch((error) => console.log(error));
    };

  useEffect(() => {
    getCartTotals();
  }, []);

  return (
    <div>
      <NavBar></NavBar>

      <h1 id="checkout_header">Checkout</h1>

          <table id="summary">
              <tr>
                  <th id="pre_header">Pre-Discount Subtotal</th>
                  <th id="post_header">Discounted Subtotal</th>
                  <th id="tax_header">Tax</th>
                  <th id="total_header">Total</th>
              </tr>
              <tr>
                  <td id="total">{cart.preSubtotal}</td>
                  <td id="total">{cart.postSubtotal}</td>
                  <td id="total">{cart.tax}</td>
                  <td id="total">{cart.totalPrice}</td>
              </tr>
          </table>      

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
