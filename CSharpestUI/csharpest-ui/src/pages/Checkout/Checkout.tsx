import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./Checkout.css";
import Card from "react-bootstrap/Card";
import NavBar from "../../components/Navbar";
import UserConstants from "../../UserConstants";
import { useNavigate } from "react-router-dom";

function Checkout() {
  const [cart, setCart] = useState<any>([]);
  const navigate = useNavigate();

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

  const placeOrder = () => {
    const formData = new FormData();

    const cardNo = (document.getElementById("cardNo") as HTMLInputElement)
      .value;
    const expMonth = (document.getElementById("expMonth") as HTMLInputElement)
      .value;
    const expYear = (document.getElementById("expYear") as HTMLInputElement)
      .value;
    const cvv = (document.getElementById("cvv") as HTMLInputElement).value;
    const cardName = (document.getElementById("cardName") as HTMLInputElement)
      .value;
    const zip = (document.getElementById("zip") as HTMLInputElement).value;

    const cardAddress = (
      document.getElementById("cardAddress") as HTMLInputElement
    ).value;

    const form = document.getElementById("payment_form");

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    formData.append("userId", UserConstants.getLocalStorage("userId", ""));
    formData.append("cardNo", cardNo);
    formData.append("month", expMonth);
    formData.append("year", expYear);
    formData.append("name", cardName);
    formData.append("cVV", cvv);
    formData.append("zip", zip);
    formData.append("address", cardAddress);

    axios
      .post("https://localhost:7150/Order/", formData)
      .then((response) => {
        console.log(response);
        alert(
          "Successfully placed order! We'll return you to the store for further shopping."
        );
        navigate("/storeHome");
      })
      .catch((error: any) => console.log(error));
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
              <input id="cardNo"></input>
              <br></br>

              <label id="label">Expiration Month</label>
              <br></br>
              <input id="expMonth"></input>
              <br></br>

              <label id="label">Expiration Year</label>
              <br></br>
              <input id="expYear"></input>
              <br></br>

              <label id="label">CVV</label>
              <br></br>
              <input id="cvv"></input>
              <br></br>

              <label id="label">Cardholder Name</label>
              <br></br>
              <input id="cardName"></input>
              <br></br>

              <label id="label">Billing Address</label>
              <br></br>
              <input id="cardAddress"></input>
              <br></br>

              <label id="label">Zip Code</label>
              <br></br>
              <input id="zip"></input>
              <br></br>

              <button
                type="submit"
                id="confirm_payment_button"
                onClick={placeOrder}
              >
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
