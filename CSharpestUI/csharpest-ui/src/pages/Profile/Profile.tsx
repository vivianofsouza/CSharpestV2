import React, { useEffect, useState } from "react";
import axios from "axios";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";

function Profile() {
    return (
        <div>
            <NavBar></NavBar>

            <body>

                <h1>Profile Manager</h1>

                <div id="mods">

                </div>
            </body>
        </div>
    );
}

export default Profile;