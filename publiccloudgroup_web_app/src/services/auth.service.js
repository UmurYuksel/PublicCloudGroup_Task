import axios from "axios";
import Constants from "../utilities/constants";

///List of functions that I will use to send API request with axios.

const login = async (Email, Password) => {
    const response = await axios.post(Constants.AUTH_API_URL_LOGIN, {
        Email,
        Password
    });
    if (response.data.token) {
        localStorage.setItem("user", JSON.stringify(response.data));
    }
    return response.data;
};

const logout = () => {
    localStorage.removeItem("user");
};

export default { login, logout, };
