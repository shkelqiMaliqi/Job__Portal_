import React, { useState } from 'react';
import axios from 'axios';

function Business() {
  const [formData, setFormData] = useState({
    B_CompanyName: '',
    B_Email: '',
    B_PhoneNumber: '',
    B_Password: '',
    B_RepeatPassword: '',
    role: 'BusinessUser'  
  });

  const [errors, setErrors] = useState({});

  const handleInputChange = (e) => {
    setFormData({ ...formData, [e.target.id]: e.target.value });
  };

  const handleRoleChange = (e) => {
    setFormData({ ...formData, role: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const validationErrors = validateForm(formData);
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
      await axios.post('https://localhost:7263/api/business', formData);
      window.location.href = '/profile'; // Redirect to profile page after successful registration
    } catch (error) {
      console.error('Registration failed:', error);
    }
  };

  const validateForm = (data) => {
    let errors = {};

    if (!data.B_CompanyName.trim()) {
      errors.B_CompanyName = 'Company Name is required';
    } else if (!data.B_Email.trim()) {
      errors.B_Email = 'Email is required';
    } else if (!data.B_PhoneNumber.trim()) {
      errors.B_PhoneNumber = 'Phone Number is required';
    } else if (!data.B_Password.trim()) {
      errors.B_Password = 'Password is required';
    } else if (!data.B_RepeatPassword.trim()) {
      errors.B_RepeatPassword = 'Repeat password is required';
    }

    return errors;
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
                  <div className="form-outline mb-4">
                    <input type="text" id="B_CompanyName" className={`form-control form-control-lg ${errors.B_CompanyName ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                    <label className="form-label" htmlFor="U_Name">Your Company Name</label>
                    {errors.B_CompanyName && <div className="invalid-feedback">{errors.B_CompanyName}</div>}
                  </div>

                  <div className="form-outline mb-4">
                    <input type="email" id="B_Email" className={`form-control form-control-lg ${errors.B_Email ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                    <label className="form-label" htmlFor="B_Email">Your Email</label>
                    {errors.B_Email && <div className="invalid-feedback">{errors.B_Email}</div>}
                  </div>

                  <div className="form-outline mb-4">
                    <input type="text" id="B_PhoneNumber" className={`form-control form-control-lg ${errors.B_PhoneNumber ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                    <label className="form-label" htmlFor="B_PhoneNumber">Your Phone no</label>
                    {errors.B_PhoneNumber && <div className="invalid-feedback">{errors.B_PhoneNumber}</div>}
                  </div>

                  <div className="form-outline mb-4">
                    <input type="password" id="B_Password" className={`form-control form-control-lg ${errors.B_Password ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                    <label className="form-label" htmlFor="B_Password">Your Password</label>
                    {errors.B_Password && <div className="invalid-feedback">{errors.B_Password}</div>}
                  </div>

                  <div className="form-outline mb-4">
                    <input type="password" id="B_RepeatPassword" className={`form-control form-control-lg ${errors.B_RepeatPassword ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                    <label className="form-label" htmlFor="B_RepeatPassword">Repeat Password</label>
                    {errors.B_RepeatPassword && <div className="invalid-feedback">{errors.B_RepeatPassword}</div>}
                  </div>

                  <div className="d-flex justify-content-center">
                    <button type="submit" className="register_btn btn-success btn-block btn-lg gradient-custom-4 text-body">Register</button>
                  </div>

                  <p className="text-center text-muted mt-5 mb-0">Already have an account? <a href="./profile" className="fw-bold text-body"><u>Login here</u></a></p>
                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Business;
