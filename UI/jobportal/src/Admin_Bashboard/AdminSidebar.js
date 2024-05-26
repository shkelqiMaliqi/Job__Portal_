import React from 'react';
import { Link } from 'react-router-dom';

const AdminSidebar = () => {
    return (
        <ul className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar" style={{ height: "100vh", position: "fixed" }}>
            <li className="nav-item active">
                <Link className="nav-link" to="/">
                    <i className="fas fa-fw fa-tachometer-alt"></i>
                    <span>Dashboard</span>
                </Link>
            </li>
            <hr className="sidebar-divider" />
           
            <li className="nav-item">
                <Link className="nav-link" to="/profile">
                    <i className="fas fa-fw fa-user"></i>
                    <span>Users</span>
                </Link>
            </li>

            <li className="nav-item">
                <Link className="nav-link" to="/BusinessDashboard">
                    <i className="fas fa-fw fa-building"></i>
                    <span>Businesses</span>
                </Link>
            </li>

            <li className="nav-item">
                <Link className="nav-link" to="/publish">
                    <i className="fas fa-fw fa-briefcase"></i>
                    <span>Job Listings</span>
                </Link>
            </li>

            <hr className="sidebar-divider" />

            {/* Dropdown Example */}
            <li className="nav-item">
                <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseCourses" aria-expanded="true" aria-controls="collapseCourses">
                    <i className="fas fa-fw fa-book"></i>
                    <span>Courses</span>
                </a>
                <div id="collapseCourses" className="collapse" aria-labelledby="headingCourses" data-parent="#accordionSidebar">
                    <div className="bg-white py-2 collapse-inner rounded">
                        <Link className="collapse-item" to="/trainingcourses">Training Courses</Link>
                        <Link className="collapse-item" to="/workshops">Workshops</Link>
                        {/* Add more links as needed */}
                    </div>
                </div>
            </li>

            <li className="nav-item">
                <Link className="nav-link" to="/staff">
                    <i className="fas fa-fw fa-users"></i>
                    <span>Staff</span>
                </Link>
            </li>
        </ul>
    );
}

export default AdminSidebar;
