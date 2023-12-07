import React, { useEffect, useState } from "react";
import axios from "axios";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";

function Profile() {

    function changeFName() {
        const formData = new FormData();

        const newName = (
            document.getElementById(`newFName`) as HTMLInputElement
        ).value;

        const form = document.getElementById(`firstName`);

        form!.addEventListener("submit", (e) => {
            e.preventDefault();
        });

        formData.append("UserId", UserConstants.getLocalStorage("userId", ""));
        formData.append("newName", newName);

        UserConstants.setLocalStorage("firstName", newName);

        axios
            .patch("https://localhost:7150/Users/fName", formData)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
    }

    function changeLName() {
        const formData = new FormData();

        const newName = (
            document.getElementById(`newLName`) as HTMLInputElement
        ).value;

        const form = document.getElementById(`lastName`);

        form!.addEventListener("submit", (e) => {
            e.preventDefault();
        });

        formData.append("UserId", UserConstants.getLocalStorage("userId", ""));
        formData.append("newName", newName);

        UserConstants.setLocalStorage("lastName", newName);

        axios
            .patch("https://localhost:7150/Users/lName", formData)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
    }

    function changeEmail() {
        const formData = new FormData();

        const newEmail = (
            document.getElementById(`newEmail`) as HTMLInputElement
        ).value;

        const form = document.getElementById(`email`);

        form!.addEventListener("submit", (e) => {
            e.preventDefault();
        });

        formData.append("UserId", UserConstants.getLocalStorage("userId", ""));
        formData.append("newEmail", newEmail);

        axios
            .patch("https://localhost:7150/Users/email", formData)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
    }

    function changePassword() {
        const formData = new FormData();

        const newPassword = (
            document.getElementById(`newPassword`) as HTMLInputElement
        ).value;

        const form = document.getElementById(`password`);

        form!.addEventListener("submit", (e) => {
            e.preventDefault();
        });

        formData.append("UserId", UserConstants.getLocalStorage("userId", ""));
        formData.append("newPassword", newPassword);

        axios
            .patch("https://localhost:7150/Users/password", formData)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
    }

    return (
        <div>
            <NavBar></NavBar>

            <body>
                <div id="header">
                    <h1 id="profile_header">Profile Manager</h1>
                </div>
                
                <div id="mods">
                    <form id={`firstName`}>
                        <div id="rowone">
                            <label id="formLabel">First Name:</label>
                            <input type="text" id={`newFName`}></input>
                            <button
                                id="add"
                                type="submit"
                                onClick={() => changeFName()}
                            >
                                Change First Name
                                </button>
                        </div>
                    </form>
                    <br></br>
                    <form id={`lastName`}>
                        <div id="rowone">
                            <label id="formLabel">Last Name:</label>
                            <input type="text" id={`newLName`}></input>
                            <button
                                id="add"
                                type="submit"
                                onClick={() => changeLName()}
                            >
                                Change Last Name
                                </button>
                        </div>
                    </form>
                    <br></br>
                    <form id={`email`}>
                        <div id="rowone">
                            <label id="formLabel">Email:</label>
                            <input type="text" id={`newEmail`}></input>
                            <button
                                id="add"
                                type="submit"
                                onClick={() => changeEmail()}
                            >
                                Change Email
                                </button>
                        </div>
                    </form>
                    <br></br>
                    <form id={`password`}>
                        <div id="rowone">
                            <label id="formLabel">Password:</label>
                            <input type="text" id={`newPassword`}></input>
                            <button
                                id="add"
                                type="submit"
                                onClick={() => changePassword()}
                            >
                                Change Password
                            </button>
                        </div>
                    </form>
                </div>
                
            </body>
        </div>
    );
}

export default Profile;