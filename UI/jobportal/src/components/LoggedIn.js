import React, { useState, useEffect } from 'react';
import { Button, Form } from 'react-bootstrap';

const LoggedIn = ({ user, onLogout }) => {
  const [editMode, setEditMode] = useState(false);
  const [editedUser, setEditedUser] = useState({ ...user });

  useEffect(() => {
    fetchUserDetails();
  }, []);

  const fetchUserDetails = async () => {
    try {
      const response = await fetch(`https://localhost:7263/api/Users/${user.U_Id}`);
      if (response.ok) {
        const data = await response.json();
        setEditedUser(data); 
      } else {
        console.error('Failed to fetch user details');
      }
    } catch (error) {
      console.error('Error fetching user details:', error);
    }
  };

  const handleEdit = () => {
    setEditMode(true);
  };

  const handleCancel = () => {
    setEditMode(false);
    fetchUserDetails(); // Reset editedUser to original user data
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
    <div className='container mt-4'>
      <div className='d-flex justify-content-between align-items-center mb-4'>
        <h2>Profile Dashboard</h2>
        <Button variant='danger' onClick={onLogout}>Logout</Button>
      </div>

      {editMode ? (
        <Form>
          <Form.Group controlId='formName'>
            <Form.Label>Name:</Form.Label>
            <Form.Control type='text' name='U_Name' value={editedUser.U_Name} onChange={handleChange} />
          </Form.Group>

          <Form.Group controlId='formSurname'>
            <Form.Label>Surname:</Form.Label>
            <Form.Control type='text' name='U_Surname' value={editedUser.U_Surname} onChange={handleChange} />
          </Form.Group>

          <Form.Group controlId='formEmail'>
            <Form.Label>Email:</Form.Label>
            <Form.Control type='email' name='U_Email' value={editedUser.U_Email} onChange={handleChange} disabled />
          </Form.Group>

          <Form.Group controlId='formUsername'>
            <Form.Label>Username:</Form.Label>
            <Form.Control type='text' name='U_Username' value={editedUser.U_Username} onChange={handleChange} />
          </Form.Group>

          <Form.Group controlId='formPhone'>
            <Form.Label>Phone:</Form.Label>
            <Form.Control type='text' name='U_Phone' value={editedUser.U_Phone} onChange={handleChange} />
          </Form.Group>

          <Form.Group controlId='formPassword'>
            <Form.Label>Password:</Form.Label>
            <Form.Control type='password' name='U_Password' value={editedUser.U_Password} onChange={handleChange} />
          </Form.Group>
          
          {/* Add input fields for other user details */}

          <Button variant='primary' onClick={handleSave}>Save</Button>
          <Button variant='secondary' className='ml-2' onClick={handleCancel}>Cancel</Button>
        </Form>
      ) : (
        <div>
          <div className='mb-4'>
            <h3>Welcome, {user.U_Name}!</h3>
            <p>Email: {user.U_Email}</p>
            <p>Username: {user.U_Username}</p>
            <p>Phone: {user.U_Phone}</p>
          </div>
          <div>
            <Button variant='primary' onClick={handleEdit}>Edit Profile</Button>
            <Button variant='info' className='ml-2'>Create CV</Button> {/* Add link functionality */}
          </div>
        </div>
      )}
    </div>
  );
};

export default LoggedIn;
