import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchWarehouse = {
    getAll: async (page, size) => {
        return apiRequest(`${API_URL}/get-all-warehouse?page=${page}&size=${size}`);
    }
}
