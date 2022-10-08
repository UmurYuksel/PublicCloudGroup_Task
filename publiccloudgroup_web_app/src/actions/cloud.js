import {
    FETCH_LIST,
} from "./types";

import CloudService from "../services/cloud.service";
import { NotificationManager } from 'react-notifications';

export const fetchList = () => (dispatch) => {
    return CloudService.getVmList().then(
        (data) => {

            dispatch({
                type: FETCH_LIST,
                payload: { vmList: data.data },
            });

            //Im using 3rd part notification library.
            NotificationManager.success('Virtual Machine Listed Refreshed', "Operation Successful",4000);
            return Promise.resolve();
        },
        (error) => {

            const message =
                (error.response &&
                    error.response.data) ||
                error.toString();

            NotificationManager.error(message, 'Error !', 5000);
            return Promise.reject();
        }
    );
};

export const activateMachine = (instanceName, zone) => (dispatch) => {

        return CloudService.activateMachine({instanceName, zone}).then(
            (data) => {
                //If operation is successfull, then re-fetch the virtual machines list.
                dispatch(fetchList());
                NotificationManager.success(instanceName + ' Virtual Machine has been Activated!', "Operation Successful", 5000);
                return Promise.resolve();
            },
            (error) => {
                console.log(error)
                const message =
                    (error.response &&
                        error.response.data) ||
                    error.toString();

                NotificationManager.error(message, 'Error !', 5000);
                return Promise.reject();
            }

        );
};

export const deactivateMachine = (instanceName, zone) => (dispatch) => {

    return CloudService.deactivateMachine({instanceName, zone}).then(
        (data) => {
            //If operation is successfull, then re-fetch the virtual machines list.
            dispatch(fetchList());
            NotificationManager.success(instanceName + ' Virtual Machine has been Deactivated!', "Operation Successful",5000);
            return Promise.resolve();
        },
        (error) => {
            console.log(error)
            const message = 
                (error.response &&
                    error.response.data) ||
                error.toString();

            NotificationManager.error(message, 'Error !', 5000);
            return Promise.reject();
        }

    );
};

export const suspendSelectedMachine = (instanceName, zone) => (dispatch) => {

    return CloudService.suspendMachine({instanceName, zone}).then(
        (data) => {
            //If operation is successfull, then re-fetch the virtual machines list.
            dispatch(fetchList());
            NotificationManager.success(instanceName + ' Virtual Machine has been Suspended!', "Operation Successful",5000);
            return Promise.resolve();
        },
        (error) => {
            console.log(error)
            const message = 
                (error.response &&
                    error.response.data) ||
                error.toString();

            NotificationManager.error(message, 'Error !', 5000);
            return Promise.reject();
        }

    );
};

export const resumeSelectedMachine = (instanceName, zone) => (dispatch) => {

    return CloudService.resumeMachine({instanceName, zone}).then(
        (data) => {
            //If operation is successfull, then re-fetch the virtual machines list.
            dispatch(fetchList());
            NotificationManager.success(instanceName + ' Virtual Machine now resumes!', "Operation Successful",5000);
            return Promise.resolve();
        },
        (error) => {
            console.log(error)
            const message = 
                (error.response &&
                    error.response.data) ||
                error.toString();

            NotificationManager.error(message, 'Error !', 5000);
            return Promise.reject();
        }

    );
};