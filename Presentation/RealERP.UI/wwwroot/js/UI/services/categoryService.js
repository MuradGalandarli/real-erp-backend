import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js" 

export const fetchCategory = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-category?page=${page}&size=${size}`, "GET")
    },
    add: async (category) => {
        return await apiRequest(`${API_URL}/add-category`, "POST", category);
    },
    delete: async (id) => {
        return await apiRequest(`${API_URL}/delete-category?id=${id}`, "DELETE")
    },
    getById: async (id) => {
        return await apiRequest(`${API_URL}/get-by-id-category?id=${id}`)
    }
        
}
