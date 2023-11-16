import React from "react";
import logo from "./logo.svg";
import axios from "axios";
import "./App.css";

function App() {
  const handleChange = (event: { target: { value: any } }) => {
    console.log("good");
  };
  const handleSubmit = (event: { preventDefault: () => void }) => {
    event.preventDefault();

    const post = {
      newItem: "sdfsd",
    };
    axios
      .post(`https://localhost:7201/Item/AddItem?newItem=apples`)
      .then((res) => {
        console.log(res);
        console.log(res.data);
      });
  };

  function sendWithForm() {
    console.log("yes");
    const form = document.getElementById("form");

    form!.addEventListener("submit", (e) => {
      e.preventDefault();
    });

    const formData = new FormData();
    formData.append("newItem", "apples");

    axios
      .post("https://localhost:7201/Cart/AddItemToCart", formData)
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }

  return (
    <div>
      <form id="form">
        <input
          name="ItemID"
          value="68df4339-7643-4365-9cf3-cd4e5f67419e"
        ></input>
        <input name="Quantity" value="25"></input>
        <button type="submit" onClick={sendWithForm}>
          Add
        </button>
      </form>
      {/* <form onSubmit={handleSubmit}>
        <label>
          Post Name:
          <input type="text" name="name" onChange={handleChange} />
        </label>
        <button type="submit">Add</button>
      </form> */}
    </div>
  );
}

export default App;
