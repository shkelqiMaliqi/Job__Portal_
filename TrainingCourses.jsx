import React, { useState } from 'react';
import axios from 'axios';

function TrainingCoursesForm() {
    const [formState, setFormState] = useState({
        fullName: '',
        email: '',
        department: '',
        courseName: '',
        completionDate: '',
        grade: '',
        declaration: ''
    });

    const handleChange = (event) => {
        setFormState({
            ...formState,
            [event.target.name]: event.target.value
        });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        
        axios.post('https://localhost:7263/api/TrainingCourses', formState)
            .then(response => {
                console.log(response);
            })
            .catch(error => {
                console.error('There was an error!', error);
            });
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Full Name:
                <input type="text" name="fullName" onChange={handleChange} />
            </label>
            <label>
                Email:
                <input type="email" name="email" onChange={handleChange} />
            </label>
            <label>
                Department:
                <input type="text" name="department" onChange={handleChange} />
            </label>
            <label>
                Course Name:
                <input type="text" name="courseName" onChange={handleChange} />
            </label>
            <label>
                Completion Date:
                <input type="date" name="completionDate" onChange={handleChange} />
            </label>
            <label>
                Grade:
                <select name="grade" onChange={handleChange}>
                    <option value="">Select a grade</option>
                    <option value="A">A</option>
                    <option value="B">B</option>
                    <option value="C">C</option>
                    <option value="D">D</option>
                    <option value="F">F</option>
                </select>
            </label>
            <label>
                Declaration of Completion:
                <textarea name="declaration" onChange={handleChange} />
            </label>
            <input type="submit" value="Submit" />
        </form>
    );
}

export default TrainingCoursesForm;
