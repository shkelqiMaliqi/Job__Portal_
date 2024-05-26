import React, { useState } from 'react';
import axios from 'axios';
import jsPDF from 'jspdf';
import 'bootstrap/dist/css/bootstrap.min.css';

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

    const saveAsPdf = () => {
        const doc = new jsPDF();
        doc.text('CV Data', 10, 10);
        Object.keys(cvData).forEach((key, index) => {
            doc.text(`${key}: ${cvData[key]}`, 10, 20 + index * 10);
        });
        doc.save('cv.pdf');
    };

    return (
        <div className='container mt-5'>
            <div className='cv_form p-5' style={{ background: 'linear-gradient(to right, #ff7e5f, #feb47b)' }}>
                <h2>Create CV</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="Cv_Name" placeholder="First Name" value={cvData.Cv_Name} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="Cv_Surname" placeholder="Last Name" value={cvData.Cv_Surname} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="date" className="form-control" name="Cv_DateOfBirth" value={cvData.Cv_DateOfBirth} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="tel" className="form-control" name="Cv_PhoneNumber" placeholder="Phone Number" value={cvData.Cv_PhoneNumber} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="email" className="form-control" name="Cv_Email" placeholder="Email" value={cvData.Cv_Email} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvExp_Experiences" placeholder="Experiences" value={cvData.CvExp_Experiences} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvEdu_Education" placeholder="Education" value={cvData.CvEdu_Education} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvIndustry_IndustryType" placeholder="Industry" value={cvData.CvIndustry_IndustryType} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvTs_TSkills" placeholder="Technical Skills" value={cvData.CvTs_TSkills} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvCertifications_Certifications" placeholder="Certifications" value={cvData.CvCertifications_Certifications} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvAs_ASkills" placeholder="Additional Skills" value={cvData.CvAs_ASkills} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvCourses_C" placeholder="Courses" value={cvData.CvCourses_C} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvLang_Lang" placeholder="Languages" value={cvData.CvLang_Lang} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <input type="text" className="form-control" name="CvAddMore_Add" placeholder="Add More" value={cvData.CvAddMore_Add} onChange={handleChange} />
                    </div>
                    <button type="submit" className="btn btn-cv">Create</button>
                    <button type="button" className="btn btn-pdf ms-1" onClick={saveAsPdf}>Save as PDF</button>
                </form>
            </div>
        </div>
    );
};

export default Cv;
