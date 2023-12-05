import React from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import "./Login.css";

const validateUser = () => {
  axios
    .get("https://localhost:7150/Item/GetAllItemsStockSort")
    .then((response) => {
      //setItemsList(response.data);
    })
    .catch((error) => console.log(error));
};

function Login() {
  return (
    <div id="login_page">
      <h1 id="welcome_header">Welcome to the CSharpest Candy Store</h1>

      <Card>
        <Card.Header>Login</Card.Header>
        <Card.Body>
          <Card.Text>
            <form id="login_form">
              <label id="username_label">Email</label>
              <br></br>
              <input id="username_input"></input>
              <br></br>
              <label id="password_label">Password</label>
              <br></br>
              <input id="password_input"></input>
              <br></br>
              <button type="submit" id="login_submit_button">
                Login{" "}
              </button>
            </form>         
          </Card.Text>
          <Button variant="primary">Go somewhere</Button>
        </Card.Body>
      </Card>

      <div id="login_container">
        <h2 id="login_header">Login</h2>
        <form id="login_form">
          <label id="username_label">Email</label>
          <br></br>
          <input id="username_input"></input>
          <br></br>
          <label id="password_label">Password</label>
          <br></br>
          <input id="password_input"></input>
          <br></br>
          <button type="submit" id="login_submit_button">
            Login{" "}
          </button>
        </form>
      </div>

      <div id="signup_container">
        <h2 id="signup_header">Create an Account</h2>
        <form id="signup_form">
          <label id="select_account_type">Select Account Type</label>
          <br></br>
          <input
            type="radio"
            id="shopper_input"
            name="user_type"
            value="shopper_input"
          ></input>
          � <label id="shopper_label">Shopper</label>
          <br></br>�{" "}
          <input
            type="radio"
            id="sm_input"
            name="user_type"
            value="sm_input"
          ></input>
          <label id="sm_label">Store Manager</label>
          <br></br>
          <br></br>
          <label id="username_label">Email</label>
          <br></br>
          <input id="username_input"></input>
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
          <button type="submit" id="signup_submit_button">
            Login
          </button>
        </form>
      </div>
    </div>
  );
}

export default Login;
