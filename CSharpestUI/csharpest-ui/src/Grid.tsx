import React, { Component, useEffect, useState } from "react";
import { render } from "react-dom";

import Container from "react-bootstrap/esm/Container";
import Row from "react-bootstrap/esm/Row";
import Col from "react-bootstrap/esm/Col";
import Card from "react-bootstrap/esm/Card";
import "./App.css";
import "bootstrap/dist/css/bootstrap.css";
import axios from "axios";
import { UUID } from "crypto";
import NavBar from "./components/Navbar";

function Grid() {
  const [itemList, setItemsList] = useState<any>([]);

  const getItemsByStock = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItemsStockSort")
      .then((response) => {
        setItemsList(response.data);
        console.log(response.data);
      })
      .catch((error) => console.log(error));
  };

  useEffect(() => {
    getItemsByStock();
  }, []);

  return (
    <div>
      <NavBar></NavBar>
      <Container>
        <Row>
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
                  <Card id="card">
                    <Card.Header>{item.name}</Card.Header>
                    <Card.Subtitle>{item.description}</Card.Subtitle>
                    <Card.Body>
                      <img src={item.imageURL} width="150" height="150"></img>
                      <br></br>${item.price} per oz.{" "}
                      {item.bundleId ? "BOGO" : ""}
                      <br></br>
                      {item.stock} left in stock
                      <br></br>
                    </Card.Body>

                    <Card.Footer>
                      <form id={`form-${item.id}`}>
                        <label>Quantity</label>
                        <input id={`quantity-${item.id}`}></input>
                        <input
                          type="hidden"
                          id={`itemId-${item.id}`}
                          value={item.id}
                        ></input>

                        <button type="submit">Add to Cart</button>
                      </form>
                    </Card.Footer>

                    <br></br>
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

export default Grid;
