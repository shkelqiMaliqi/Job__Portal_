import React from 'react';
import { Route } from 'react-router-dom';
import { getToken } from './Auth';
import { useNavigate } from 'react-router-dom';

const PrivateRoute = ({ component: Component, ...rest }) => {
  const navigate = useNavigate();

  return (
    <Route
      {...rest}
      render={(props) =>
        getToken() ? (
          <Component {...props} />
        ) : (
          (() => {
            navigate("/loginpage");
            return null;
          })()
        )
      }
    />
  );
};

export default PrivateRoute;
