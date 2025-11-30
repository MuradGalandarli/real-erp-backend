import { fetchEmployee } from "../../services/employeeService.js"
import { createEmployeeTable } from "../../table/employeeTable.js"

export async function getAllEmployeeAsync() {
  
    const data = await fetchEmployee.getAll();
    const employees = data.employees; 
   
    console.log(employees)
    let table = createEmployeeTable();
    debugger;
   //let mapEmployess = employees.map(emp => ({
   //     fullName: emp.fullName,
   //     position: emp.position,
   //     department: DepartmentId,  
   //     user: UserId
   // }));
    
    let id = 0
    employees.forEach(employee => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${employee.fullName}</td>
        <td>${employee.position}</td>
        <td>${employee.departmentId}</td>
        <td>${employee.userId}</td>
        </tr> `
    }
    );
    table += `</table>`
    return table;


}

