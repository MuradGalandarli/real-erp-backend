import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js" 

export const fetchEmployee = {

    getAll: async (page = 1, size = 10) => {
        await apiRequest(API_URL/``)
    } 
}