import React from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "../App.css";

function Login() {
  return (
    <div>
      <h1>Login</h1>
      <form id="form">
        <label>Username</label>
        <br></br>
        <input></input>
        <br></br>
        <label>Password</label>
        <br></br>
        <input></input>
        <br></br>
        <button type="submit">Login </button>
      </form>
    </div>
  );
}

export default Login;
