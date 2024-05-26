import React, { useEffect, useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';

const MainPage = () => {
    const [jobs, setJobs] = useState([]);
    const [categories, setCategories] = useState({
        JobCategories: [],
        JobCategories_City: [],
        JobCategories_Schedule_Time: []
    });
    const [expandedJobId, setExpandedJobId] = useState(null);

    const [selectedIndustry, setSelectedIndustry] = useState('');
    const [selectedCity, setSelectedCity] = useState('');
    const [selectedSchedule, setSelectedSchedule] = useState('');

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const response = await axios.get('https://localhost:7263/api/jobs');
                setJobs(response.data);
            } catch (error) {
                console.error('Error fetching jobs:', error);
            }
        };

        const fetchCategories = async () => {
            try {
                const [categoryNameResponse, categoryCityResponse, categoryScheduleResponse] = await Promise.all([
                    axios.get('https://localhost:7263/api/jobcategories'),
                    axios.get('https://localhost:7263/api/jobcategories_city'),
                    axios.get('https://localhost:7263/api/jobcategories_schedule')
                ]);

                setCategories({
                    JobCategories: categoryNameResponse.data,
                    JobCategories_City: categoryCityResponse.data,
                    JobCategories_Schedule_Time: categoryScheduleResponse.data
                });
            } catch (error) {
                console.error('Error fetching categories:', error);
            }
        };

        fetchJobs();
        fetchCategories();
    }, []);

    const toggleDetails = (jobId) => {
        setExpandedJobId(prevJobId => (prevJobId === jobId ? null : jobId));
    };

    const handleIndustryChange = (event) => {
        setSelectedIndustry(event.target.value);
    };

    const handleCityChange = (event) => {
        setSelectedCity(event.target.value);
    };

    const handleScheduleChange = (event) => {
        setSelectedSchedule(event.target.value);
    };

    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Job Listings</h1>
            
            <div className="mb-4">
                <h3>Categories</h3>
                <form>
                    <div className="row">
                        <div className="col-md-4">
                            <div className="form-group">
                                <label htmlFor="industrySelect">Industry</label>
                                <select className="form-control" id="industrySelect" value={selectedIndustry} onChange={handleIndustryChange}>
                                    <option value="" disabled>Select Industry</option>
                                    {categories.JobCategories.map((category, index) => (
                                        <option key={index} value={category.JobCategoryName}>{category.JobCategoryName}</option>
                                    ))}
                                </select>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group">
                                <label htmlFor="citySelect">City</label>
                                <select className="form-control" id="citySelect" value={selectedCity} onChange={handleCityChange}>
                                    <option value="" disabled>Select City</option>
                                    {categories.JobCategories_City.map((category, index) => (
                                        <option key={index} value={category.JobCategory_City_Name}>{category.JobCategory_City_Name}</option>
                                    ))}
                                </select>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group">
                                <label htmlFor="scheduleSelect">Schedule</label>
                                <select className="form-control" id="scheduleSelect" value={selectedSchedule} onChange={handleScheduleChange}>
                                    <option value="" disabled>Select Schedule</option>
                                    {categories.JobCategories_Schedule_Time.map((category, index) => (
                                        <option key={index} value={category.JobCategories_Schedule_Time}>{category.JobCategories_Schedule_Time}</option>
                                    ))}
                                </select>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            
            <div className="row">
                {jobs.map((job) => (
                    <div key={job.JobId} className="col-md-4 mb-4">
                        <div className="card">
                            <div className="card-body">
                                <h2 className="card-title">{job.JobTitle}</h2>
                                <div className="card-intro">
                                    <div className="col-md-12">
                                        <p>{job.CompanyName}</p>
                                        <p>{job.JobType}</p>
                                    </div>
                                </div>
                                <button className="btn btn-primary" onClick={() => toggleDetails(job.JobId)}>
                                    {expandedJobId === job.JobId ? 'Show Less' : 'See More'}
                                </button>
                                {expandedJobId === job.JobId && (
                                    <div className="mt-3">
                                        <p><strong>Description:</strong> {job.JobDescription}</p>
                                        <p><strong>Experience:</strong> {job.Experience}</p>
                                        <p><strong>Qualification:</strong> {job.Qualification}</p>
                                        <p><strong>Requirements:</strong> {job.Requirements}</p>
                                        <p><strong>Number of Positions:</strong> {job.NumberOfPositions}</p>
                                        <hr/>
                                        <p><i class="fa fa-link"></i> <a href={job.Website} target="_blank" rel="noopener noreferrer">{job.Website}</a></p>
                                        <p><i class="fa fa-envelope"></i> {job.CompanyEmail}</p>
                                        <p><i class="fa fa-map-marker"></i> {job.CompanyAddress}</p>
                                        <p><i class="fa fa-globe"></i> {job.CompanyCountry}</p>
                                        <p><i class="fa fa-map-signs"></i> {job.CompanyState}</p>
                                        <p><i class="fa fa-phone"></i> {job.CompanyPhone}</p>
                                        <p><i class="fa fa-calendar"></i> {new Date(job.CreateDate_C).toLocaleDateString()}</p>
                                        <div className="apply-button">Apply Now</div>
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

