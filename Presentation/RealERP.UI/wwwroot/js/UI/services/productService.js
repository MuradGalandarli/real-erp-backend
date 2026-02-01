import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchProduct = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-product?page=${page}&size=${size}`)
    },
    getById: async (id) => {
        return await apiRequest(`${API_URL}/get-by-id-product?id=${id}`)
    },
    update: async (product) => {
        return await apiRequest(`${API_URL}/update-product`, "PUT", product)
    },
    add: async (product) => {
        return await apiRequest(`${API_URL}/add-product`, "POST", product)
    }
}