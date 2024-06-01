import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';

const Publish = () => {
    const [job, setJob] = useState({
        JobTitle: '',
        NumberOfPositions: '',
        JobDescription: '',
        Qualification: '',
        Experience: '',
        Requirements: '',
        JobType: '',
        CompanyName: '',
        CompanyLogo: null, 
        Website: '',
        CompanyEmail: '',
        CompanyAddress: '',
        CompanyCountry: '',
        CompanyState: '',
        CompanyPhone: '',
        CreateDate_C: new Date(),
        JobCategoryId: '',
        JobCategories_ScheduleId: '',
        JobCategories_CityId: '',
        U_Id: ''
    });

    const [jobCategories, setJobCategories] = useState([]);
    const [jobCategoriesCity, setJobCategoriesCity] = useState([]);
    const [jobCategoriesSchedule, setJobCategoriesSchedule] = useState([]);

    useEffect(() => {
        fetchJobCategories();
        fetchJobCategoriesCity();
        fetchJobCategoriesSchedule();
    }, []);

    const fetchJobCategories = async () => {
        try {
            const response = await axios.get('https://localhost:7263/api/JobCategories');
            setJobCategories(response.data);
        } catch (error) {
            console.error('Error fetching job categories:', error);
        }
    };

    const fetchJobCategoriesCity = async () => {
        try {
            const response = await axios.get('https://localhost:7263/api/JobCategories_City');
            setJobCategoriesCity(response.data);
        } catch (error) {
            console.error('Error fetching job categories city:', error);
        }
    };

    const fetchJobCategoriesSchedule = async () => {
        try {
            const response = await axios.get('https://localhost:7263/api/JobCategories_Schedule');
            setJobCategoriesSchedule(response.data);
        } catch (error) {
            console.error('Error fetching job categories schedule:', error);
        }
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setJob({
            ...job,
            [name]: value
        });
    };

    const handleFileChange = (e) => {
        setJob({
            ...job,
            CompanyLogo: e.target.files[0]
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const formData = new FormData();
            for (const key in job) {
                if (key === 'CompanyLogo' && job[key]) {
                    formData.append(key, job[key], job[key].name);
                } else {
                    formData.append(key, job[key]);
                }
            }

            const imageResponse = await axios.post('https://localhost:7263/api/Jobs/SaveFile', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            const imageName = imageResponse.data;

            const jobData = { ...job, CompanyLogo: imageName };
            await axios.post('https://localhost:7263/api/Jobs', jobData);
            alert('Job posted successfully!');
        } catch (error) {
            console.error('There was an error posting the job!', error);
        }
    };

    return (
        <div className="container mt-5">
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Job Title</label>
                    <input type="text" className="form-control" name="JobTitle" value={job.JobTitle} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Number of Positions</label>
                    <input type="number" className="form-control" name="NumberOfPositions" value={job.NumberOfPositions} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Job Description</label>
                    <textarea className="form-control" name="JobDescription" value={job.JobDescription} onChange={handleChange}></textarea>
                </div>
                <div className="form-group">
                    <label>Qualification</label>
                    <textarea className="form-control" name="Qualification" value={job.Qualification} onChange={handleChange}></textarea>
                </div>
                <div className="form-group">
                    <label>Experience</label>
                    <textarea className="form-control" name="Experience" value={job.Experience} onChange={handleChange}></textarea>
                </div>
                <div className="form-group">
                    <label>Requirements</label>
                    <textarea className="form-control" name="Requirements" value={job.Requirements} onChange={handleChange}></textarea>
                </div>
                <div className="form-group">
                    <label>Job Type</label>
                    <select className="form-control" name="JobType" value={job.JobType} onChange={handleChange}>
                        <option value="">Select Job Type</option>
                        <option value="Full-Time">Full-Time</option>
                        <option value="Part-Time">Part-Time</option>
                        <option value="Internship">Internship</option>
                    </select>
                </div>
                <div className="form-group">
                    <label>Company Name</label>
                    <input type="text" className="form-control" name="CompanyName" value={job.CompanyName} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Company Logo</label>
                    <input type="file" className="form-control" name="CompanyLogo" onChange={handleFileChange} />
                </div>
                <div className="form-group">
                    <label>Website</label>
                    <input type="text" className="form-control" name="Website" value={job.Website} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Company Email</label>
                    <input type="email" className="form-control" name="CompanyEmail" value={job.CompanyEmail} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Company Address</label>
                    <textarea className="form-control" name="CompanyAddress" value={job.CompanyAddress} onChange={handleChange}></textarea>
                </div>
                <div className="form-group">
                    <label>Company Country</label>
                    <input type="text" className="form-control" name="CompanyCountry" value={job.CompanyCountry} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Company State</label>
                    <input type="text" className="form-control" name="CompanyState" value={job.CompanyState} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Company Phone</label>
                    <input type="text" className="form-control" name="CompanyPhone" value={job.CompanyPhone} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Job Category</label>
                    <select className="form-control" name="JobCategoryId" value={job.JobCategoryId} onChange={handleChange}>
                        <option value="">Select Job Category</option>
                        {jobCategories.map(category => (
                            <option key={category.JobCategoryID} value={category.JobCategoryID}>{category.JobCategoryName}</option>
                        ))}
                    </select>
                </div>
                <div className="form-group">
                    <label>Job City</label>
                    <select className="form-control" name="JobCategories_CityId" value={job.JobCategories_CityId} onChange={handleChange}>
                        <option value="">Select Job City</option>
                        {jobCategoriesCity.map(city => (
                            <option key={city.JobCategory_CityId} value={city.JobCategory_CityId}>{city.JobCategory_City_Name}</option>
                        ))}
                    </select>
                </div>
                <div className="form-group">
                    <label>Job Schedule</label>
                    <select className="form-control" name="JobCategories_ScheduleId" value={job.JobCategories_ScheduleId} onChange={handleChange}>
                        <option value="">Select Job Schedule</option>
                        {jobCategoriesSchedule.map(schedule => (
                            <option key={schedule.JobCategories_ScheduleId} value={schedule.JobCategories_ScheduleId}>{schedule.JobCategories_Schedule_Time}</option>
                        ))}
                    </select>
                </div>
                <div className="form-group">
                    <label>User ID</label>
                    <input type="text" className="form-control" name="U_Id" value={job.U_Id} onChange={handleChange} />
                </div>
                <button type="submit" className="btn btn-primary">Post Job</button>
            </form>
        </div>
    );
};

export default Publish;
