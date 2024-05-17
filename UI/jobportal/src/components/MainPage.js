import React, { useEffect, useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';


const MainPage = () => {
    const [jobs, setJobs] = useState([]);
    const [expandedJobId, setExpandedJobId] = useState(null);

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const response = await axios.get('https://localhost:7263/api/jobs');
                setJobs(response.data);
            } catch (error) {
                console.error('Error fetching jobs:', error);
            }
        };

        fetchJobs();
    }, []);

    const toggleDetails = (jobId) => {
        setExpandedJobId(prevJobId => (prevJobId === jobId ? null : jobId));
    };

    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Job Listings</h1>
            <div className="row">
                {jobs.map((job) => (
                    <div key={job.JobId} className="col-md-4 mb-4">
                        <div className="card h-100">
                            <div className="card-body">
                                <h2 className="card-title">{job.JobTitle}</h2>
                                <p className="card-text"><strong>Company:</strong> {job.CompanyName}</p>
                                <p className="card-text"><strong>Description:</strong> {job.JobDescription.substring(0, 100)}...</p>
                                <button className="btn btn-primary" onClick={() => toggleDetails(job.JobId)}>
                                    {expandedJobId === job.JobId ? 'Show Less' : 'See More'}
                                </button>
                                {expandedJobId === job.JobId && (
                                    <div className="mt-3">
                                        <p><strong>Qualification:</strong> {job.Qualification}</p>
                                        <p><strong>Experience:</strong> {job.Experience}</p>
                                        <p><strong>Requirements:</strong> {job.Requirements}</p>
                                        <p><strong>Job Type:</strong> {job.JobType}</p>
                                        <p><strong>Number of Positions:</strong> {job.NumberOfPositions}</p>
                                        <p><strong>Website:</strong> <a href={job.Website} target="_blank" rel="noopener noreferrer">{job.Website}</a></p>
                                        <p><strong>Email:</strong> {job.CompanyEmail}</p>
                                        <p><strong>Address:</strong> {job.CompanyAddress}</p>
                                        <p><strong>Country:</strong> {job.CompanyCountry}</p>
                                        <p><strong>State:</strong> {job.CompanyState}</p>
                                        <p><strong>Phone:</strong> {job.CompanyPhone}</p>
                                        <p><strong>Date Created:</strong> {new Date(job.CreateDate_C).toLocaleDateString()}</p>
                                    </div>
                                )}
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default MainPage;
