import React, { useState } from 'react';
import {variables} from '../Varibales'
import axios from 'axios'; 

function Register() {
  
  const [formData, setFormData] = useState({
    U_Name: '',
    U_Surname: '',
    U_Email: '',
    U_Username: '',
    U_Phone: '',
    U_Password: '',
    U_RepeatPassword: ''
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

    if (!data.U_Name.trim()) {
      errors.U_Name = 'Name is required';
    
    }
    /*
    else if (!data.U_Surname.trim()) {
      errors.U_Surname = 'Surname is required';
    }
    else if (!data.U_Email.trim()) {
      errors.U_Email = 'Email is required';
    }
    else if (!data.U_Username.trim()) {
      errors.U_Usernme = 'Username is required';
    }
    else if (!data.U_Phone.trim()) {
      errors.U_Phone = 'Phone Number is required';
    }
    else if (!data.U_Password.trim()) {
      errors.U_Password = 'Password is required';
    }
    else if (!data.U_RepeatPassword.trim()) {
      errors.U_RepeatPassword = 'Repeat password is required';
    }
    */

  
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
                      <input type="text" id="U_Name" className={`form-control form-control-lg ${errors.U_Name ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_Name">Your Name</label>
                      {errors.U_Name && <div className="invalid-feedback">{errors.U_Name}</div>}
                    </div>
                    {/* Repeat this structure for other form fields */}
                    <div className="form-outline mb-4">
                      <input type="text" id="U_Surname" className={`form-control form-control-lg ${errors.U_Surname ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_Surname">Your Surname</label>
                      {errors.U_Surame && <div className="invalid-feedback">{errors.U_Surname}</div>}
                    </div>

                    <div className="form-outline mb-4">
                      <input type="email" id="U_Email" className={`form-control form-control-lg ${errors.U_Email ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_Email">Your Email</label>
                      {errors.U_Email && <div className="invalid-feedback">{errors.U_Email}</div>}
                    </div>

                    <div className="form-outline mb-4">
                      <input type="text" id="U_Username" className={`form-control form-control-lg ${errors.U_Username ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_Username">Your Username</label>
                      {errors.U_Userame && <div className="invalid-feedback">{errors.U_Username}</div>}
                    </div>

                    <div className="form-outline mb-4">
                      <input type="text" id="U_Phone" className={`form-control form-control-lg ${errors.U_Phone ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_Phone">Your Phone no</label>
                      {errors.U_Phone && <div className="invalid-feedback">{errors.U_Phone}</div>}
                    </div>

                    <div className="form-outline mb-4">
                      <input type="password" id="U_Password" className={`form-control form-control-lg ${errors.U_Password ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_Password">Your Password</label>
                      {errors.U_Password && <div className="invalid-feedback">{errors.U_Password}</div>}
                    </div>

                    <div className="form-outline mb-4">
                      <input type="password" id="U_RepeatPassword" className={`form-control form-control-lg ${errors.U_RepeatPassword ? 'is-invalid' : ''}`} onChange={handleInputChange} />
                      <label className="form-label" htmlFor="U_RepeatPassword">Repeat Password</label>
                      {errors.U_RepeatPassword && <div className="invalid-feedback">{errors.U_RepeatPassword}</div>}
                    </div>


                    <div className="d-flex justify-content-center">
                      <button type="submit" className="register_btn btn-success btn-block btn-lg gradient-custom-4 text-body">Register</button>
                    </div>

                    <p className="text-center text-muted mt-5 mb-0">Have already an account? <a href="./profile" className="fw-bold text-body"><u>Login here</u></a></p>

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
