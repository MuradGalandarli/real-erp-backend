import { apiRequest } from "../../core/api.js";
import { fetchRole } from "../../services/roleService.js"
import { roleTable } from "../../table/roleTable.js"
export async function getAllRole(page, size)
{
    const roles = await fetchRole.getAll(page, size)
    let table = roleTable();
    let id = 0;
    roles.forEach(role => {
      
        table += `
        <tr>
        <td>${++id}</td>
        <td>${role.name}</td>
        <td><button data-id=${role.id} class="update-btn" id="getRoleModal">Update</button></td>
        <td><button data-id=${role.id} id="deleteRole" class="delete-btn" >Delete</button></td>
        </tr>
        `
    })
    table += `</table>`
    return table;
}

export async function getByIdRoleAsync(id) {
    const role = await fetchRole.getbyid(id);
    document.getElementById("name").value = role.name;
    document.querySelector("#submit-btn").dataset.id = id;
}

export async function updateRoleAsync(id) {
    let role = {

        id: document.querySelector("#submit-btn").dataset.id,
        name: document.getElementById("name").value
    };
    await fetchRole.update(role);
}

export async function addRoleAsync() {
    let role = {
        name: document.getElementById("name").value
    }
    await fetchRole.add(role);
}