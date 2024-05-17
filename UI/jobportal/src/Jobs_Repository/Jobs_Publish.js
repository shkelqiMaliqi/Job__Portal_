import React, { useState } from 'react';
import axios from 'axios';

const Jobs_Publish = () => {
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
        CreateDate_C: new Date()
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
            await axios.post('/api/Jobs', job);
            
            console.log('Job created successfully!');
        } catch (error) {
            console.error('Error creating job:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Job Title:</label>
            <input type="text" name="Job_Input" value={job.JobTitle} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.NumberOfPositions} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.JobDescription} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.Qualification} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.Experience} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.Requirements} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.JobType} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyName} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyLogo} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.Website} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyEmail} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyAddress} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyCountry} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyState} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CompanyPhone} onChange={handleChange} />
            <input type="text" name="Job_Input" value={job.CreateDate_C} onChange={handleChange} />
           

            <button type="submit">Create Job</button>
        </form>
    );
};

export default Jobs_Publish;
