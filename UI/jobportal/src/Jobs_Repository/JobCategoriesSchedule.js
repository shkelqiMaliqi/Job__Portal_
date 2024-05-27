import React, { useState, useEffect } from 'react';
import axios from 'axios';

const JobCategoriesSchedule = () => {
  const [jobCategories, setJobCategories] = useState([]);
  const [newScheduleTime, setNewScheduleTime] = useState('');

  useEffect(() => {
    fetchJobCategories();
  }, []);

  const fetchJobCategories = async () => {
    try {
      const response = await axios.get('https://localhost:7263/api/JobCategories_Schedule');
      setJobCategories(response.data);
    } catch (error) {
      console.error('Error fetching job categories:', error);
    }
  };

  const addJobCategory = async () => {
    try {
      await axios.post('https://localhost:7263/api/JobCategories_Schedule', {
        JobCategories_Schedule_Time: newScheduleTime
      });
      fetchJobCategories(); // Refresh the list after adding
      setNewScheduleTime(''); // Clear input field
    } catch (error) {
      console.error('Error adding job category:', error);
    }
  };

  return (
    <div>
      <h2>Job Categories Schedule</h2>
      <ul>
        {jobCategories.map((category) => (
          <li key={category.JobCategories_ScheduleId}>{category.JobCategories_Schedule_Time}</li>
        ))}
      </ul>
      <div>
        <input
          type="text"
          value={newScheduleTime}
          onChange={(e) => setNewScheduleTime(e.target.value)}
        />
        <button onClick={addJobCategory}>Add Schedule</button>
      </div>
    </div>
  );
};

export default JobCategoriesSchedule;
