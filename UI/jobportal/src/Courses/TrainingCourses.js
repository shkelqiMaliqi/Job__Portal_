import React, { useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';

const TrainingCourses = () => {
    const [course, setCourse] = useState({
        title: '',
        description: '',
        startDate: '',
        endDate: '',
        instructor: '',
        price: ''
    });



    const handleChange = (e) => {
        const { name, value } = e.target;
        setCourse({ ...course, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
           await axios.post('https://localhost:7263/api/trainingcourses', course);
            alert('Training course created successfully!');
         
        } catch (error) {
            console.error('Error creating training course:', error);
            alert('Error creating training course');
        }
    };

    return (
        <div className="form-container">
            <h2>Add New Training Course</h2>
            <form className="training-course-form" onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="title">Course Title:</label>
                    <input type="text" id="title" name="title" value={course.title} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="description">Course Description:</label>
                    <input type="text" id="description" name="description" value={course.description} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="startDate">Start Date:</label>
                    <input type="date" id="startDate" name="startDate" value={course.startDate} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="endDate">End Date:</label>
                    <input type="date" id="endDate" name="endDate" value={course.endDate} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="instructor">Instructor Name:</label>
                    <input type="text" id="instructor" name="instructor" value={course.instructor} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="price">Course Price:</label>
                    <input type="number" id="price" name="price" value={course.price} onChange={handleChange} required />
                </div>
                <button type="submit">Add Training Course</button>
            </form>
        </div>
    );
};

export default TrainingCourses;
