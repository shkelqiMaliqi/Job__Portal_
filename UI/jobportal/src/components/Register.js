import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Register = () => {
  const [formData, setFormData] = useState({
    U_Name: '',
    U_Surname: '',
    U_Email: '',
    U_Username: '',
    U_Phone: '',
    U_Password: '',
    U_RepeatPassword: '',
    U_Type: 'user', 
  });

  const [errors, setErrors] = useState({});
  const navigate = useNavigate();

  const handleInputChange = (e) => {
    setFormData({ ...formData, [e.target.id]: e.target.value });
  };

  const validateForm = (data) => {
    let errors = {};

    if (!data.U_Name.trim()) {
      errors.U_Name = 'Name is required';
    }
    if (!data.U_Surname.trim()) {
      errors.U_Surname = 'Surname is required';
    }
    if (!data.U_Email.trim()) {
      errors.U_Email = 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(data.U_Email)) {
      errors.U_Email = 'Email address is invalid';
    }
    if (!data.U_Username.trim()) {
      errors.U_Username = 'Username is required';
    }
    if (!data.U_Phone.trim()) {
      errors.U_Phone = 'Phone Number is required';
    } else if (!/^\d{9}$/.test(data.U_Phone)) {
      errors.U_Phone = 'Phone number should be 9 digits';
    }
    if (!data.U_Password.trim()) {
      errors.U_Password = 'Password is required';
    } else if (data.U_Password.trim().length < 6) {
      errors.U_Password = 'Password must be at least 6 characters long';
    }
    if (!data.U_RepeatPassword.trim()) {
      errors.U_RepeatPassword = 'Repeat password is required';
    } else if (data.U_Password !== data.U_RepeatPassword) {
      errors.U_RepeatPassword = 'Passwords do not match';
    }

    return errors;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const validationErrors = validateForm(formData);
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
      const response = await axios.post('https://localhost:7263/api/users', formData);
      console.log('Registration successful:', response.data);
      navigate('/loginpage');
    } catch (error) {
      console.error('Registration failed:', error);
    }
  };

  return (
    <div className="mask d-flex align-items-center h-100 gradient-custom-3">
      <div className="container h-100">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="col-12 col-md-9 col-lg-7 col-xl-6">
            <div className="card" style={{ borderRadius: '15px' }}>
              <div className="card-body p-5">
                <h2 className="text-uppercase text-center mb-5">Create an account</h2>
                <form onSubmit={handleSubmit}>
                  {/* Name */}
                  <div className="form-outline mb-4">
                    <input
                      type="text"
                      id="U_Name"
                      className={`form-control form-control-lg ${errors.U_Name ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_Name}
                    />
                    <label className="form-label" htmlFor="U_Name">Your Name</label>
                    {errors.U_Name && <div className="invalid-feedback">{errors.U_Name}</div>}
                  </div>

                  {/* Surname */}
                  <div className="form-outline mb-4">
                    <input
                      type="text"
                      id="U_Surname"
                      className={`form-control form-control-lg ${errors.U_Surname ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_Surname}
                    />
                    <label className="form-label" htmlFor="U_Surname">Your Surname</label>
                    {errors.U_Surname && <div className="invalid-feedback">{errors.U_Surname}</div>}
                  </div>

                  {/* Email */}
                  <div className="form-outline mb-4">
                    <input
                      type="email"
                      id="U_Email"
                      className={`form-control form-control-lg ${errors.U_Email ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_Email}
                    />
                    <label className="form-label" htmlFor="U_Email">Your Email</label>
                    {errors.U_Email && <div className="invalid-feedback">{errors.U_Email}</div>}
                  </div>

                  {/* Username */}
                  <div className="form-outline mb-4">
                    <input
                      type="text"
                      id="U_Username"
                      className={`form-control form-control-lg ${errors.U_Username ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_Username}
                    />
                    <label className="form-label" htmlFor="U_Username">Your Username</label>
                    {errors.U_Username && <div className="invalid-feedback">{errors.U_Username}</div>}
                  </div>

                  {/* Phone Number */}
                  <div className="form-outline mb-4">
                    <input
                      type="text"
                      id="U_Phone"
                      className={`form-control form-control-lg ${errors.U_Phone ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_Phone}
                    />
                    <label className="form-label" htmlFor="U_Phone">Your Phone Number</label>
                    {errors.U_Phone && <div className="invalid-feedback">{errors.U_Phone}</div>}
                  </div>

                  {/* Password */}
                  <div className="form-outline mb-4">
                    <input
                      type="password"
                      id="U_Password"
                      className={`form-control form-control-lg ${errors.U_Password ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_Password}
                    />
                    <label className="form-label" htmlFor="U_Password">Your Password</label>
                    {errors.U_Password && <div className="invalid-feedback">{errors.U_Password}</div>}
                  </div>

                  {/* Repeat Password */}
                  <div className="form-outline mb-4">
                    <input
                      type="password"
                      id="U_RepeatPassword"
                      className={`form-control form-control-lg ${errors.U_RepeatPassword ? 'is-invalid' : ''}`}
                      onChange={handleInputChange}
                      value={formData.U_RepeatPassword}
                    />
                    <label className="form-label" htmlFor="U_RepeatPassword">Repeat Password</label>
                    {errors.U_RepeatPassword && <div className="invalid-feedback">{errors.U_RepeatPassword}</div>}
                  </div>

                  {/* Select User Type */}
                  <div className="form-outline mb-4">
                    <select
                      id="U_Type"
                      className="form-select form-select-lg"
                      onChange={handleInputChange}
                      value={formData.U_Type}
                    >
                      <option value="user">User</option>
                      <option value="business">Business</option>
                      
                    </select>
                  </div>

                  {/* Register button */}
                  <div className="d-grid">
                    <button type="submit" className="btn btn-success btn-lg gradient-custom-4 text-body">Register</button>
                  </div>

                  {/* Login link */}
                  <p className="text-center text-muted mt-5 mb-0">
                    Already have an account? <a href="./loginpage" className="fw-bold text-body"><u>Login here</u></a>
                  </p>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Register;
