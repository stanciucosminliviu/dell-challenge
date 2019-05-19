import React, { Component } from "react";
import Validation from "../validation";
import { withRouter } from "react-router-dom";
import { createHashHistory } from 'history'
import createHistory from 'history/createBrowserHistory'
export const history = createHashHistory();
class Products extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    
    fetch("http://localhost:2534/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
      
  }

  componentDidUpdate(){
    fetch("http://localhost:2534/api/products")
    .then(res => res.json())
    .then(
      result => {
        this.setState({
          isLoaded: true,
          items: result
        });
      },
      // Note: it's important to handle errors here
      // instead of a catch() block so that we don't swallow
      // exceptions from actual bugs in components.
      error => {
        this.setState({
          isLoaded: true,
          error
        });
      }
    );
  }

  updateElement(id){
    console.log("update");
    this.props.history.push('/editproduct#/'+id);
  }

deleteElement=(id)=>{
  const requestOptions = {
    method: 'DELETE'
  };
  fetch("http://localhost:2534/api/products/"+id, requestOptions)
      .then(
        fetch("http://localhost:2534/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
          console.log(this.state);
          
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      )
      );
}

  render() {
    
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
        <div> <h1 className="display-4">Products</h1>
          <ul>
            {items.map(item => (
              <li key={item.id}>
                {item.name} - {item.category}
                <h1></h1>
                <button onClick={()=>this.deleteElement(item.id)} className="btn btn-danger">Delete</button>
                
                <button onClick={()=>this.updateElement(item.id)} className="btn btn-warning">Update</button>
                
              </li>
              
            ))}
            
          </ul></div>
      );
    }
  }
}


export default Products;
