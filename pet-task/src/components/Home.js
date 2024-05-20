import React, { useState } from "react";
import axios from "axios";
import { Select, MenuItem, TextField } from "@mui/material";
import "../css/Home.css";

const Home = () => {
  const [name, setName] = useState("");
  const [color, setColor] = useState("#000000");
  const [age, setAge] = useState("");
  const [type, setType] = useState("");
  const [loading, setLoading] = useState(false);
  //   const [pets, setPets] = useState("");

  //Add new pet
  const handleSubmit = (event) => {
    setLoading(true);
    axios
      .post("https://localhost:7210/api/pet", {
        name: name,
        color: color,
        age: age,
        type: type,
      })
      .then((response) => {
        console.log("Pet added successfully", response.data);
        setLoading(false);
        setName("");
        setColor("");
        setAge("");
        setType("");
      })
      .catch((err) => {
        console.log("Error adding task:", err);
      });
  };

  //Get all pets
  //   const handlePetsButton = () => {
  //     axios
  //       .get("https://localhost:7210/api/pet")
  //       .then((response) => {
  //         setPets(response.data.pets);
  //       })
  //       .catch((err) => {
  //         console.log("Error adding task:", err);
  //       });
  //   };

  return (
    <div className="home-container">
      <h2>Create a new pet</h2>
      {loading ? (
        <h2>Loading...</h2>
      ) : (
        <form onSubmit={handleSubmit} className="input-form">
          <TextField
            type="text"
            inputProps={{ maxLength: 25 }}
            value={name}
            onChange={(e) => setName(e.target.value)}
            label="Name"
            fullWidth
          />
          <TextField
            type="color"
            value={color}
            onChange={(e) => setColor(e.target.value)}
            fullWidth
          />
          <TextField
            type="number"
            inputProps={{ min: 0, max: 20 }}
            value={age}
            onChange={(e) => setAge(e.target.value)}
            label="Age"
            fullWidth
          />
          <Select
            label="Select type"
            value={type}
            onChange={(e) => setType(e.target.value)}
            fullWidth
          >
            <MenuItem value={"Dog"}>Dog</MenuItem>
            <MenuItem value={"Cat"}>Cat</MenuItem>
            <MenuItem value={"Horse"}>Horse</MenuItem>
            <MenuItem value={"Other"}>Other</MenuItem>
          </Select>
          <button type="submit" className="submit-button">
            Add Pet
          </button>
        </form>
      )}
    </div>
  );
};

export default Home;
