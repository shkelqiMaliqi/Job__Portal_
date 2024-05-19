import React from 'react';
import  {Route, Routes } from 'react-router-dom'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
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
<<<<<<< HEAD
import NormalorBusiness from './components/NormalorBusiness';
=======
import Jobs_Publish from './Jobs_Repository/Jobs_Publish';
import MainPage from './components/MainPage';
import BusinessDashboard from './BusinessDetails/BusinessDashboard';
>>>>>>> 26f4599b4b8fa81780ac09eb2a38791c5d237a5c

function App() {
  return (
    <>
      <Navbar />
      <div className="container">
        <Routes>
          <Route path="/mainpage" element={<MainPage />} />
          <Route path="/home" element={<Home />} />
          <Route path="/whyus" element={<WhyUs />} />
          <Route path="/contactus" element={<ContactUs />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/register" element={<Register />} />
          <Route path="/publish" element={<Publish />} />
          <Route path="/loggedIn" element={<LoggedIn />} />
          <Route path="/loginPage" element={<LoginPage />} />
          <Route path="/cv" element={<Cv />} />
<<<<<<< HEAD
          <Route path="/normalorbusiness" element={<NormalorBusiness />} />

=======
          <Route path="/jobs_publish" element={<Jobs_Publish />} />
          <Route path="/businessdashboard" element={<BusinessDashboard />} />
>>>>>>> 26f4599b4b8fa81780ac09eb2a38791c5d237a5c
        </Routes>
      </div>
      <footer>

      </footer>
    </>
  )
}

export default App;
