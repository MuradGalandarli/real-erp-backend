import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchEmployee = {

    getAll: async (page = 1, size = 10) => {
        return await apiRequest(`${API_URL}/get-all-employee?page=${page}&size=${size}`)
    },
    getById: async (id) => {
        return await apiRequest(`${API_URL}/get-By-Id-Employee?id=${id}`)
    },
    update: async (employee) => {
        return await apiRequest(`${API_URL}/update-employee`, "PUT", employee)
    },
    add: async (employee) => {
        return await apiRequest(`${API_URL}/add-employee`, "POST", employee)
    },
    delete: async (id) => {
        return await apiRequest(`${API_URL}/`)
    }

} 
