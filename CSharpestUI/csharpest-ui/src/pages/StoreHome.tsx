import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "../App.css";

// use this to submit an item to cart
const addItemToCart = () => {
  const form = document.getElementById("form");

  form!.addEventListener("submit", (e) => {
    e.preventDefault();
  });

  const formData = new FormData();
  // change this from hardcoded to taking input from form
  formData.append("newItem", "apples");

  axios
    .post("https://localhost:7150/Cart/AddItemToCart", formData)
    .then((res) => console.log(res))
    .catch((err) => console.log(err));
};

function StoreHome() {
  const [itemList, setItemsList] = useState<any>([]);

  // we're getting the list of all items here in this GET request. It's stored in a JavaScript array. Use developer tools to view what it looks like. You'll must likely need to map it into table to display it onto the screen.
  const getItems = () => {
    axios
      .get("https://localhost:7150/Item/GetAllItems")
      .then((response) => {
        setItemsList(response.data);
      })
      .catch((error) => console.log(error));
  };

  // add to Cart POST request
  function addToCart() {
    const form = document.getElementById("form");

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    const formData = new FormData();
    formData.append("ItemID", "68df4339-7643-4365-9cf3-cd4e5f67419e");
    formData.append("Quantity", "6");

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
      <h1>Store Home</h1>
      {itemList.map(
        (item: {
          bogo: boolean;
          stock: number;
          price: number;
          description: string;
          name: string;
        }) => (
          <>
            <li>{item.name}</li>
            <li>{item.description}</li>
            <li>{item.price}</li>
            <li>{item.stock}</li>
            <li>{item.bogo ? "BOGO" : ""}</li>
            <li>
              <form id="form">
                <label>Quantity </label>
                <input></input>
                <button type="submit" onClick={addToCart}>
                  Add to Cart
                </button>
              </form>
            </li>
            <br></br>
          </>
        )
      )}
    </div>
  );
}

export default StoreHome;
