import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Validation from "../validation";

class NewProduct extends Component {
  constructor() {
    super();
    this.state = {
      Name: "",
      Category: "",
      Success: false,
      ErrorColor: "black"
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit = event => {
    event.preventDefault();
    let postData = {
      Name: this.state.Name,
      Category: this.state.Category
    };

    if(postData.Name!=""){

    fetch("http://localhost:2534/api/products", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors",
      body: JSON.stringify(postData)
    })
    .then(res => res.json())
    .then(this.props.history.push('/products'))
    .catch(err => console.log(err));
 
  }
  else{
    this.setState({ErrorColor: "red"});
  }
  };

  showError (){
    if(this.state.Name===""){
      return("This field is mandatory!");
    }
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <h4>Add new Product</h4>
        <div className="form-group">
          <label className="control-label" htmlFor="Name">
            Name
          </label>
         
          
          <input
            className="form-control"
            type="text"
            id="Name"
            name="Name"
            onChange={this.handleInputChange}
            value={this.state.Name}
          />
          
          <label style={{color: this.state.ErrorColor}}>
            {this.showError()}
          </label>

          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Name"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <label className="control-label" htmlFor="Category">
            Category
          </label>
          <input
            className="form-control"
            type="text"
            id="Category"
            name="Category"
            onChange={this.handleInputChange}
            value={this.state.Category}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Category"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <button className="btn btn-primary">Submit</button>
        </div>
        <Validation />
      </form>
    );
  }
}

export default NewProduct;
