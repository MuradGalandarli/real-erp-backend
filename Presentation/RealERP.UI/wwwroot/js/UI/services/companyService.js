import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js" 

export const fetchCompany = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-company?page=${page}&size=${size}`) 
    },
    add: async (companyDto) => {
        return await apiRequest(`${API_URL}/add-company`, "POST", { companyDto: companyDto })
    }
}