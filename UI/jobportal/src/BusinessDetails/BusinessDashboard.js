import React from "react";
import { Link } from "react-router-dom"; 

const BusinessDashboard = () => {
    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Business Dashboard</h1>
            <div className="d-flex justify-content-center">
                {}
                <Link to="/listings" className="btn btn-primary mr-3">View Listings</Link>
                {}
                <Link to="/publish" className="btn btn-success">Publish</Link>
            </div>
        </div>
    );
};

export default BusinessDashboard;
