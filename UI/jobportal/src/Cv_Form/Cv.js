import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Cv = () => {
    const [cvData, setCvData] = useState({
        Cv_Name: '',
        Cv_Surname: '',
        Cv_DateOfBirth: '',
        Cv_PhoneNumber: '',
        Cv_Email: '',
        CvExp_Experiences: '', 
        CvEdu_Education: '',
        CvIndustry_IndustryType:'',
        CvTs_TSkills:'',
        CvCertifications_Certifications:'',
        CvAs_ASkills:'',
        CvCourses_C:'',
        CvLang_Lang:'',
        CvAddMore_Add:'',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCvData({ ...cvData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
    
        try {
            await axios.post('https://localhost:7263/api/experiences', { CvExp_Experiences: cvData.CvExp_Experiences });
            await axios.post('https://localhost:7263/api/education', { CvEdu_Education: cvData.CvEdu_Education });
            await axios.post('https://localhost:7263/api/industry', { CvIndustry_IndustryType: cvData.CvIndustry_IndustryType });
            await axios.post('https://localhost:7263/api/technicalSkills', { CvTs_TSkills: cvData.CvTs_TSkills });
            await axios.post('https://localhost:7263/api/additionalSkills', { CvAs_ASkills: cvData.CvAs_ASkills });
            await axios.post('https://localhost:7263/api/courses', { CvCourses_C: cvData.CvCourses_C });
            await axios.post('https://localhost:7263/api/languages', { CvLang_Lang: cvData.CvLang_Lang });
            await axios.post('https://localhost:7263/api/addmore', { CvAddMore_Add: cvData.CvAddMore_Add });

            const cvFormData = {
                Cv_Name: cvData.Cv_Name,
                Cv_Surname: cvData.Cv_Surname,
                Cv_DateOfBirth: cvData.Cv_DateOfBirth,
                Cv_PhoneNumber: cvData.Cv_PhoneNumber,
                Cv_Email: cvData.Cv_Email,
            };
    
            await axios.post('https://localhost:7263/api/cv', cvFormData);
    
            setCvData({
                Cv_Name: '',
                Cv_Surname: '',
                Cv_DateOfBirth: '',
                Cv_PhoneNumber: '',
                Cv_Email: '',
                CvExp_Experiences: '',
                CvEdu_Education: '',
                CvIndustry_IndustryType:'',
                CvTs_TSkills:'',
                CvCertifications_Certifications:'',
                CvAs_ASkills:'',
                CvCourses_C:'',
                CvLang_Lang:'',
                CvAddMore_Add:'',
            });
    
            console.log('CV and experience added successfully');
        } catch (error) {
            console.error('Error adding CV and experience:', error);
        }
    };
    

    return (
        <div className='cv_form'>
            <h2>Create CV</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="Cv_Name" placeholder="First Name" value={cvData.Cv_Name} onChange={handleChange} />
                <input type="text" name="Cv_Surname" placeholder="Last Name" value={cvData.Cv_Surname} onChange={handleChange} />
                <input type="date" name="Cv_DateOfBirth" value={cvData.Cv_DateOfBirth} onChange={handleChange} />
                <input type="tel" name="Cv_PhoneNumber" placeholder="Phone Number" value={cvData.Cv_PhoneNumber} onChange={handleChange} />
                <input type="email" name="Cv_Email" placeholder="Email" value={cvData.Cv_Email} onChange={handleChange} />
                <input type="text" name="CvExp_Experiences" placeholder="Experiences" value={cvData.CvExp_Experiences} onChange={handleChange} />
                <input type="text" name="CvEdu_Education" placeholder="Education" value={cvData.CvEdu_Education} onChange={handleChange} />
                <input type="text" name="CvIndustry_IndustryType" placeholder="Industry" value={cvData.CvIndustry_IndustryType} onChange={handleChange} />
                <input type="text" name="CvTs_TSkills" placeholder="Technical Skills" value={cvData.CvTs_TSkills} onChange={handleChange} />
                <input type="text" name="CvCertifications_Certifications" placeholder="Certifications" value={cvData.CvCertifications_Certifications} onChange={handleChange} />
                <input type="text" name="CvAs_ASkills" placeholder="Additional Skills" value={cvData.CvAs_ASkills} onChange={handleChange} />
                <input type="text" name="CvCourses_C" placeholder="Courses" value={cvData.CvCourses_C} onChange={handleChange} />
                <input type="text" name="CvLang_Lang" placeholder="Languages" value={cvData.CvLang_Lang} onChange={handleChange} />
                <input type="text" name="CvAddMore_Add" placeholder="Add More" value={cvData.CvAddMore_Add} onChange={handleChange} />
                <button type="submit" className="cv-button">Create</button>
            </form>
        </div>
    );
};

export default Cv;