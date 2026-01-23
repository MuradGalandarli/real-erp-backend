import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchRole = {
    getAll: async (page, size) => {
        return await apiRequest(`${API_URL}/get-all-role?page=${page}&size=${size}`)
    },
    getbyid: async (id) => {
        return await apiRequest(`${API_URL}/get-by-id-role?id=${id}`)
    },
    update: async (role) => {
        return await apiRequest(`${API_URL}/update-role`, "PUT", role)
    },
    add: async (role) => {
        return await apiRequest(`${API_URL}/add-role`,"POST",role)
    }
}

