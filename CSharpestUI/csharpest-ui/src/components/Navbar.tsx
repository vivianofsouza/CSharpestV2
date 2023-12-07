import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import "./Navbar.css";
import UserConstants from "../UserConstants";

function NavBar() {
  return (
    <Navbar expand="lg" className="bg-body-tertiary" id="nav">
      <Container>
        <Navbar.Brand href="/storeHome" id="nav_link">
          Store Home
        </Navbar.Brand>
        <Navbar.Brand href="/checkout" id="nav_link">
          Checkout
        </Navbar.Brand>
        <Navbar.Brand href="/cart" id="nav_link_cart">
          My Cart
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
