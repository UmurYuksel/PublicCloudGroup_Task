import React, { useState } from 'react';
import { useDispatch } from "react-redux";
import { activateMachine, deactivateMachine, suspendSelectedMachine, resumeSelectedMachine } from '../../actions/cloud';
import Loading from 'react-fullscreen-loading';

const VmCard = ({ singleItem }) => {

  const [loading, setLoading] = useState(false);
  const dispatch = useDispatch();

  //Start or Stop the Machine.
  const handleStartStop = async () => {

    setLoading(true);

    //If its stopped, then start the machine.
    if (singleItem.status === "TERMINATED") {
      return dispatch(activateMachine(singleItem.name, singleItem.zone)).then(() => {
        setLoading(false);
      })
        .catch(() => {
          setLoading(false);
        });
    }

    //If Machine is status is started, then stop it.
    return dispatch(deactivateMachine(singleItem.name, singleItem.zone)).then(() => {
      setLoading(false);
    })
      .catch(() => {
        setLoading(false);
      });
  }

  //Suspend or Resume the Machine.
  const handleSuspendResume = async () => {

    setLoading(true);

    //If its SUSPENDED, then resume the machine.
    if (singleItem.status === "SUSPENDED") {
      //If Machine is status is started, then stop it.
      return dispatch(resumeSelectedMachine(singleItem.name, singleItem.zone)).then(() => {
        setLoading(false);
      })
        .catch(() => {
          setLoading(false);
        });

    }

    //MACHINE RESUMES, SUSPEND IT.
    return dispatch(suspendSelectedMachine(singleItem.name, singleItem.zone)).then(() => {
      setLoading(false);
    })
      .catch(() => {
        setLoading(false);
      });

  }


  //Returning the card as a fragment.
  return (
    <>
      <Loading loading={loading} background="#2ecc71" loaderColor="#3498db" />
      {/*NECESSARY CONDITIONAL STYLING */}
      <div className={singleItem.status === "TERMINATED" ? "card text-bg-danger mb-3" : singleItem.status === "SUSPENDED" ? "card text-bg-warning mb-3" : "card text-bg-success mb-3"}>
        <div className="card-header">
          <h5 className="card-title">
            Instance Name: {singleItem.name}
          </h5>
        </div>
        <div className="card-body">
          <h5>
            Status: {singleItem.status} <p></p>
          </h5>
          <h5>
            Zone: {singleItem.zone}
          </h5>
          <p className="card-text">
            Last Started: {singleItem.lastStartTimestamp}  -  Last Stopped: {singleItem.lastStopTimestamp}
          </p>
        </div>
        <div className="card-footer">
          <div className="d-grid gap-2">
            <button
              className={singleItem.status === "TERMINATED" ? "btn btn-success" : "btn btn-danger"}
              type="button"
              onClick={handleStartStop}
            >
              {singleItem.status === "TERMINATED" ? "Activate" : "Stop"}
            </button>
            {/* 
              Important ! 
              Stopped Virtual machine cannot be suspended.
              Also, Resume request can be only sent for suspended machines.
            
            */}
            {singleItem.status != "TERMINATED" ? <button
              className={singleItem.status === "SUSPENDED" ? "btn btn-success" : "btn btn-danger"}
              type="button"
              onClick={handleSuspendResume}
            >
              {singleItem.status === "SUSPENDED" ? "Resume This Vm" : "Suspend This Vm"}
            </button> : null
            }

          </div>
        </div>
      </div>
    </>
  )
}
export default VmCard;