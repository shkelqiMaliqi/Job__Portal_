import React from 'react';

const ContactUs = () => {
  return (
    <main className="contactus_main">
      <div className="contactus_container">
        <h2>Contact Us</h2>
        <form method="post" action="SendEmail">
          <div className="form-group">
            <label htmlFor="name">Name:</label>
            <input type="text" id="name" name="name" className="form-control" required />
          </div>

          <div className="form-group">
            <label htmlFor="surname">Surname:</label>
            <input type="text" id="surname" name="surname" className="form-control" required />
          </div>
          
          <div className="form-group">
            <label htmlFor="email">Email:</label>
            <input type="email" id="email" name="email" className="form-control" required />
          </div>

          <div className="form-group">
            <label htmlFor="subject">Subject:</label>
            <input type="text" id="subject" name="subject" className="form-control" />
          </div>
          
          <div className="form-group">
            <label htmlFor="message">Message:</label>
            <textarea id="message" name="message" className="form-control" rows="5" required></textarea>
          </div>
          
          <button type="submit" className="btn btn-primary">Send Message</button>
        </form>
      </div>
    </main>
  );
}

export default ContactUs;
