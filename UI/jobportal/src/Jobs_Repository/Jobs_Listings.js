import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Jobs_Listings = () => {
  const [jobs, setJobs] = useState([]);
  const [editedJob, setEditedJob] = useState({
    JobId: '',
    JobTitle: '',
    NumberOfPositions: 0,
    JobDescription: '',
    Qualification: '',
    Experience: '',
    Requirements: '',
    JobType: '',
    CompanyName: '',
    CompanyLogo: '',
    Website: '',
    CompanyEmail: '',
    CompanyAddress: '',
    CompanyCountry: '',
    CompanyState: '',
    CompanyPhone: '',
    CreateDate_C: ''
  });

  useEffect(() => {
    fetchJobs();
  }, []);

  const fetchJobs = () => {
    axios.get('https://localhost:7263/api/jobs')
      .then(response => {
        setJobs(response.data);
      })
      .catch(error => {
        console.error('Error fetching jobs:', error);
      });
  };

  const handleEdit = (job) => {
    setEditedJob(job);
  };

  const handleUpdate = () => {
    axios.put(`https://localhost:7263/api/jobs`, editedJob)
      .then(response => {
        console.log(response.data);
        fetchJobs(); // Refresh jobs list after update
        setEditedJob({  // Reset editedJob state after successful update
          JobId: '',
          JobTitle: '',
          NumberOfPositions: 0,
          JobDescription: '',
          Qualification: '',
          Experience: '',
          Requirements: '',
          JobType: '',
          CompanyName: '',
          CompanyLogo: '',
          Website: '',
          CompanyEmail: '',
          CompanyAddress: '',
          CompanyCountry: '',
          CompanyState: '',
          CompanyPhone: '',
          CreateDate_C: ''
        });
      })
      .catch(error => {
        console.error('Error updating job: ', error);
      });
  };

  const handleDelete = (id) => {
    axios.delete(`https://localhost:7263/api/jobs/${id}`)
      .then(response => {
        console.log(response.data);
        fetchJobs(); // Refresh jobs list after deletion
      })
      .catch(error => {
        console.error('Error deleting job: ', error);
      });
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedJob({
      ...editedJob,
      [name]: value
    });
  };

  return (
    <div>
      <h2>All Jobs</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Job ID</th>
            <th>Job Title</th>
            <th>Number of Positions</th>
            <th>Job Description</th>
            <th>Qualification</th>
            <th>Experience</th>
            <th>Requirements</th>
            <th>Job Type</th>
            <th>Company Name</th>
            <th>Company Logo</th>
            <th>Website</th>
            <th>Company Email</th>
            <th>Company Address</th>
            <th>Company Country</th>
            <th>Company State</th>
            <th>Company Phone</th>
            <th>Create Date</th>
            <th>Actions</th>
            {/* Add more table headers as needed */}
          </tr>
        </thead>
        <tbody>
          {jobs.map(job => (
            <tr key={job.JobId}>
              <td>{job.JobId}</td>
              <td>{job.JobTitle}</td>
              <td>{job.NumberOfPositions}</td>
              <td>{job.JobDescription}</td>
              <td>{job.Qualification}</td>
              <td>{job.Experience}</td>
              <td>{job.Requirements}</td>
              <td>{job.JobType}</td>
              <td>{job.CompanyName}</td>
              <td>{job.CompanyLogo}</td>
              <td>{job.Website}</td>
              <td>{job.CompanyEmail}</td>
              <td>{job.CompanyAddress}</td>
              <td>{job.CompanyCountry}</td>
              <td>{job.CompanyState}</td>
              <td>{job.CompanyPhone}</td>
              <td>{job.CreateDate_C}</td>
              <td>
                <button className="btn btn-primary mr-2" onClick={() => handleEdit(job)}>Edit</button>
                <button className="btn btn-danger" onClick={() => handleDelete(job.JobId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Example form for editing job details */}
      {editedJob.JobId &&
        <div className="mt-3">
          <h3>Edit Job</h3>
          <form onSubmit={(e) => { e.preventDefault(); handleUpdate(); }}>
            <div className="form-group">
              <label>Job Title</label>
              <input type="text" className="form-control" name="JobTitle" value={editedJob.JobTitle} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Number of Positions</label>
              <input type="number" className="form-control" name="NumberOfPositions" value={editedJob.NumberOfPositions} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Job Description</label>
              <textarea className="form-control" name="JobDescription" value={editedJob.JobDescription} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Qualification</label>
              <input type="text" className="form-control" name="Qualification" value={editedJob.Qualification} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Experience</label>
              <input type="text" className="form-control" name="Experience" value={editedJob.Experience} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Requirements</label>
              <input type="text" className="form-control" name="Requirements" value={editedJob.Requirements} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Job Type</label>
              <input type="text" className="form-control" name="JobType" value={editedJob.JobType} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company Name</label>
              <input type="text" className="form-control" name="CompanyName" value={editedJob.CompanyName} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company Logo</label>
              <input type="text" className="form-control" name="CompanyLogo" value={editedJob.CompanyLogo} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Website</label>
              <input type="text" className="form-control" name="Website" value={editedJob.Website} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company Email</label>
              <input type="email" className="form-control" name="CompanyEmail" value={editedJob.CompanyEmail} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company Address</label>
              <input type="text" className="form-control" name="CompanyAddress" value={editedJob.CompanyAddress} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company Country</label>
              <input type="text" className="form-control" name="CompanyCountry" value={editedJob.CompanyCountry} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company State</label>
              <input type="text" className="form-control" name="CompanyState" value={editedJob.CompanyState} onChange={handleChange} />
            </div>
            <div className="form-group">
              <label>Company Phone</label>
              <input type="text" className="form-control" name="CompanyPhone" value={editedJob.CompanyPhone} onChange={handleChange} />
            </div>
            <button type="submit" className="btn btn-success">Update</button>
          </form>
        </div>
      }
    </div>
  );
};

export default Jobs_Listings;
