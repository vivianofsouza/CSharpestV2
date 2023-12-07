import React, { useEffect, useState } from "react";
import axios from "axios";
import "./Cart.css";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";
import Row from "react-bootstrap/esm/Row";
import Col from "react-bootstrap/esm/Col";
import Card from "react-bootstrap/esm/Card";
import Container from "react-bootstrap/esm/Container";

function Cart() {
    const [cartList, setCartList] = useState<any>([]);
    const [cart, setCart] = useState<any>([]);

    console.log(UserConstants.getLocalStorage("userId", ""));

  const getCartItems = () => {
    const params = {
      userID: UserConstants.getLocalStorage("userId", ""),
      };

    axios
      .get("https://localhost:7150/Cart/GetCartItems", { params })
      .then((response) => {
        if (response.data != null) {
          setCartList(response.data);
        }
        console.log("success!");
      })
      .catch((error) => console.log(error));
  };

  const getCartTotals = () => {
    const params = {
      userID: UserConstants.getLocalStorage("userId", ""),
      };

    axios
      .get("https://localhost:7150/Cart/GetCartTotals", { params })
      .then((response) => {
        if (response.data != null) {
          setCart(response.data);
        }
        console.log("success!");
      })
      .catch((error) => console.log(error));
  };

  useEffect(() => {
      getCartItems();
      getCartTotals();
  }, []);

  function removeFromCart(cartItem: string) {
    axios
      .delete("https://localhost:7150/Cart/RemoveFromCart/", {
        params: {
          itemId: cartItem,
          cartId: UserConstants.getLocalStorage("cartId", ""),
        },
      })
      .then((res) => {
        console.log(res);
        document.getElementById(`itemId-${cartItem}`)!.style.display = "none";
      })
      .catch((err) => console.log(err));
  }

    function addQuantity(fromFormItem: string) {
        const formData = new FormData();

        const itemID = (
            document.getElementById(`itemId-${fromFormItem}`) as HTMLInputElement
        ).value;

        const quantity = (
            document.getElementById(`quantity-${fromFormItem}`) as HTMLInputElement
        ).value;

        const add = "true";

        const form = document.getElementById(`form-${fromFormItem}`);

        form!.addEventListener("submit", (e) => {
            e.preventDefault();
        });

        formData.append("ItemId", itemID);
        formData.append("CartId", UserConstants.getLocalStorage("cartId", ""));
        formData.append("Quantity", quantity);
        formData.append("true", add);

        axios
            .post("https://localhost:7150/Cart/ChangeQuantity", formData)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
    }

    function removeQuantity(fromFormItem: string) {
        const formData = new FormData();

        const itemID = (
            document.getElementById(`itemId-${fromFormItem}`) as HTMLInputElement
        ).value;

        const quantity = (
            document.getElementById(`quantity-${fromFormItem}`) as HTMLInputElement
        ).value;

        const add = "false";

        const form = document.getElementById(`form-${fromFormItem}`);

        form!.addEventListener("submit", (e) => {
            e.preventDefault();
        });

        formData.append("ItemId", itemID);
        formData.append("CartId", UserConstants.getLocalStorage("cartId", ""));
        formData.append("Quantity", quantity);
        formData.append("false", add);

        axios
            .post("https://localhost:7150/Cart/ChangeQuantity", formData)
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
    }

  function clearCart() {
    axios
      .delete("https://localhost:7150/Cart/ClearCart/", {
        params: {
          cartId: UserConstants.getLocalStorage("cartId", ""),
        },
      })
      .then((res) => {
        document.getElementById("cart")!.style.display = "none";
      })
      .catch((err) => console.log(err));
  }

  return (
    <div id="body">
      <NavBar></NavBar>
      <h1 id="cart_header">Cart</h1>

              <table id="summary">
                  <tr>
                    <th id="pre_header">Pre-Discount Subtotal</th>
                    <th id="post_header">Discounted Subtotal</th>
                    <th id="tax_header">Tax</th>
                    <th id="total_header">Total</th>
                    <th id="button_header">Clear Cart</th>
                  </tr>
                  <tr>
                    <td id="total">{cart.preSubtotal}</td>
                    <td id="total">{cart.postSubtotal}</td>
                    <td id="total">{cart.tax}</td>
                      <td id="total">{cart.totalPrice}</td>
                    <td><button id="clear_cart" type="submit" onClick={clearCart}>Clear</button></td>
                  </tr>
              </table>          

          <Container id="cart_container">
              <Row id="candy_row">
                {cartList.map(
                    (cartItem: {
                    id: string;
                    name: string;
                    imageURL: string;
                    unitPrice: number;
                    quantity: number;
                    totalPrice: number;
                    }) => (
                        <>
                            <Col xs="3">
                                <Card id="cart_card">
                                    <Card.Header id="card_header">
                                        {cartItem.name}
                                    </Card.Header>
                                    <Card.Body id="card_body">
                                        <img id="candy_image" src={cartItem.imageURL} width="200" height="200"></img>
                                    </Card.Body>
                                    <Card.Footer id="card+footer">
                                    </Card.Footer>
                                    <div id={`itemId-${cartItem.id}`}>
                                        <li id="card_label">$ / oz: {cartItem.unitPrice}</li>
                                        <li id="card_label">Quantity: {cartItem.quantity}</li>
                                        <li id="card_label">Price: {cartItem.totalPrice}</li>

                                        <form id={`form-${cartItem.id}`}>
                                            <div id="rowone">
                                                <span id="quan">
                                                    <label>Quantity</label>
                                                </span>
                                                <span id="answer">
                                                    <input id={`quantity-${cartItem.id}`}></input>
                                                </span>
                                            </div>

                                            <input
                                                type="hidden"
                                                id={`itemId-${cartItem.id}`}
                                                value={cartItem.id}
                                            ></input>
                                            <br></br>
                                            <button
                                                id="add"
                                                type="submit"
                                                onClick={() => addQuantity(cartItem.id)}
                                            >
                                                Add
                                            </button>
                                            <button
                                                id="remove"
                                                type="submit"
                                                onClick={() => removeQuantity(cartItem.id)}
                                            >
                                                Remove
                                            </button>
                                        </form>

                                        <button
                                        id="remove_button"
                                        type="submit"
                                        onClick={() => removeFromCart(cartItem.id)}
                                    >
                                        Remove from Cart
                                    </button>
                                    </div>
                                </Card>
                            </Col>
                        
                    </>
                    )
                )}
              </Row>
          </Container>
    </div>
  );
}

export default Cart;
