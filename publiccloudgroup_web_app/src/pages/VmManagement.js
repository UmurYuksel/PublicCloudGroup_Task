import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { Navigate } from 'react-router-dom';
import { fetchList } from '../actions/cloud';
import VirtualMachineList from '../components/ui/VmList';

function VmManagement() {

  const [machineList, setMachineList] = useState([]);
  const dispatch = useDispatch();

  const { user: currentUser } = useSelector((state) => state.auth);
  const { vmList } = useSelector((state) => state.cloud);


  useEffect(() => {
    (async function () {
      await dispatch(fetchList());
    })();
  }, [dispatch]);

  useEffect(() => {
    (async function () {
      setMachineList(vmList);
    })();
  }, [vmList]);

  if (!currentUser) {
    return <Navigate to="/login" />;
  }

  return (
    <div className="col-md-12">

      {
        (machineList && machineList.length > 0) ?
          <>
            <h3>List of Virtual Machines</h3>
            <VirtualMachineList
              listData={machineList}
            />
          </>

          : null
      }
    </div>
  )
}

export default VmManagement;