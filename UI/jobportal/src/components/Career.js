import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';


const Career = () => {
    const [courses, setCourses] = useState([]);
    const navigate = useNavigate();

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

    const formatDate = (isoDate) => {
        const options = { day: 'numeric', month: 'numeric', year: 'numeric' };
        return new Date(isoDate).toLocaleDateString('en-GB', options); 
    };

    return (
        <div className="container mt-10">
            <h1 className="text-center mb-4 display-5">Training Courses</h1>
            <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
                {courses.length > 0 ? (
                    courses.map((course) => (
                        <div key={course.TrainingCourseId} className="col">
                            <div className="course gradient-background_career h-100 shadow w-auto px-4 py-3">
                                <div className="courses-body">
                                    <h5 className="course-title mb-4 text-center">{course.Title}</h5>
                                    <p className="course-text mb-4">{course.Description}</p>
                                    <p className="course-text mb-3"><strong>Start Date:</strong> {formatDate(course.StartDate)}</p>
                                    <p className="course-text mb-3"><strong>End Date:</strong> {formatDate(course.EndDate)}</p>
                                    <p className="course-text mb-3"><strong>Instructor:</strong> {course.Instructor}</p>
                                    <p className="course-text mb-3"><strong>Price:</strong> {course.Price} $</p>
                                    <div className="text-center mt-3"> 
                                        <button
                                            className="btn_career btn-primary w-auto px-5 py-2.5" 
                                            onClick={() => navigate('/CourseApply_Form')}
                                            style={{ 
                                            backgroundColor: 'lightgreen', 
                                            border: 'none', 
                                            color: 'white', 
                                            borderRadius: '8px', 
                                            transition: '0.6s' }}
                                        >
                                            Reserve a Spot
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))
                ) : (
                    <p className="text-center w-100 text-xl font-medium text-muted">No courses available</p>
                )}
            </div>
        </div>
    );
};

export default Career;
