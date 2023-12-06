import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";

function NavBar() {
  return (
    <Navbar expand="lg" className="bg-body-tertiary">
      <Container>
        <Navbar.Brand href="/storeHome">Store Home</Navbar.Brand>
        <Navbar.Brand href="/cart">My Cart</Navbar.Brand>
        <Navbar.Brand href="/checkout">Checkout</Navbar.Brand>
      </Container>
    </Navbar>
  );
}

export default NavBar;
