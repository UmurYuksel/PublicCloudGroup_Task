import axios from "axios";
import authHeader from "./auth-header";
import Constants from "../utilities/constants";

///List of functions that I will use to send API request with axios.

const getVmList = () => {
  return axios.get(Constants.CLOUD_API_URL_GET_VM_LIST, { headers: authHeader() });
};

const deactivateMachine = (requestObject) => {
  return axios.post(Constants.CLOUD_API_URL_STOP_SELECTED_VM, { InstanceName: requestObject.instanceName, Zone: requestObject.zone }, { headers: authHeader() });
};

const activateMachine = (requestObject) => {
  return axios.post(Constants.CLOUD_API_URL_START_SELECTED_VM, { InstanceName: requestObject.instanceName, Zone: requestObject.zone }, { headers: authHeader() });
};

const suspendMachine = (requestObject) => {
  return axios.post(Constants.CLOUD_API_URL_SUSPEND_SELECTED_VM, { InstanceName: requestObject.instanceName, Zone: requestObject.zone }, { headers: authHeader() });
};

const resumeMachine = (requestObject) => {
  return axios.post(Constants.CLOUD_API_URL_RESUME_SELECTED_VM, { InstanceName: requestObject.instanceName, Zone: requestObject.zone }, { headers: authHeader() });
};


export default {
  getVmList,
  deactivateMachine,
  activateMachine,
  suspendMachine,
  resumeMachine,
};