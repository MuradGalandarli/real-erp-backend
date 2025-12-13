import { apiRequest } from "../core/api.js"
import { API_URL } from "../core/config.js"

export const fetchDepartment =
{
    getAll: async (page = 1, size = 10) => {
        return await apiRequest(`${API_URL}/get-all-department?page=${page}&size=${size}`)
    },
    add: async (department) => {
        return await apiRequest(`${API_URL}/add-department`, "POST", department)
    },
    getById: async (id)=>
    {
        return await apiRequest(`${API_URL}/get-By-Id?id=${id}`)
    }


}