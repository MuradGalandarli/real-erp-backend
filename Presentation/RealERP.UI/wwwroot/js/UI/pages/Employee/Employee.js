import { fetchEmployee } from "../../services/employeeService.js"
import { createEmployeeTable } from "../../table/employeeTable.js"
    
export async function getAllEmployeeAsync() {
  
    const data = await fetchEmployee.getAll();
    const employees = data.employees; 
   
    console.log(employees)
    let table = createEmployeeTable();
    debugger;
  
    
    let id = 0
    employees.forEach(employee => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${employee.fullName}</td>
        <td>${employee.position}</td>
        <td>${employee.departmentId}</td>
        <td>${employee.userId}</td>
        <td><button data-userId=${employee.id} id="getUpdateEmployeModal">Update</button></td>
        <td><button>Delete</button></td>
        
        </tr> `
    }
    );
    table += `</table>`
    return table;


}

