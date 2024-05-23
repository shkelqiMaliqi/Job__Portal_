
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
            navigate('/career'); 
        } catch (error) {
            console.error('Error submitting application:', error);
        }
    };

    return (
        <div className="container_apply mt-5">
            <div className="form-container_apply p-4 shadow-sm rounded">
                <h1 className="text-center mb-4">Apply for a Course</h1>
                <form onSubmit={handleSubmit}>
                    <div className="form-group mb-3">
                        <label htmlFor="Attendant_Name">First Name</label>
                        <input
                            type="text"
                            className="form-contro_apply"
                            name="Attendant_Name"
                            value={form.Attendant_Name}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="form-group_apply mb-3">
                        <label htmlFor="Attendant_Surname">Surname</label>
                        <input
                            type="text"
                            className="form-control_apply"
                            name="Attendant_Surname"
                            value={form.Attendant_Surname}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="form-group_apply mb-3">
                        <label htmlFor="Attendant_Email">Email</label>
                        <input
                            type="email"
                            className="form-control_apply"
                            name="Attendant_Email"
                            value={form.Attendant_Email}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="form-group_apply mb-3">
                        <label htmlFor="Attendant_PhoneNo">Phone Number</label>
                        <input
                            type="text"
                            className="form-control_apply"
                            name="Attendant_PhoneNo"
                            value={form.Attendant_PhoneNo}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="form-group_apply mb-4">
                        <label htmlFor="Courses_ApplyingName">Course Name</label>
                        <input
                            type="text"
                            className="form-control_apply"
                            name="Courses_ApplyingName"
                            value={form.Courses_ApplyingName}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <button type="submit" className="btn_ btn-primary_apply btn-block">Reserve a Spot</button>
                </form>
            </div>
        </div>
    );
};

export default CourseApplyForm;
