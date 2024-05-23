// CourseApplyForm.js
import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

const CourseApplyForm = () => {
    const [form, setForm] = useState({
        Attendant_Name: '',
        Attendant_Surname: '',
        Attendant_Email: '',
        Attendant_PhoneNo: '',
        Courses_ApplyingName: ''
    });

    const navigate = useNavigate();

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('https://localhost:7263/api/coursesapply', form);
            alert('Application submitted successfully');
            navigate('/career'); // Navigate back to Career component
        } catch (error) {
            console.error('Error submitting application:', error);
        }
    };

    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Apply for a Course</h1>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>First Name</label>
                    <input
                        type="text"
                        className="form-control"
                        name="Attendant_Name"
                        value={form.Attendant_Name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Surname</label>
                    <input
                        type="text"
                        className="form-control"
                        name="Attendant_Surname"
                        value={form.Attendant_Surname}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input
                        type="email"
                        className="form-control"
                        name="Attendant_Email"
                        value={form.Attendant_Email}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Phone Number</label>
                    <input
                        type="text"
                        className="form-control"
                        name="Attendant_PhoneNo"
                        value={form.Attendant_PhoneNo}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Course Name</label>
                    <input
                        type="text"
                        className="form-control"
                        name="Courses_ApplyingName"
                        value={form.Courses_ApplyingName}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Reserve a Spot</button>
            </form>
        </div>
    );
};

export default CourseApplyForm;
