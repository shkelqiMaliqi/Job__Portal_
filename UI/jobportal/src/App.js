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
import NormalorBusiness from './components/NormalorBusiness';
import MainPage from './components/MainPage';
import TrainingCourses from './Courses/TrainingCourses';
import Career from './components/Career';
import CourseApply_Form from './Courses/CourseApply_Form';
import AdminDashboard from './Admin_Bashboard/AdminDashboard';
import AdminSidebar from './Admin_Bashboard/AdminSidebar';
import AdminNavbar from './Admin_Bashboard/AdminNavbar';
import AdminFooter from './Admin_Bashboard/AdminFooter';

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
          <Route path="/normalorbusiness" element={<NormalorBusiness />} />
          <Route path="/mainpage" element={<MainPage />} />
          <Route path="/trainingcourses" element={<TrainingCourses />} />
          <Route path="/career" element={<Career />} />
          <Route path="/CourseApply_Form" element={<CourseApply_Form />} />
          <Route path="/admindashboard" element={<AdminDashboard />} />
          <Route path="/adminsidebar" element={<AdminSidebar />} />
          <Route path="/adminnavbar" element={<AdminNavbar />} />
          <Route path="/adminfooter" element={<AdminFooter />} />


        </Routes>
      </div>
      <footer>

      </footer>
    </>
  )
}

export default App;
