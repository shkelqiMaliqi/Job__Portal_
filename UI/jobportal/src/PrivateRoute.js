
/*
import React from 'react';
import { Route, Navigate } from 'react-router-dom';
import { getToken } from './Auth';

const PrivateRoute = ({ element: Element, ...rest }) => {
  return (
    <Route
      {...rest}
      element={
        getToken() ? (
          <Element />
        ) : (
          <Navigate to="/loginpage" />
        )
      }
    />
  );
};

export default PrivateRoute;
*/