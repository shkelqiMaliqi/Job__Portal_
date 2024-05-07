import React, { useState } from 'react';
import Profile from './Profile';

const LoginPage = () => {
    const [loggedInUserId, setLoggedInUserId] = useState(null);

    const handleLogin = (userId) => {
        setLoggedInUserId(userId);
      
        window.location.href = '/LoggedIn';
    };

    return (
        <div>
            {loggedInUserId ? (
                <p>You are already logged in. Redirecting...</p>
            ) : (
                <Profile onLogin={handleLogin} />
            )}
        </div>
    );
};

export default LoginPage;
