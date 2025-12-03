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
    document.querySelector("#userId").value = data.userId;
}

 //public int Id { get; set; }
 //       public string FullName { get; set; }
 //       public string Position { get; set; }
 //       public int DepartmentId { get; set; }
 //       public string ? UserId { get; set; }
