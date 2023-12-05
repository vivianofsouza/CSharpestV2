import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import axios from "axios";
import Nav from "react-bootstrap/Nav"; // Using bootstrap, pre-made HTML components for React projects. import components one by one as needed
import "./StoreHome.css";
import { UUID } from "crypto";

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
  function addToCart() {
    const form = document.getElementById("form");

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    const formData = new FormData();
    const itemID = (document.getElementById("ItemID") as HTMLInputElement)
      .value;
    const quantity = (document.getElementById("Quantity") as HTMLInputElement)
      .value;
    formData.append("ItemID", itemID);
    formData.append("Quantity", quantity);

    axios
      .post("https://localhost:7150/Cart/AddItemToCart", formData)
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }

  // const getUsers = async () => {
  //   const params = {
  //     page: 1,
  //     limit: 10,
  //     sort: 'name',
  //   };
  //   try {
  //     const response = await axios.get(baseURL, { params });
  //     const users = response.data;
  //     console.log(users);
  //   } catch (error) {
  //     console.error('Error fetching users:', error);
  //   }
  // };

  useEffect(() => {
    getItems();
  }, []);
  return (
    <div>
      <h1 id="shop_header">Shop the CSharpest Store</h1>

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

      {itemList.map(
        (item: {
          itemId: UUID;
          bogo: boolean;
          stock: number;
          price: number;
          description: string;
          name: string;
          imageURL: string;
        }) => (
          <>
            <li>{item.name}</li>
            <li>{item.description}</li>
            <li>{item.price}</li>
            <li>{item.stock}</li>
            <li>{item.bogo ? "BOGO" : ""}</li>
            <li>
              <img src={item.imageURL} width="200" height="200"></img>
            </li>
            <li>
              <form id="form">
                <label>Quantity</label>
                <input id="Quantity"></input>
                <input type="hidden" id="ItemID" value={item.itemId}></input>

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
