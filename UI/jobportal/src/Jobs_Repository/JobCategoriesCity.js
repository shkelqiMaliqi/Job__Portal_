import React, { useState, useEffect } from 'react';
import axios from 'axios';

const JobCategoriesCity = () => {
  const [jobCategories, setJobCategories] = useState([]);
  const [newCategoryName, setNewCategoryName] = useState('');

  useEffect(() => {
    fetchJobCategories();
  }, []);

  const fetchJobCategories = async () => {
    try {
      const response = await axios.get('https://localhost:7263/api/JobCategories_City');
      setJobCategories(response.data);
    } catch (error) {
      console.error('Error fetching job categories:', error);
    }
  };

  const addJobCategory = async () => {
    try {
      await axios.post('https://localhost:7263/api/JobCategories_City', {
        JobCategory_City_Name: newCategoryName
      });
      fetchJobCategories(); // Refresh the list after adding
      setNewCategoryName(''); // Clear input field
    } catch (error) {
      console.error('Error adding job category:', error);
    }
  };

  return (
    <div>
      <h2>Job Categories City</h2>
      <ul>
        {jobCategories.map((category) => (
          <li key={category.JobCategory_CityId}>{category.JobCategory_City_Name}</li>
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

export default JobCategoriesCity;
