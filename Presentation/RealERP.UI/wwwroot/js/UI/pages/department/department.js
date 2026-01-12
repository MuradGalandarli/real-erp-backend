import { createDepartmentTable } from "../../table/departmentTable.js"
import { fetchDepartment } from "../../services/departmentService.js"

export async function getAllDepartmentAsync(page, size) {
    let table = createDepartmentTable();
    const department = await fetchDepartment.getAll(page, size);
    let id = 0
    console.log(department)
    department.forEach(dep => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${dep.name}</td>
        <td>${dep.companyId}</td>
        <td><button data-id="${dep.id}"id="getUpdateDepartmentModal" class="update-btn">Update</button></td>
        <td><button data-id="${dep.id}" id="deleteDepartment" class="delete-btn">Sil</button></td>
        </tr>
        `
    })
    table +=`</table>`
    return table;
}

export async function addDepartmentAsync() {
    const department = {
        name: document.getElementById("name").value,
        companyId: document.getElementById("company").value,
    };
    await fetchDepartment.add(department);
}

export async function getByIdDepartment(id) {
    const department = await fetchDepartment.getById(id);
    document.getElementById("name").value = department.name;
    document.getElementById("company").value = department.companyId;
    document.querySelector("#submit-btn").dataset.id = id;
}

export async function updateDepartmentAsync(id) {
    const department = {
        id: id,
        name: document.getElementById("name").value,
        companyId: document.getElementById("company").value
    }
    await fetchDepartment.update(department);
}

export async function deleteDepartment(id) {
    await fetchDepartment.delete(id);
}