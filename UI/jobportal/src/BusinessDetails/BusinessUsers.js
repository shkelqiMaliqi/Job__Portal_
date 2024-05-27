import React, { useState, useEffect } from 'react';
import axios from 'axios';

const BusinessUsers = () => {
  const [businessUsers, setBusinessUsers] = useState([]);
  const [editedUser, setEditedUser] = useState({
    U_ID: '',
    U_Name: '',
    U_Surname: '',
    U_Email: '',
    U_Username: '',
    U_Phone: ''
  });

  useEffect(() => {
    fetchBusinessUsers();
  }, []);

  const fetchBusinessUsers = () => {
    axios.get('https://localhost:7263/api/users')
      .then(response => {
        const allUsers = response.data;
        const filteredUsers = allUsers.filter(user => user.U_Type === 'business');
        setBusinessUsers(filteredUsers);
      })
      .catch(error => {
        console.error('Error fetching business users: ', error);
      });
  };

  const handleEdit = (user) => {
    setEditedUser(user);
  };

  const handleUpdate = () => {
    axios.put(`https://localhost:7263/api/users/${editedUser.U_ID}`, editedUser)
      .then(response => {
        console.log(response.data);
        fetchBusinessUsers(); // Refresh business users list after update
        setEditedUser({  // Reset editedUser state after successful update
          U_ID: '',
          U_Name: '',
          U_Surname: '',
          U_Email: '',
          U_Username: '',
          U_Phone: ''
        });
      })
      .catch(error => {
        console.error('Error updating user: ', error);
      });
  };

  const handleDelete = (id) => {
    axios.delete(`https://localhost:7263/api/users/${id}`)
      .then(response => {
        console.log(response.data);
        fetchBusinessUsers(); // Refresh business users list after deletion
      })
      .catch(error => {
        console.error('Error deleting user: ', error);
      });
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedUser({
      ...editedUser,
      [name]: value
    });
  };

  return (
    <div>
      <h2>Business Users</h2>
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
            <th>Username</th>
            <th>Phone</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {businessUsers.map(user => (
            <tr key={user.U_ID}>
              <td>{user.U_ID}</td>
              <td>{user.U_Name}</td>
              <td>{user.U_Surname}</td>
              <td>{user.U_Email}</td>
              <td>{user.U_Username}</td>
              <td>{user.U_Phone}</td>
              <td>
                <button className="btn btn-primary mr-2" onClick={() => handleEdit(user)}>Edit</button>
                <button className="btn btn-danger" onClick={() => handleDelete(user.U_ID)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Example form for editing user details */}
      {editedUser.U_ID &&
        <div className="mt-3">
          <h3>Edit Business User</h3>
          <form onSubmit={(e) => { e.preventDefault(); handleUpdate(); }}>
            <div className="form-group">
              <label>Name</label>
              <input type="text" className="form-control" name="U_Name" value={editedUser.U_Name} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Surname</label>
              <input type="text" className="form-control" name="U_Surname" value={editedUser.U_Surname} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Email</label>
              <input type="email" className="form-control" name="U_Email" value={editedUser.U_Email} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Username</label>
              <input type="text" className="form-control" name="U_Username" value={editedUser.U_Username} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Phone</label>
              <input type="text" className="form-control" name="U_Phone" value={editedUser.U_Phone} onChange={handleChange} />
            </div>
            <button type="submit" className="btn btn-success">Update</button>
          </form>
        </div>
      }
    </div>
  );
};

export default BusinessUsers;
