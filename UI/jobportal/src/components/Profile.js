import React from 'react';

const Profile = () => {
  return (
    <section className="vh-100 d-flex justify-content-center align-items-center">
      <div className="container">
        <div className="row">
          <div className="col-sm-6">

            <div className="px-5">
              <i className="fas fa-crow fa-2x me-3 pt-5" style={{ color: '#709085' }}></i>
              <span className="h1 fw-bold mb-0">Job Portal</span>
            </div>

            <div className="d-flex align-items-center h-custom-2 px-5 mt-5">

              <form style={{ width: '23rem', border: '1px solid #ccc', borderRadius: '8px', padding: '20px' }}>

                <h3 className="fw-normal mb-3 pb-3" style={{ letterSpacing: '1px', textAlign: 'center' }}>Log in</h3>

                <div data-mdb-input-init className="form-outline mb-4">
                  <input type="email" id="form2Example18" className="form-control form-control-lg" />
                  <label className="form-label" htmlFor="form2Example18">Email address</label>
                </div>

                <div data-mdb-input-init className="form-outline mb-4">
                  <input type="password" id="form2Example28" className="form-control form-control-lg" />
                  <label className="form-label" htmlFor="form2Example28">Password</label>
                </div>

                <div className="pt-1 mb-4">
                  <button data-mdb-button-init data-mdb-ripple-init className="btn btn-info btn-lg btn-block" type="button">Login</button>
                </div>
                
                <p style={{ textAlign: 'center' }}>Don't have an account? <a href="./register" className="link-info">Register here</a></p>


              </form>

            </div>

          </div>
         
        </div>
      </div>
    </section>
  );
}

export default Profile;
