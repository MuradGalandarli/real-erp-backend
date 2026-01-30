import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchProduct = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-product?page=${page}&size=${size}`)
    }
}