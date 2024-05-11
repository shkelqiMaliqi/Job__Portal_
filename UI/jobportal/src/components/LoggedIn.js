import React, { useState, useEffect } from 'react';

const LoggedIn = ({ user, onLogout }) => {
  const [editMode, setEditMode] = useState(false);
  const [editedUser, setEditedUser] = useState({ ...user });

  useEffect(() => {
    setEditedUser({ ...user });
  }, [user]);

  const handleEdit = () => {
    setEditMode(true);
  };

  const handleCancel = () => {
    setEditMode(false);
  };

  const handleSave = async () => {
    try {
      const response = await fetch(`https://localhost:7263/api/Users/${user.U_Id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(editedUser),
      });
      if (response.ok) {
        console.log('User updated successfully');
        setEditMode(false);
        // You might want to update the user state here if needed
      } else {
        console.error('Failed to update user');
      }
    } catch (error) {
      console.error('Error updating user:', error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedUser({ ...editedUser, [name]: value });
  };

  return (
    <div className='logged-in-container'>
      {editMode ? (
        <div className='edit-mode'>
          <h2>Edit Profile</h2>
          <div className='form-group'>
            <label>Name:</label>
            <input type='text' name='U_Name' value={editedUser.U_Name} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label>Surname:</label>
            <input type='text' name='U_Surname' value={editedUser.U_Surname} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label>Email:</label>
            <input type='text' name='U_Email' value={editedUser.U_Email} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label>Username:</label>
            <input type='text' name='U_Username' value={editedUser.U_Username} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label>Phone:</label>
            <input type='text' name='U_Phone' value={editedUser.U_Phone} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label>Password:</label>
            <input type='password' name='U_Password' value={editedUser.U_Password} onChange={handleChange} />
          </div>
          {/* Add input fields for other user details */}
          <button onClick={handleSave}>Save</button>
          <button onClick={handleCancel}>Cancel</button>
        </div>
      ) : (
        <div className='view-mode'>
          <div className='user-details'>
            <h2>Welcome, {user.U_Email}!</h2>
            <p>Email: {user.U_Email}</p>
            <p>Username: {user.U_Username}</p>
            <p>Phone: {user.U_Phone}</p>
          </div>
          <div className='buttons-container'>
            <button className='logout-button' onClick={onLogout}>Logout</button>
            <button className='edit-button' onClick={handleEdit}>Edit Profile</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default LoggedIn;
