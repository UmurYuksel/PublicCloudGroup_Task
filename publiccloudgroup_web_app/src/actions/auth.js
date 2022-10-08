import {
    LOGIN_SUCCESS,
    LOGIN_FAIL,
    LOGOUT,
} from "./types";

import AuthService from "../services/auth.service";
import { NotificationManager} from 'react-notifications';

export const login = (email, password) => (dispatch) => {
    return AuthService.login(email, password).then(
        (data) => {
            dispatch({
                type: LOGIN_SUCCESS,
                payload: { user: data },
            });

            return Promise.resolve();
        },
        (error) => {

            const message =
                (error.response &&
                    error.response.data) ||
                error.toString();

            dispatch({
                type: LOGIN_FAIL,
            });

            NotificationManager.error(message, 'Error!', 5000);

            return Promise.reject();
        }
    );
};

export const logout = () => (dispatch) => {
    AuthService.logout();

    dispatch({
        type: LOGOUT,
    });
};