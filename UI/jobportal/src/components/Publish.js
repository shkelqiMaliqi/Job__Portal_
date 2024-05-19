import React, { useState } from 'react';
import axios from 'axios';

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
        CreateDate_C: new Date().toISOString().slice(0, 10) // To set the date in 'YYYY-MM-DD' format
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
        } catch (error) {
            console.error('Error creating job:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Job Title:</label>
            <input type="text" name="JobTitle" value={job.JobTitle} onChange={handleChange} />
            <label>Number of Positions:</label>
            <input type="number" name="NumberOfPositions" value={job.NumberOfPositions} onChange={handleChange} />
            <label>Job Description:</label>
            <input type="text" name="JobDescription" value={job.JobDescription} onChange={handleChange} />
            <label>Qualification:</label>
            <input type="text" name="Qualification" value={job.Qualification} onChange={handleChange} />
            <label>Experience:</label>
            <input type="text" name="Experience" value={job.Experience} onChange={handleChange} />
            <label>Requirements:</label>
            <input type="text" name="Requirements" value={job.Requirements} onChange={handleChange} />
            <label>Job Type:</label>
            <input type="text" name="JobType" value={job.JobType} onChange={handleChange} />
            <label>Company Name:</label>
            <input type="text" name="CompanyName" value={job.CompanyName} onChange={handleChange} />
            <label>Company Logo:</label>
            <input type="text" name="CompanyLogo" value={job.CompanyLogo} onChange={handleChange} />
            <label>Website:</label>
            <input type="text" name="Website" value={job.Website} onChange={handleChange} />
            <label>Company Email:</label>
            <input type="email" name="CompanyEmail" value={job.CompanyEmail} onChange={handleChange} />
            <label>Company Address:</label>
            <input type="text" name="CompanyAddress" value={job.CompanyAddress} onChange={handleChange} />
            <label>Company Country:</label>
            <input type="text" name="CompanyCountry" value={job.CompanyCountry} onChange={handleChange} />
            <label>Company State:</label>
            <input type="text" name="CompanyState" value={job.CompanyState} onChange={handleChange} />
            <label>Company Phone:</label>
            <input type="text" name="CompanyPhone" value={job.CompanyPhone} onChange={handleChange} />
            <label>Create Date:</label>
            <input type="date" name="CreateDate_C" value={job.CreateDate_C} onChange={handleChange} />

            <button type="submit">Create Job</button>
        </form>
    );
};

export default Publish;
