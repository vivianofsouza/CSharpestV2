import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";

import "./Navbar.css";
import UserConstants from "../UserConstants";

function NavBar() {
  return (
    <Navbar expand="lg" className="bg-body-tertiary" id="nav">
      <Container>
        <Navbar.Brand
          href={
            UserConstants.getLocalStorage("isAdmin", "")
              ? "/storeManager"
              : "storeHome"
          }
          id="nav_link"
        >
          Home
        </Navbar.Brand>

        <Navbar.Brand href="/checkout" id="nav_link">
          {UserConstants.getLocalStorage("isAdmin", "") ? (
            ""
          ) : (
            <h3>Checkout</h3>
          )}
        </Navbar.Brand>

        <Navbar.Brand href="/cart" id="nav_link">
          {UserConstants.getLocalStorage("isAdmin", "") ? "" : <h3>My Cart</h3>}
        </Navbar.Brand>

        <Navbar.Brand
          href="/"
          id="nav_link"
          onClick={() => UserConstants.logOut()}
        >
          Log out
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
}

export default NavBar;
