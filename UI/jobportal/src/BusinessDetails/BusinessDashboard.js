import React from "react";
import { Link } from "react-router-dom";
import axios from "axios";

const BusinessDashboard = () => {
    const handleLogout = async () => {
        try {
            await axios.post("https://localhost:7263/api/Users/logout");

            // Clear local storage or state as needed
            localStorage.removeItem('isLoggedIn');
            localStorage.removeItem('userData');

            console.log("Logged out successfully");
            
            // Redirect to login or homepage
            window.location.href = "/mainpage";
        } catch (error) {
            console.error("Logout error:", error);
        }
    };

    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Business Dashboard</h1>
            <div className="row">
                <div className="col-12">
                    <button onClick={handleLogout} className="btn btn-danger btn-lg align-end">
                        Logout
                    </button>
                </div>
                <div className="col-12 mt-3">
                    <Link to="/jobs_listings" className="btn btn-primary btn-lg btn-block">
                        View Listings
                    </Link>
                </div>
                <div className="col-12 mt-3">
                    <Link to="/publish" className="btn btn-success btn-lg btn-block">
                        Publish
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default BusinessDashboard;
