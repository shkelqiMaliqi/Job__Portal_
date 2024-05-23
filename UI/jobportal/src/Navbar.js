import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';


export default function Navbar() {
    return (
        <nav className="nav navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link to="/MainPage" className="navbar-brand site-title">
                    Job Portal
                </Link>
                <div className="collapse navbar-collapse justify-content-center">
                    <ul className="navbar-nav">
                        <CustomLink to="/Whyus">Why Us</CustomLink>
                        <CustomLink to="/Publish">Publish</CustomLink>
                        <CustomLink to="/Contactus">Contact Us</CustomLink>
                        <CustomLink to="/Career">Career</CustomLink>
                    </ul>
                </div>
                <Link to="/Profile" className="nav-link site-profile">
                    Profile
                </Link>
            </div>
        </nav>
    );
}

function CustomLink({ to, children, ...props }) {
    const path = window.location.pathname;

    return (
        <li className={`nav-item ${path === to ? 'active' : ''}`}>
            <Link to={to} className="nav-link" {...props}>
                {children}
            </Link>
        </li>
    );
}
