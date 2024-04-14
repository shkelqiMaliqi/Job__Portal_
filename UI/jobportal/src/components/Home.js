import React from 'react';


const Home = () => {
  return (
    <>
   
    <div className="dropdown">
        <select className="form-select" aria-label="Default select example">
          <option selected>Select Job Category</option>
          <option value="frontend-developer">Frontend Developer</option>
          <option value="back-developer">Back Developer</option>
          <option value="software-engineer">Software Engineer</option>
        </select>
      </div>
      
    <div className="job-listing-container">
      <h3 className="job-title">Frontend Developer</h3>
      <p className="job-details">Company: Tech Company Inc.</p>
      <p className="job-details">Location: New York</p>
      <p className="job-details">Date Posted: April 10, 2024</p>
      <p className="job-details">Number of Positions: 3</p>
    </div>
    
    <div className="job-listing-container">
      <h3 className="job-title">Back Developer</h3>
      <p className="job-details">Company: Tech Company Inc.</p>
      <p className="job-details">Location: New York</p>
      <p className="job-details">Date Posted: April 10, 2024</p>
      <p className="job-details">Number of Positions: 3</p>
    </div>

    <div className="job-listing-container">
      <h3 className="job-title">Software Engineer</h3>
      <p className="job-details">Company: Tech Company Inc.</p>
      <p className="job-details">Location: New York</p>
      <p className="job-details">Date Posted: April 10, 2024</p>
      <p className="job-details">Number of Positions: 3</p>
    </div>
</>
  );
}

export default Home;
