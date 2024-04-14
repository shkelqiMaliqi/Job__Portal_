import React from 'react';

const Profile = () => {
  return (
    <section className="vh-100">
      <div className="container-fluid">
        <div className="row">
          <div className="col-sm-6 text-black">

            <div className="px-5 ms-xl-4">
              <i className="fas fa-crow fa-2x me-3 pt-5 mt-xl-4" style={{ color: '#709085' }}></i>
              <span className="h1 fw-bold mb-0 ">Job Portal</span>
            </div>

            <div className="d-flex align-items-center h-custom-2 px-5 ms-xl-4 mt-5 pt-5 pt-xl-0 mt-xl-n5">

              <form style={{ width: '23rem' }}>

                <h3 className="fw-normal mb-3 pb-3" style={{ letterSpacing: '1px' }}>Log in</h3>

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
                
                <p>Don't have an account? <a href="./register" className="link-info">Register here</a></p>


              </form>

            </div>

          </div>
         
        </div>
      </div>
    </section>
  );
}

export default Profile;
