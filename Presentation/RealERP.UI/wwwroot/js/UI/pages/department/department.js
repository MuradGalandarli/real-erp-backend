import { createDepartmentTable } from "../../table/departmentTable.js"
import { fetchDepartment } from "../../services/departmentService.js"

export async function getAllDepartmentAsync(page, size) {
    let table = createDepartmentTable();
    const department = await fetchDepartment.getAll(page, size);
    let id =0
    department.forEach(dep => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${dep.name}</td>
        <td><button data-id="${dep.id}"id="getUpdateDepartmentModal" class="update-btn">Update</button></td>
        <td><button class="delete-btn">Sil</button></td>
        </tr>
        `
    })
    table +=`</table>`
    return table;
}

export async function addDepartmentAsync() {
    const department = { name: document.getElementById("name").value };
    await fetchDepartment.add(department);
}

export async function getByIdDepartment(id) {
    const department = await fetchDepartment.getById(id);
    let name = document.getElementById("name").value = department.name;

}