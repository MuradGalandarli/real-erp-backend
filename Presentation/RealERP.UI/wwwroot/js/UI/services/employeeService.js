import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js" 

export const fetchEmployee = {

    getAll: async (page = 1, size = 10) => {
        return await apiRequest(`${API_URL}/get-all-employee?page=${page}&size=${size}`)
    },
        getById: async (id) => {
            return await apiRequest(`${API_URL}/get-By-Id-Employee?id=${id}`)
        } 
    } 
