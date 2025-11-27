import { createUserTableHeader } from "../../table/userTable.js";
import { fetchUsers } from "../../services/userService.js";

async function getAllUserTable() {
    const content = document.getElementById("Content")
    let table = await createUserTableHeader();
    const users = await fetchUsers.getAll(1, 10);

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

    content.innerHTML = table +`</table >`;


    console.log(users)

}

await getAllUserTable();

console.log('Test');
