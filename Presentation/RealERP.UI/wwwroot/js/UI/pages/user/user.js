import { createUserTableHeader } from "../../table/userTable.js";
import { fetchUsers } from "../../services/userService.js";



export async function getAllUserTable() {
    const content = document.getElementById("Content")
    let table = await createUserTableHeader()
    const users = await fetchUsers.getAll(1, 10);
    //debugger;
    const mapUser = users.map(user => ({
        id: user.Id,
        name: user.name,
        email: user.email
    }) );
    let id = 0
   
    mapUser.forEach(user =>

        table += `
        <tr>
          <td>${++id}</td>
            <td>${user.name}</td>
            <td>${user.email}</td>
            <td><button class="updateUser" data-userid="${user.id}">Update</button></td>
            <td><button class="deleteUser" data-userid="${user.id}">Delete</button></td>
        </tr>
       ` )

    table + `</table >`;
    return table;
}
 
export function openModal() {
    modal.classList.remove("hide");
}






