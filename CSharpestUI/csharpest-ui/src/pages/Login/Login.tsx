import React from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import Card from "react-bootstrap/Card";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "./Login.css";
import { useNavigate } from "react-router-dom";
import UserConstants from "../../UserConstants";

const validateUser = () => {
  axios
    .get("https://localhost:7150/api/Users/Login")
    .then((response) => {
      //setItemsList(response.data);
    })
    .catch((error) => console.log(error));
};

function Login() {
  // creates navigation object to navigate to next page based on whether a user is store manager or customer
  const navigate = useNavigate();

  // handles customer login
  function loginCustomer() {
    const form = document.getElementById("login_form");

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    const formData = new FormData();
    const email = (document.getElementById("Email") as HTMLInputElement).value;
    const password = (document.getElementById("Password") as HTMLInputElement)
      .value;
    formData.append("Email", email);
    formData.append("Password", password);

    axios
      .post("https://localhost:7150/api/Users/Login", formData)
      .then((res) => {
        if (res.status == 200) {
          console.log(res.data);
          UserConstants.setCurrUser(res.data.id);
          UserConstants.setCurrCart(res.data.cartId);
          UserConstants.setIsAdmin(res.data.isAdmin);
          UserConstants.setFirstName(res.data.firstName);
          UserConstants.setLastName(res.data.lastName);
          navigate("/storeHome");
        } else {
          alert(
            "Invalid Username or Password. Please try again or Create an Account."
          );
        }
      })
      .catch((err) => {
        console.log(err);
        alert(
          "Invalid Username or Password. Please try again or Create an Account."
        );
      });
  }

  return (
    <div id="login_page">
      <h1 id="welcome_header">Welcome to the CSharpest Candy Store</h1>

      <Row id="row">
        <Col md={6} id="create_account_col">
          <Card id="create_account_card">
            <Card.Header id="create_account_card_header">
              Create Account
            </Card.Header>
            <Card.Body id="create_account_card_body">
              <Card.Text id="create_account_card_text">
                <form id="create_account_form">
                  <p id="select_account_type">Select Account Type</p>
                  <input
                    type="radio"
                    id="shopper_account"
                    name="account_type"
                    value="Shopper"
                  ></input>
                  <label id="shopper_label">Shopper</label>
                  <input
                    type="radio"
                    id="store_manager_account"
                    name="account_type"
                    value="Store Manager"
                  ></input>
                  <label id="sm_label">Store Manager</label>
                  <br></br>
                  <br></br>
                  <label id="email_label">Email</label>
                  <br></br>
                  <input id="email_input"></input>
                  <br></br>
                  <label id="first_name_label">First Name</label>
                  <br></br>
                  <input id="first_name_input"></input>
                  <br></br>
                  <label id="last_name_label">Last Name</label>
                  <br></br>
                  <input id="last_name_input"></input>
                  <br></br>
                  <label id="password_label">Password</label>
                  <br></br>
                  <input id="password_input"></input>
                  <br></br>
                  <button type="submit" id="create_account_submit_button">
                    Create Account
                  </button>
                </form>
              </Card.Text>
            </Card.Body>
          </Card>
        </Col>

        <Col md={6} id="login_col">
          <Card id="login_card">
            <Card.Header id="login_card_header">Login</Card.Header>
            <Card.Body id="login_card_body">
              <Card.Text id="login_card_text">
                <form id="login_form">
                  <label id="email_label">Email</label>
                  <br></br>
                  <input id="Email"></input>
                  <br></br>
                  <label id="password_label">Password</label>
                  <br></br>
                  <input id="Password"></input>
                  <br></br>
                  <button
                    type="submit"
                    id="login_submit_button"
                    onClick={loginCustomer}
                  >
                    Login{" "}
                  </button>
                </form>
              </Card.Text>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </div>
  );
}

export default Login;
