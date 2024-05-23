import React, { useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';

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
    } catch (error) {
      console.error('Submission failed:', error);
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
    if (!data.C_Surname.trim()) {
      errors.C_Surname = 'Name is required';
    }
    if (!data.C_Message.trim()) {
      errors.C_Message = 'Email is required';
    }


    return errors;
  };

  return (
    <main className='contactus_intro'>
      <div className="container">
        <div className="row">
          <div className="col-md-4">
            <h2 className='contact_h2'>Contact Us</h2>
            <p className='contactus_text'>
              We would love to hear from you! If you have any questions, feedback, or inquiries, please feel free to reach out to us. 
              You can use the form on the right to send us a message directly. We strive to respond to all messages within 24 hours.
            </p>
          </div>
          <div className="col-md-8">
            <div className="contactus_main">
              <div className="contactus_container">
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

                  <button type="submit" className="btn_contactUs btn-primary">Send Message</button>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
  );
}

export default ContactUs;
