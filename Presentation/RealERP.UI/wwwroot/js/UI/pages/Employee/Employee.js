import { fetchEmployee } from "../../services/employeeService.js"
import { fetchUsers } from "../../services/userService.js";
import { createEmployeeTable } from "../../table/employeeTable.js"
    
export async function getAllEmployeeAsync() {
   
    const data = await fetchEmployee.getAll();
    const employees = data.employees;
    
    let table = createEmployeeTable();
   
    let id = 0
   
    employees.forEach(employee => {
       
        table += `
        <tr>
        <td>${++id}</td>
        <td>${employee.fullName}</td>
        <td>${employee.position}</td>
        <td>${employee.departmentId}</td>
        <td>${employee.userId}</td>
        <td><button data-user-id=${employee.id} id="getUpdateEmployeModal">Update</button></td>
        <td><button>Delete</button></td>
        </tr> `
    }
    );
    table += `</table>`
    return table;

}

export async function getByIdEmployeeAsync(id) {
    const data = await fetchEmployee.getById(id)
    document.querySelector("#fullName").value = data.fullName;
    document.querySelector("#position").value = data.position;
    document.querySelector("#departmentId").value = data.departmentId;
    document.querySelector("#submit-btn").dataset.employeeid = id;
}

export async function updateEmployeeAsync(id) {

    const employee = {
        id:id,
        fullName: document.querySelector("#fullName").value,
        position: document.querySelector("#position").value,
        departmentId: document.querySelector("#departmentId").value
    }
    await fetchEmployee.update(employee);

}

export async function addEmployee() {
    const employee = {
        fullName: document.querySelector("#fullName").value,
        position: document.querySelector("#position").value,
        departmentId: document.querySelector("#departmentId").value,
        userId: document.querySelector("#userId").value
    }
    debugger;
    await fetchEmployee.add(employee);
}