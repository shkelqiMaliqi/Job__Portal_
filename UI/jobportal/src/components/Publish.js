import React, { useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';


const Publish = () => {
    const [job, setJob] = useState({
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
        CompanyPhone: 0,
        CreateDate_C: new Date().toISOString().slice(0, 10) 
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setJob(prevJob => ({
            ...prevJob,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('https://localhost:7263/api/jobs', job);
            
            console.log('Job created successfully!');
            alert('Job added successfully!');
        } catch (error) {
            console.error('Error creating job:', error);
        }
    };

    return (
        <div className="publish-container">
            <div className="container">
                <h2 className="text-center my-4">Publish a Job</h2>
                <form onSubmit={handleSubmit} className="row g-3">
                    <div className="col-md-6">
                        <label htmlFor="JobTitle" className="form-label_publish">Job Title:</label>
                        <input type="text" id="JobTitle" name="JobTitle" value={job.JobTitle} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="NumberOfPositions" className="form-label_publis">Number of Positions:</label>
                        <input type="number" id="NumberOfPositions" name="NumberOfPositions" value={job.NumberOfPositions} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-12">
                        <label htmlFor="JobDescription" className="form-label_publis">Job Description:</label>
                        <input type="text" id="JobDescription" name="JobDescription" value={job.JobDescription} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="Qualification" className="form-label_publis">Qualification:</label>
                        <input type="text" id="Qualification" name="Qualification" value={job.Qualification} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="Experience" className="form-label_publis">Experience:</label>
                        <input type="text" id="Experience" name="Experience" value={job.Experience} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-12">
                        <label htmlFor="Requirements" className="form-label_publis">Requirements:</label>
                        <input type="text" id="Requirements" name="Requirements" value={job.Requirements} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="JobType" className="form-label_publis">Job Type:</label>
                        <input type="text" id="JobType" name="JobType" value={job.JobType} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyName" className="form-label_publis">Company Name:</label>
                        <input type="text" id="CompanyName" name="CompanyName" value={job.CompanyName} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyLogo" className="form-label_publis">Company Logo:</label>
                        <input type="text" id="CompanyLogo" name="CompanyLogo" value={job.CompanyLogo} onChange={handleChange} className="form-control" />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="Website" className="form-label_publish">Website:</label>
                        <input type="text" id="Website" name="Website" value={job.Website} onChange={handleChange} className="form-control" />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyEmail" className="form-label_publish">Company Email:</label>
                        <input type="email" id="CompanyEmail" name="CompanyEmail" value={job.CompanyEmail} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyAddress" className="form-label_publish">Company Address:</label>
                        <input type="text" id="CompanyAddress" name="CompanyAddress" value={job.CompanyAddress} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyCountry" className="form-label_publish">Company Country:</label>
                        <input type="text" id="CompanyCountry" name="CompanyCountry" value={job.CompanyCountry} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyState" className="form-label_publish">Company State:</label>
                        <input type="text" id="CompanyState" name="CompanyState" value={job.CompanyState} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CompanyPhone" className="form-label_publish">Company Phone:</label>
                        <input type="text" id="CompanyPhone" name="CompanyPhone" value={job.CompanyPhone} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CreateDate_C" className="form-label_publish">Create Date:</label>
                        <input type="date" id="CreateDate_C" name="CreateDate_C" value={job.CreateDate_C} onChange={handleChange} className="form-control" required />
                    </div>
                    <div className="col-12 text-center mt-4">
                        <button type="submit" className="btn btn_publish">Create Job</button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Publish;
