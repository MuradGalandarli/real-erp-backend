import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js" 

export const fetchCategory = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-category?page=${page}&size=${size}`, "GET")
    }
        
}
