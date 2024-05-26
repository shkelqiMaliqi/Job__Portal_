import React from 'react';

const WhyUs = () => {
  return (
    <main className="whyus_main">
      <div className="h2_whyus_intro">
        <h2>About Us</h2>
        <p className="whyUs_desc">Welcome to Job Portal, your ultimate destination for finding the perfect job match. 
          At Job Portal, we understand the challenges job seekers face in today's competitive market, 
          which is why we strive to provide a seamless and efficient platform to connect talented 
          individuals with their dream opportunities.</p>
        
        <h2 className="ourmission">
          Our Mission
        </h2>
        
        <p className="whyUs_desc">
          Our mission at Job Portal is simple yet profound: to empower individuals by helping them discover, 
          apply, and secure their ideal jobs. We aim to bridge the gap between employers and job seekers, facilitating 
          meaningful connections that drive personal and professional growth.
        </p>
      </div>
      
      <div className="whyUs_spliter">
        <h3 className="whyUs_Split">What Sets us Apart:</h3>
      </div>
      
      <div className="whyUs_sectors">
        <div className="sector_1">
          <h2 className="sector_h2">User-Friendly Interface</h2>
          <p className="sector_p">Our intuitive platform is designed to make the job search process as smooth and hassle-free as possible. 
            With advanced search filters and personalized recommendations, finding the right job has never been easier.</p>
        </div>
        <div className="sector_1">
          <h2 className="sector_h2">Quality Assurance</h2>
          <p className="sector_p">We prioritize quality over quantity, thoroughly vetting each job listing to ensure legitimacy and relevance. 
            This commitment to quality helps streamline the job search process and saves our users valuable time and effort.</p>
        </div>
        <div className="sector_1">
          <h2 className="sector_h2">Career Resources</h2>
          <p className="sector_p">
            In addition to job listings, we offer a wealth of resources and tools to support our users throughout their career journey.
            From resume writing tips to interview preparation advice, we're here to help you succeed every step of the way.</p>
        </div>
        
      </div>
    </main>
  );
};

export default WhyUs;
