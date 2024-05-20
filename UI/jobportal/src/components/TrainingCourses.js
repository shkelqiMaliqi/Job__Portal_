import React, { useState } from 'react';
import axios from 'axios';

const TrainingCourse = () => {
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
            const response = await axios.post('https://localhost:7263/api/trainingcourses', course);
            alert(response.data);
        } catch (error) {
            console.error('Error creating training course:', error);
            alert('Error creating training course');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Title:</label>
                <input type="text" name="title" value={course.title} onChange={handleChange} required />
            </div>
            <div>
                <label>Description:</label>
                <input type="text" name="description" value={course.description} onChange={handleChange} required />
            </div>
            <div>
                <label>Start Date:</label>
                <input type="date" name="startDate" value={course.startDate} onChange={handleChange} required />
            </div>
            <div>
                <label>End Date:</label>
                <input type="date" name="endDate" value={course.endDate} onChange={handleChange} required />
            </div>
            <div>
                <label>Instructor:</label>
                <input type="text" name="instructor" value={course.instructor} onChange={handleChange} required />
            </div>
            <div>
                <label>Price:</label>
                <input type="number" name="price" value={course.price} onChange={handleChange} required />
            </div>
            <button type="submit">Add Training Course</button>
        </form>
    );
};

export default TrainingCourse;
