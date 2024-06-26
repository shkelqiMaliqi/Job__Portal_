import React from 'react';
import axios from 'axios';

const AdminNavbar = () => {

    const handleLogout = async () => {
        try {
            const response = await axios.post('https://localhost:7263/api/users/logout');
            console.log('Logout response:', response); 
            console.log('Logout success:', response.data); 

          
            localStorage.removeItem('isLoggedIn');
            localStorage.removeItem('userData');

            window.location.href = "/mainpage";
        } catch (error) {
            console.error('Logout error:', error);
            alert('Logout failed. Please try again.'); 
        }
    };

    return (
        <nav className="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">
            <button id="sidebarToggleTop" className="btn btn-link d-md-none rounded-circle mr-3">
                <i className="fa fa-bars"></i>
            </button>
            
            <ul className="navbar-nav ml-auto">
                <li className="nav-item dropdown no-arrow">
                    <a className="nav-link dropdown-toggle" href="/" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span className="mr-2 d-none d-lg-inline text-gray-600 small">Log Out</span>
                    </a>
                    <div className="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                        <button className="dropdown-item" onClick={handleLogout}>
                            <i className="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                            Logout
                        </button>
                    </div>
                </li>
            </ul>
        </nav>
    );
}

export default AdminNavbar;
