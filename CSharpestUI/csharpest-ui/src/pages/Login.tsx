import React from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "../App.css";
import "./Login.css";

function Login() {
  return (
    <div id="login_page">
      <h1 id="welcome_header">Welcome to the CSharpest Candy Store</h1>

      <div id="login_container">
        <h2 id="login_header">Login</h2>
        <form id="login_form">
          <label id="username_label">Username</label>
          <br></br>
          <input id="username_input"></input>
          <br></br>
          <label id="password_label">Password</label>
          <br></br>
          <input id="password_input"></input>
          <br></br>
          <button type="submit" id="login_submit_button">Login </button>
        </form>
      </div>
    </div>
  );
}

export default Login;
