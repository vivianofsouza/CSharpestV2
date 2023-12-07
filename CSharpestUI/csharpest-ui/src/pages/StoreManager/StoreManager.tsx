import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./StoreManager.css";
import { UUID } from "crypto";
import NavBar from "../../components/Navbar";
import Row from "react-bootstrap/esm/Row";
import Col from "react-bootstrap/esm/Col";
import Card from "react-bootstrap/esm/Card";
import Container from "react-bootstrap/esm/Container";
import UserConstants from "../../UserConstants";

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

  function modifyPrice(fromFormItem: string) {
    const formData = new FormData();

    const itemID = (
      document.getElementById(`itemId-${fromFormItem}`) as HTMLInputElement
    ).value;

    const price = (
      document.getElementById(`price-${fromFormItem}`) as HTMLInputElement
    ).value;

    const form = document.getElementById(`form-${fromFormItem}`);

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    formData.append("ItemId", itemID);
    formData.append("Price", price);

    axios
      .patch("https://localhost:7150/Item/ChangePrice", formData)
      .then((response) => {
        alert("Item price successfully changed.");
      })
      .catch((error) => console.log(error));
  }

  function modifyStock(fromFormItem: string) {
    const formData = new FormData();

    const itemID = (
      document.getElementById(`itemId-${fromFormItem}`) as HTMLInputElement
    ).value;

    const stock = (
      document.getElementById(`stock-${fromFormItem}`) as HTMLInputElement
    ).value;

    const form = document.getElementById(`form-${fromFormItem}`);

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    formData.append("ItemId", itemID);
    formData.append("Stock", stock);

    axios
      .patch("https://localhost:7150/Item/ChangeStock", formData)
      .then((response) => {
        alert("Item stock successfully changed.");
      })
      .catch((error) => console.log(error));
  }

  useEffect(() => {
    getItems();
  }, []);
  return (
    <>
      <NavBar></NavBar>
      <div>
        <h1 id="store_manager_header">Manage the CSharpest Store Now</h1>
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
                        <span id="bundle">{item.bundleId ? "BOGO" : ""}</span>
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
                          <input
                            type="hidden"
                            id={`itemId-${item.id}`}
                            value={item.id}
                          ></input>

                          <div id="rowone">
                            <label id="price">New Price</label>
                            <input id={`price-${item.id}`} className ="answer"></input>

                            <button
                              id="modifyPrice"
                              type="submit"
                              onClick={() => modifyPrice(item.id)}
                            >
                              Modify Price
                            </button>
                          </div>

                          <div id="rowtwo">
                            <label id="stock">New Stock</label>
                            <input id={`stock-${item.id}`} className="answer"></input>

                            <button
                              id="modifyStock"
                              type="submit"
                              onClick={() => modifyStock(item.id)}
                            >
                              Modify Stock
                            </button>
                          </div>

                          <div id="rowthree">

                            <button
                              id="deleteItem"
                              type="submit"
                              onClick={() => modifyStock(item.id)}
                            >
                              Delete Item
                            </button>
                          </div>
                        </form>
                      </Card.Footer>
                    </Card>
                  </Col>
                </>
              )
            )}
          </Row>
        </Container>

      <Card id="add_item_card">
        <Card.Header id="add_item_header">
          Add New Item to CSharpest Store
        </Card.Header>
        <Card.Body id="add_item_body">
          <Card.Text id="add_item_text">
            <form id="payment_form">
              <label id="label2">Item Name</label>
              <br></br>
              <input id="input"></input>
              <br></br>

              <label id="label2">Item Description</label>
              <br></br>
              <input id="input"></input>
              <br></br>

              <label id="label2">Item Price (per oz.)</label>
              <br></br>
              <input id="input"></input>
              <br></br>

              <label id="label2">Stock</label>
              <br></br>
              <input id="input"></input>
              <br></br>

              <label id="label2">Sale</label>
              <br></br>
              <input id="input"></input>
              <br></br>

              <button type="submit" id="add_item_button">
                Add Item to CSharpest Store
              </button>
            </form>
          </Card.Text>
        </Card.Body>
      </Card>
      </div>
    </>
  );
}

export default StoreHome;
