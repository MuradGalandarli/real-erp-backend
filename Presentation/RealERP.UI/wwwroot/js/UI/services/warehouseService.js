import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchWarehouse = {
    getAll: async (page, size) => {
        return apiRequest(`${API_URL}/get-all-warehouse?page=${page}&size=${size}`);
    },
    getbyId: async (id) => {
        return apiRequest(`${API_URL}/get-by-id-warehouse?id=${id}`)
    },
    update: async (warehouse) => {
        return apiRequest(`${API_URL}/update-warehouse`, "PUT", warehouse)
    },
    add: async (warehouse) => {
        return apiRequest(`${API_URL}/add-warehouse`, "POST", warehouse)
    },
    delete: async (id) => {
        return apiRequest(`${API_URL}/warehouse-delete?id=${id}`,"DELETE")
    }

}
