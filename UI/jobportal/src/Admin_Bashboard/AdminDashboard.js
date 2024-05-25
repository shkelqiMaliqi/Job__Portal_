import React from 'react';
import AdminSidebar from './AdminSidebar';
import AdminNavbar from './AdminNavbar';
import AdminFooter from './AdminFooter';

const AdminDashboard = () => {
    return (
        <div id="wrapper">
            {/* Sidebar */}
            <AdminSidebar />
            {/* Content Wrapper */}
            <div id="content-wrapper" className="d-flex flex-column">
                {/* Main Content */}
                <div id="content">
                    <AdminNavbar />
                    <div className="container-fluid">
                        <h1 className="h3 mb-4 text-gray-800">Dashboard</h1>
                    </div>
                </div>
                {/* Footer */}
                <AdminFooter />
            </div>
        </div>
    );
}

export default AdminDashboard;
