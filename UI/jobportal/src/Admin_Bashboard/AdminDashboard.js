import React from 'react';
import AdminSidebar from './AdminSidebar';
import AdminNavbar from './AdminNavbar';
import AdminFooter from './AdminFooter';

const AdminDashboard = () => {
    return (
        <div id="admin_wrapper">
            {/* Sidebar */}
            <AdminSidebar />
            {/* Content Wrapper */}
            <div id="admin_content-wrapper" className="d-flex flex-column">
                {/* Main Content */}
                <div id="content">
                    <AdminNavbar />
                    <div className="admin_container-fluid">
                       
                    </div>
                </div>
          
            </div>
        </div>
    );
}

export default AdminDashboard;
