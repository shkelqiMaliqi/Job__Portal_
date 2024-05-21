import React, { useEffect, useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';

const Career = () => {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        const fetchCourses = async () => {
            try {
                const response = await axios.get('https://localhost:7263/api/trainingcourses');
                setCourses(response.data);
            } catch (error) {
                console.error('Error fetching courses:', error);
            }
        };

        fetchCourses();
    }, []);

    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Training Courses</h1>
            <div className="row">
                    {courses.map((course) => (
                       // <div key={course.TrainingCourseId} className="col-md-4 mb-4">
                            <div className="card h-100">
                                <div className="card-body">
                                <p className="card-text">
                                        <strong>Title:</strong> {course.Title}
                                    </p>
                                    <p className="card-text">
                                        <strong>Description:</strong> {course.Description}
                                    </p>
                                    <p className="card-text">
                                        <strong>Start Date:</strong> {course.EtartDate}
                                    </p>
                                    <p className="card-text">
                                        <strong>End Date:</strong> {course.EndDate}
                                    </p>
                                    <p className="card-text">
                                        <strong>Instructor:</strong> {course.Instructor}
                                    </p>
                                    <p className="card-text">
                                        <strong>Price:</strong> ${course.Price}
                                    </p>
                                </div>
                            </div>
                       // </div>
                  
                ))}
                    <p className="text-center">No courses available</p>
                
            </div>
        </div>
        
    );
};

export default Career;
