import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./StoreHome.css";
import { UUID } from "crypto";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";
import Row from "react-bootstrap/esm/Row";
import Col from "react-bootstrap/esm/Col";
import Card from "react-bootstrap/esm/Card";
import Container from "react-bootstrap/esm/Container";

function StoreHome() {
  const [itemList, setItemsList] = useState<any>([]);
  // we're getting the list of all items here in this GET request. It's stored in a JavaScript array. Use developer tools to view what it looks like. You'll must likely need to map it into table to display it onto the screen.
  const getItems = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsPriceSort")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  const getItemsByAlphabet = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsAZSort")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  const getItemsByStock = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsStockSort")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  const getOnSale = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsOnSale")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  // add to Cart POST request, hardcoded values for now
  function addToCart(fromFormItem: string) {
    const formData = new FormData();

    const itemID = (
      document.getElementById(`itemId-${fromFormItem}`) as HTMLInputElement
    ).value;

    const quantity = (
      document.getElementById(`quantity-${fromFormItem}`) as HTMLInputElement
    ).value;

    const form = document.getElementById(`form-${fromFormItem}`);

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    formData.append("ItemId", itemID);
    formData.append("CartId", UserConstants.getLocalStorage("cartId", ""));
    formData.append("Quantity", quantity);

    console.log(itemID + "item");
    console.log(quantity + "quant");
    console.log(UserConstants.getLocalStorage("cartId", "") + "cart");

    axios
      .post("https://localhost:7150/Cart/AddItemToCart", formData)
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }

  useEffect(() => {
    getItems();
  }, []);

  return (
    <div>
      <NavBar></NavBar>

        <div id="header">
            <h1 id="shop_header">
            Welcome,  {UserConstants.getLocalStorage("firstName", "")}!
            </h1>
            <h2 id="shop_subheader">Shop the CSharpest Store Now</h2>
        </div>

      <div id="sort_buttons">
        <button id="sort_by_price" type="submit" onClick={getItems}>
          Sort by Price
        </button>
        <button
          id="sort_by_alphabet"
          type="submit"
          onClick={getItemsByAlphabet}
        >
          Sort by A-Z
        </button>
        <button id="sort_by_stock" type="submit" onClick={getItemsByStock}>
          Sort by Stock Remaining
        </button>
        <button id="on_sale" type="submit" onClick={getOnSale}>
          On Sale
        </button>
      </div>

      <Container id="candy_container">
        <Row id="candy_row">
          {itemList.map(
            (item: {
              id: UUID;
              bundleId: string;
              stock: number;
              price: number;
              description: string;
              name: string;
              imageURL: string;
            }) => (
              <>
                <Col xs="3">
                  <Card id="candy_card">
                    <Card.Header id="card_header">{item.name}<span id="bundle">{item.bundleId ? "BOGO" : ""}</span></Card.Header>
                    <Card.Subtitle id="card_subtitle">{item.description}</Card.Subtitle>
                    <Card.Body id="card_body">
                      <img src={item.imageURL} width="150" height="150" id="candy_pic"></img>
                      <br></br>${item.price.toFixed(2)} per oz.{" "}
                      
                      <br></br>
                      {item.stock} left in stock
                      <br></br>
                    </Card.Body>

                    <Card.Footer id="card_footer">
                      <form id={`form-${item.id}`}>
                      <div id="rowone">
                        <span id="quan">
                            <label>Quantity</label>
                        </span>
                        <span id="answer">
                            <input id={`quantity-${item.id}`}></input>
                        </span>
                      </div>
                        
                        <input
                          type="hidden"
                          id={`itemId-${item.id}`}
                          value={item.id}
                        ></input>
                        <br></br>
                        <button
                          id="add"
                          type="submit"
                          onClick={() => addToCart(item.id)}
                        >
                          Add to Cart
                        </button>
                      </form>
                    </Card.Footer>
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

export default StoreHome;
