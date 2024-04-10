import logo from './logo.svg';
import './App.css';
import {Component, Profiler } from 'react';
import {Home} from './Home';
import {WhyUs} from './WhyUs';
import {Publish} from './Publish';
import {ContactUs} from './ContactUs';
import {Profile} from './Profile';
import {Register} from './Register';
import { BrowserRouter, Route, Switch,NavLink } from 'react-router-dom';



function App(){
    return(
      <BrowserRouter>
      <div className="App container">
        <h3 className="d-flex justify-content-center m-3">
          React Js
        </h3>
        <nav className="navbar navbar-expand-sm bg-light navbar-dark">
          <ul className="navbar-nav">
              <li className="nav-item- m-1">
                <NavLink className="btn btn-light btn-outline-primary" to="/home">Home</NavLink>
              </li>

              <li className="nav-item- m-1">
                <NavLink className="btn btn-light btn-outline-primary" to="/WhyUs">Why Us</NavLink>
              </li>

              <li className="nav-item- m-1">
                <NavLink className="btn btn-light btn-outline-primary" to="/Publish">Publish</NavLink>
              </li>

              <li className="nav-item- m-1">
                <NavLink className="btn btn-light btn-outline-primary" to="/ContactUs">Contact Us</NavLink>
              </li>

              <li className="nav-item- m-1">
                <NavLink className="btn btn-light btn-outline-primary" to="/Profile">Profile</NavLink>
              </li>
          </ul>
        </nav>

        <Switch>
            <Route path='/home' component={Home}/>
            <Route path='/WhyUs' component={WhyUs}/>
            <Route path='/Publish' component={Publish}/>
            <Route path='/ContactUs' component={ContactUs}/>
            <Route path='/Profile' component={Profile}/>
        </Switch>
      </div>
      </BrowserRouter>
      
);
}
export default App;
