//In My Local Machine, the API broadcast itself from this port. It may be different in your machine.
const AUTH_API_BASE_URL_DEVELOPMENT = "https://localhost:7108/api/Auth"; 
const CLOUD_API_BASE_URL_DEVELOPMENT = "https://localhost:7108/api/CloudManagement";

const AUTH_API_BASE_URL_PRODUCTION = "dummy_production_url";
const CLOUD_API_BASE_URL_PRODUCTION = "dummy_production_url";

//Login
//GetVmList
//StopSelectedVm
//StartSelectedVm

const ENDPOINTS = {
    LOGIN:"Login",
    GET_VM_LIST: "GetVmList",
    START_SELECTED_VM: "StartSelectedVm",
    STOP_SELECTED_VM: "StopSelectedVm",
    SUSPEND_SELECTED_VM: "SuspendSelectedVM",
    RESUME_SELECTED_VM: "ResumeSelectedVM",
};

const development = {
    AUTH_API_URL_LOGIN : `${AUTH_API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.LOGIN}`,
    CLOUD_API_URL_GET_VM_LIST : `${CLOUD_API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_VM_LIST}`,
    CLOUD_API_URL_START_SELECTED_VM : `${CLOUD_API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.START_SELECTED_VM}`,
    CLOUD_API_URL_STOP_SELECTED_VM : `${CLOUD_API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.STOP_SELECTED_VM}`,
    CLOUD_API_URL_SUSPEND_SELECTED_VM : `${CLOUD_API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.SUSPEND_SELECTED_VM}`,
    CLOUD_API_URL_RESUME_SELECTED_VM : `${CLOUD_API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.RESUME_SELECTED_VM}`,
}

const production = {
    AUTH_API_URL_LOGIN : `${AUTH_API_BASE_URL_PRODUCTION}/${ENDPOINTS.LOGIN}`,
    CLOUD_API_URL_GET_VM_LIST : `${CLOUD_API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_VM_LIST}`,
    CLOUD_API_URL_START_SELECTED_VM : `${CLOUD_API_BASE_URL_PRODUCTION}/${ENDPOINTS.START_SELECTED_VM}`,
    CLOUD_API_URL_STOP_SELECTED_VM : `${CLOUD_API_BASE_URL_PRODUCTION}/${ENDPOINTS.STOP_SELECTED_VM}`,
    CLOUD_API_URL_SUSPEND_SELECTED_VM : `${CLOUD_API_BASE_URL_PRODUCTION}/${ENDPOINTS.SUSPEND_SELECTED_VM}`,
    CLOUD_API_URL_RESUME_SELECTED_VM : `${CLOUD_API_BASE_URL_PRODUCTION}/${ENDPOINTS.RESUME_SELECTED_VM}`,
}

const Constants = process.env.NODE_ENV ==='development' ? development : production;

export default Constants;