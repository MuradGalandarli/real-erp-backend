import { apiRequest } from "../core/api.js";
import { API_URL } from "../core/config.js";

export const fetchUsers = {
  
    getAll: async (page = 1, size = 10) => {
        return await apiRequest(`${API_URL}/get-all-user?page=${page}&size=${size}`);
    },
    getById: async (email) => {
        return await apiRequest(`${API_URL}/get-by-email-user?email=${email}`);
    },

    addUser: async (data) => {
        return await apiRequest(`${API_URL}/add-user`,"POST", data)
    },
    deleteUser: async (email) => {
        return await apiRequest(`${API_URL}/delete-user?email=${email}`, "DELETE")
    }

  
};
