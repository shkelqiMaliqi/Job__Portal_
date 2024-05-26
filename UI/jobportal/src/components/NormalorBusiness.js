import React, { useState } from 'react';

function NormalorBusiness() {
  const [userRole, setUserRole] = useState('');

  const handleRoleSelection = (role) => {
    setUserRole(role);
    if (role === 'normal') {
      window.location.href = '/register/';
    } else if (role === 'business') {
      window.location.href = '/business/';
    }
  };

  return (
    <div className="mask d-flex align-items-center h-100 gradient-custom-3">
      <div className="container h-100">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="col-12 col-md-9 col-lg-7 col-xl-6">
            <div className="card" style={{ borderRadius: '15px' }}>
              <div className="card-body p-5">
                <h2 className="text-uppercase text-center mb-5">Choose User Type</h2>
                <div className="form-group mb-4">
                  <label className="d-block mb-2">User Type:</label>
                  <div className="btn-group" role="group">
                    <button 
                      type="button" 
                      className={`btn btn-lg ${userRole === 'normal' ? 'btn-primary' : 'btn-outline-primary'}`}
                      onClick={() => handleRoleSelection('normal')}
                    >
                      Normal User
                    </button>   
                    <button 
                      type="button" 
                      className={`btn btn-lg ${userRole === 'business' ? 'btn-primary' : 'btn-outline-primary'}`}
                      onClick={() => handleRoleSelection('business')}
                    >
                      Business User
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default NormalorBusiness;
