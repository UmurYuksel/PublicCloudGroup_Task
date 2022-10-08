import React, { useState, useEffect, useCallback } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Routes, Route, Link, useLocation } from "react-router-dom";
import PCG_Image from './assets/PCG_background.png';

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import 'react-notifications/lib/notifications.css';

import {NotificationContainer} from 'react-notifications'

import Login from "./pages/Login";
import Home from "./pages/Home";
import VmManagement from "./pages/VmManagement";

import { logout } from './actions/auth';


const App = () => {

  const [showVmBoard, setShowVmBoard] = useState(false);
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  const logOut = useCallback(() => {
    dispatch(logout());
  }, [dispatch]);

  useEffect(() => {
    if (currentUser) {
      setShowVmBoard(true);
    } else {
      setShowVmBoard(false);
    }
  }, [currentUser]);

  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <Link to={"/"} className="navbar-brand">
          Public Cloud Group App
        </Link>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/home"} className="nav-link">
              Home
            </Link>
          </li>

          {showVmBoard && (
            <li className="nav-item">
              <Link to={"/vm-management"} className="nav-link">
                Vm Management
              </Link>
            </li>
          )}
        </div>

        {currentUser ? (
          <div className="navbar-nav ml-auto">
            <li className="nav-item">
              <Link to={"/profile"} className="nav-link">
                {currentUser.username}
              </Link>
            </li>
            <li className="nav-item">
              <a href="/login" className="nav-link" onClick={logOut}>
                Log Out
              </a>
            </li>
          </div>
        ) : (
          <div className="navbar-nav ml-auto">
            <li className="nav-item">
              <Link to={"/login"} className="nav-link">
                Login
              </Link>
            </li>
          </div>
        )}
      </nav>

      <div className="container mt-3" >
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/home" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/vm-management" element={<VmManagement />} />
        </Routes>
      </div>
      <NotificationContainer/>
    </div>
  );
};

export default App;