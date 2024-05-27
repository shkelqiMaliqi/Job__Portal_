import React, { useState, useEffect } from 'react';
import axios from 'axios';

const JobCategories = () => {
  const [jobCategories, setJobCategories] = useState([]);
  const [newCategoryName, setNewCategoryName] = useState('');

  useEffect(() => {
    fetchJobCategories();
  }, []);

  const fetchJobCategories = async () => {
    try {
      const response = await axios.get('https://localhost:7263/api/JobCategories');
      setJobCategories(response.data);
    } catch (error) {
      console.error('Error fetching job categories:', error);
    }
  };

  const addJobCategory = async () => {
    try {
      await axios.post('https://localhost:7263/api/JobCategories', {
        JobCategoryName: newCategoryName
      });
      fetchJobCategories(); 
      setNewCategoryName(''); 
    } catch (error) {
      console.error('Error adding job category:', error);
    }
  };

  return (
    <div>
      <h2>Job Categories</h2>
      <ul>
        {jobCategories.map((category) => (
          <li key={category.JobCategoryID}>{category.JobCategoryName}</li>
        ))}
      </ul>
      <div>
        <input
          type="text"
          value={newCategoryName}
          onChange={(e) => setNewCategoryName(e.target.value)}
        />
        <button onClick={addJobCategory}>Add Category</button>
      </div>
    </div>
  );
};

export default JobCategories;
