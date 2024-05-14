import React, { useState } from 'react';
import axios from 'axios';

function Register() {
  
  const [formData, setFormData] = useState({
    U_Name: '',
    U_Surname: '',
    U_Email: '',
    U_Username: '',
    U_Phone: '',
    U_Password: '',
    U_RepeatPassword: '',
    userRole: '' // Add user role field
  });

  const [errors, setErrors] = useState({});


  const handleInputChange = (e) => {
    setFormData({ ...formData, [e.target.id]: e.target.value });
  };

  
  const handleSubmit = async (e) => {
    e.preventDefault();


    const validationErrors = validateForm(formData);
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
  
      await axios.post('https://localhost:7263/api/users', formData);
     
      window.location.href = '/profile';
    } catch (error) {
      console.error('Registration failed:', error);
     
    }
  };


  const validateForm = (data) => {
    let errors = {};

    // Validation rules...

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
                  {/* Form fields... */}
                  
                  <div className="form-group mb-4">
                    <label className="d-block mb-2">User Type:</label>
                    <div className="btn-group" role="group">
                      <button 
                        type="button" 
                        className={`btn btn-lg ${formData.userRole === 'normal' ? 'btn-primary' : 'btn-outline-primary'}`}
                        onClick={() => setFormData({ ...formData, userRole: 'normal' })}
                      >
                        Normal User
                      </button>
                      <button 
                        type="button" 
                        className={`btn btn-lg ${formData.userRole === 'business' ? 'btn-primary' : 'btn-outline-primary'}`}
                        onClick={() => setFormData({ ...formData, userRole: 'business' })}
                      >
                        Business User
                      </button>
                    </div>
                  </div>

                  {/* Submit button */}
                  <div className="d-flex justify-content-center">
                    <button type="submit" className="register_btn btn-success btn-block btn-lg gradient-custom-4 text-body">Register</button>
                  </div>
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
