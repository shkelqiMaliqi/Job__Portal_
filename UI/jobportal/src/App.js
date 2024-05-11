import React from 'react';
import  {Route, Routes } from 'react-router-dom'; 
import Navbar from "./Navbar"
import Home from './components/Home';
import WhyUs from './components/WhyUs';
import ContactUs from './components/ContactUs';
import Profile from './components/Profile';
import Publish from './components/Publish'
import Register  from './components/Register';
import LoggedIn from './components/LoggedIn';
import LoginPage from './components/LoginPage';
import Cv from'./Cv_Form/Cv';

function App() {
  return (
    <>
      <Navbar />
      <div className="container">
        <Routes>
          <Route path="/home" element={<Home />} />
          <Route path="/whyus" element={<WhyUs />} />
          <Route path="/contactus" element={<ContactUs />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/register" element={<Register />} />
          <Route path="/publish" element={<Publish />} />
          <Route path="/loggedIn" element={<LoggedIn />} />
          <Route path="/loginPage" element={<LoginPage />} />
          <Route path="/cv" element={<Cv />} />
        </Routes>
      </div>
      <footer>

      </footer>
    </>
  )
}

export default App;
