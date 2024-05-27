import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Courses_List = () => {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [editCourseId, setEditCourseId] = useState(null);
  const [editedCourse, setEditedCourse] = useState({
    Title: '',
    Description: '',
    StartDate: '',
    EndDate: '',
    Instructor: '',
    Price: 0
  });

  useEffect(() => {
    fetchCourses();
  }, []);

  const fetchCourses = () => {
    axios.get('https://localhost:7263/api/TrainingCourses')
      .then(response => {
        setCourses(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching courses:', error);
        setLoading(false);
      });
  };

  const handleDeleteCourse = (id) => {
    if (window.confirm('Are you sure you want to delete this course?')) {
      axios.delete(`https://localhost:7263/api/TrainingCourses/${id}`)
        .then(response => {
          console.log(response.data);
          fetchCourses(); // Refresh the list after deletion
        })
        .catch(error => {
          console.error('Error deleting course:', error);
        });
    }
  };

  const handleEditCourse = (course) => {
    setEditCourseId(course.TrainingCourseId);
    setEditedCourse({
      Title: course.Title,
      Description: course.Description,
      StartDate: course.StartDate,
      EndDate: course.EndDate,
      Instructor: course.Instructor,
      Price: course.Price
    });
  };

  const handleCancelEdit = () => {
    setEditCourseId(null);
    setEditedCourse({
      Title: '',
      Description: '',
      StartDate: '',
      EndDate: '',
      Instructor: '',
      Price: 0
    });
  };

  const handleSaveEdit = () => {
    axios.put(`https://localhost:7263/api/TrainingCourses/${editCourseId}`, editedCourse)
      .then(response => {
        console.log(response.data);
        fetchCourses(); // Refresh the list after update
        setEditCourseId(null);
        setEditedCourse({
          Title: '',
          Description: '',
          StartDate: '',
          EndDate: '',
          Instructor: '',
          Price: 0
        });
      })
      .catch(error => {
        console.error('Error updating course:', error);
      });
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setEditedCourse(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container">
      <h2 className="mt-4 mb-4">Training Courses</h2>
      <table className="table table-bordered table-striped">
        <thead className="thead-dark">
          <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Description</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th>Instructor</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {courses.map(course => (
            <tr key={course.TrainingCourseId}>
              <td>{course.TrainingCourseId}</td>
              <td>{editCourseId === course.TrainingCourseId ? (
                <input
                  type="text"
                  className="form-control"
                  name="Title"
                  value={editedCourse.Title}
                  onChange={handleInputChange}
                />
              ) : (
                course.Title
              )}</td>
              <td>{editCourseId === course.TrainingCourseId ? (
                <input
                  type="text"
                  className="form-control"
                  name="Description"
                  value={editedCourse.Description}
                  onChange={handleInputChange}
                />
              ) : (
                course.Description
              )}</td>
              <td>{editCourseId === course.TrainingCourseId ? (
                <input
                  type="text"
                  className="form-control"
                  name="StartDate"
                  value={editedCourse.StartDate}
                  onChange={handleInputChange}
                />
              ) : (
                new Date(course.StartDate).toLocaleDateString('en-US')
              )}</td>
              <td>{editCourseId === course.TrainingCourseId ? (
                <input
                  type="text"
                  className="form-control"
                  name="EndDate"
                  value={editedCourse.EndDate}
                  onChange={handleInputChange}
                />
              ) : (
                new Date(course.EndDate).toLocaleDateString('en-US')
              )}</td>
              <td>{editCourseId === course.TrainingCourseId ? (
                <input
                  type="text"
                  className="form-control"
                  name="Instructor"
                  value={editedCourse.Instructor}
                  onChange={handleInputChange}
                />
              ) : (
                course.Instructor
              )}</td>
              <td>{editCourseId === course.TrainingCourseId ? (
                <input
                  type="text"
                  className="form-control"
                  name="Price"
                  value={editedCourse.Price}
                  onChange={handleInputChange}
                />
              ) : (
                `$${course.Price}`
              )}</td>
              <td>
                {editCourseId === course.TrainingCourseId ? (
                  <div>
                    <button
                      className="btn btn-sm btn-success mr-2"
                      onClick={handleSaveEdit}
                    >
                      Save
                    </button>
                    <button
                      className="btn btn-sm btn-secondary"
                      onClick={handleCancelEdit}
                    >
                      Cancel
                    </button>
                  </div>
                ) : (
                  <div>
                    <button
                      className="btn btn-sm btn-primary mr-2"
                      onClick={() => handleEditCourse(course)}
                    >
                      Edit
                    </button>
                    <button
                      className="btn btn-sm btn-danger"
                      onClick={() => handleDeleteCourse(course.TrainingCourseId)}
                    >
                      Delete
                    </button>
                  </div>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Courses_List;
