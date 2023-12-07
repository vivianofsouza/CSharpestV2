import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";

import "./Navbar.css";
import UserConstants from "../UserConstants";

function NavBar() {
    return (
        <html lang="en">
            <head>
                <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"/>
            <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"></script>
            <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"></script>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"></script>
            </head>
            <body>
                <nav className="navbar navbar-light">
                <ul id="nav-bar">
                    <li id="bar">
                        <a href="/storeHome" id="nav_home">Home</a>
                    </li>
                    <li id="bar">
                        <a href="/cart" id="nav_cart">My Cart</a>
                    </li>
                    <li id="bar">
                        <a href="/checkout" id="nav_checkout">Checkout</a>
                    </li>
                    <li id="bar">
                        <a href="/profile" id="nav_profile">Profile</a>
                    </li>
                    <li id="bar">
                        <a href="/" id="nav_logout" onClick={() => UserConstants.logOut()}>Logout</a>
                    </li>
                </ul>
    </nav>
            </body>
            </html>
      
  );
}

export default NavBar;