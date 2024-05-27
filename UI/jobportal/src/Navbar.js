import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ReactComponent as MenuIcon } from './menu.svg'; 

export default function Navbar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light" style={{ background: 'linear-gradient(20deg, #ccffcc, lightblue)' }}>
            <div className="container-fluid">
                <Link to="/MainPage" className="navbar-brand site-title">
                    Job Portal
                </Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <MenuIcon width="30" height="30" />
                </button>
                <div className="collapse navbar-collapse justify-content-center" id="navbarNav">
                    <ul className="navbar-nav">
                        <CustomLink to="/Whyus">Why Us</CustomLink>
                        <CustomLink to="/Publish">Publish</CustomLink>
                        <CustomLink to="/Contactus">Contact Us</CustomLink>
                        <CustomLink to="/Career">Career</CustomLink>
                    </ul>
                </div>
                <Link to="/LoginPage" className="nav-link site-profile">
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
