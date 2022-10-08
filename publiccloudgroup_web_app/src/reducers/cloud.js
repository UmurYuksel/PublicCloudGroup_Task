import {
    FETCH_LIST
  } from "../actions/types";
    
  const initialState = {
    vmList: []
  }
    
  export default function (state = initialState, action) {
    const { type, payload } = action;
    switch (type) {
      case FETCH_LIST:
        return {
          ...state,
          vmList: payload.vmList,
        };
      default:
        return state;
    }
  }