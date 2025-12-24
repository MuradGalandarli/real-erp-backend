import { API_URL } from "../core/config.js"
import { apiRequest } from "../core/api.js"

export const fetchBrand = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-brand?page=${page}&size=${size}`);
    },
    add: async (brand) => {
        return await apiRequest(`${API_URL}/add-brnad`, "POST", brand)
    }
} 