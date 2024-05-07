import React, { useState } from 'react';
import axios from 'axios';

function ContactUs() {
  const [formData, setFormData] = useState({
    C_Name: '',
    C_Surname: '',
    C_Email: '',
    C_Subject: '',
    C_Message: ''
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
      await axios.post('https://localhost:7263/api/contact', formData);
      // Assuming you have a success message or redirection logic here
    } catch (error) {
      console.error('Submission failed:', error);
      // Handle error appropriately, e.g., display an error message to the user
    }
  };

  const validateForm = (data) => {
    let errors = {};

    if (!data.C_Name.trim()) {
      errors.C_Name = 'Name is required';
    }
    if (!data.C_Email.trim()) {
      errors.C_Email = 'Email is required';
    }
    // Add validation for other fields as needed

    return errors;
  };

  return (
    <main className="contactus_main">
      <div className="contactus_container">
        <h2>Contact Us</h2>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="C_Name">Name:</label>
            <input
              type="text"
              id="C_Name"
              className={`form-control ${errors.C_Name ? 'is-invalid' : ''}`}
              onChange={handleInputChange}
              required
            />
            {errors.C_Name && <div className="invalid-feedback">{errors.C_Name}</div>}
          </div>

          <div className="form-group">
            <label htmlFor="C_Surname">Surname:</label>
            <input
              type="text"
              id="C_Surname"
              className="form-control"
              onChange={handleInputChange}
            />
          </div>

          <div className="form-group">
            <label htmlFor="C_Email">Email:</label>
            <input
              type="email"
              id="C_Email"
              className={`form-control ${errors.C_Email ? 'is-invalid' : ''}`}
              onChange={handleInputChange}
              required
            />
            {errors.C_Email && <div className="invalid-feedback">{errors.C_Email}</div>}
          </div>

          <div className="form-group">
            <label htmlFor="C_Subject">Subject:</label>
            <input
              type="text"
              id="C_Subject"
              className="form-control"
              onChange={handleInputChange}
            />
          </div>

          <div className="form-group">
            <label htmlFor="C_Message">Message:</label>
            <textarea
              id="C_Message"
              className="form-control"
              rows="5"
              onChange={handleInputChange}
              required
            ></textarea>
          </div>

          <button type="submit" className="btn btn-primary">Send Message</button>
        </form>
      </div>
    </main>
  );
}

export default ContactUs;
