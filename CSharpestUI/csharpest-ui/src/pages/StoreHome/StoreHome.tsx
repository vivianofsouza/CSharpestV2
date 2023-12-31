import React, { useEffect, useState } from "react";
import axios from "axios";
import "./StoreHome.css";
import { UUID } from "crypto";
import UserConstants from "../../UserConstants";
import NavBar from "../../components/Navbar";
import Row from "react-bootstrap/esm/Row";
import Col from "react-bootstrap/esm/Col";
import Card from "react-bootstrap/esm/Card";
import Container from "react-bootstrap/esm/Container";

// renders the Store Home page, where users can browse items and sales an add items to cart
function StoreHome() {
  const [itemList, setItemsList] = useState<any>([]);

  // Req to get all store inventory items. The default sort is by Price.
  const getItems = () => {
    console.log(UserConstants.getLocalStorage("userId", ""));
    axios
      .get("https://localhost:7150/Item/GetAllItemsPriceSort")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  // Same as above, but sorted by alphabet.
  const getItemsByAlphabet = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsAZSort")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  // Same as above, but sorted by stock left.
  const getItemsByStock = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsStockSort")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  // Returns all store inventory that's on sale.
  const getOnSale = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsOnSale")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  // Adds an item to cart
  // funcParams: fromFormItem, a string that indicates which item a user would like to add to cart
  // reqParams: itemId (from fromFormItem), quantity (from input on page), cartId (from UserConstants global variables)
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

    axios
      .post("https://localhost:7150/Cart/AddItemToCart", formData)
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }

  // renders store inventory upon navigation to page
  useEffect(() => {
    getItems();
  }, []);

  return (
    <div>
      <NavBar></NavBar>

      <div id="header">
        <h1 id="shop_header">
          Welcome, {UserConstants.getLocalStorage("firstName", "")}{" "}
          {UserConstants.getLocalStorage("lastName", "")}!
        </h1>
        <h2 id="shop_subheader">Shop the CSharpest Store Now</h2>
      </div>

      {/*Buttons to sort the inventory */}

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

      {/*Grid to display the inventory */}
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
                    <Card.Header id="card_header">
                      {item.name}
                      <span id="bundle">
                        {item.bundleId == "6818fb3a-3079-4117-ba4c-7c16be4f9422"
                          ? "BOGO"
                          : ""}
                      </span>
                      <span id="bundle1">
                        {item.bundleId == "10836660-07a5-4bfe-95c5-bff33d13c09d"
                          ? "halfoff"
                          : ""}
                      </span>
                      <span id="bundle2">
                        {item.bundleId == "c4229070-dc1c-4121-b5d7-d33231c24c20"
                          ? "thirtyoff"
                          : ""}
                      </span>
                      <span id="bundle3">
                        {item.bundleId == "519de2c1-84d3-49ab-a65a-d5e55c819d60"
                          ? "tenoff"
                          : ""}
                      </span>
                    </Card.Header>
                    <Card.Subtitle id="card_subtitle">
                      {item.description}
                    </Card.Subtitle>
                    <Card.Body id="card_body">
                      <img
                        src={item.imageURL}
                        width="150"
                        height="150"
                        id="candy_pic"
                      ></img>
                      <br></br>${item.price.toFixed(2)} per oz. <br></br>
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
