import { createUserTableHeader } from "../../table/userTable.js";
import { fetchUsers } from "../../services/userService.js";


export async function getAllUserTable() {
    const content = document.getElementById("Content")
    let table = await createUserTableHeader()
    const users = await fetchUsers.getAll(1, 10);
    console.log(users)
    const mapUser = users.map(user => ({
        id: user.Id,
        name: user.name,
        email: user.email,
        surname: user.surname,
        companyId: user.companyId
    }));
    let id = 0
    
    mapUser.forEach(user =>

        table += `
        <tr>
          <td>${++id}</td>
            <td>${user.surname}</td>
            <td>${user.name}</td>
            <td>${user.email}</td>
            <td>${user.companyId}</td>
            <td><button  class="update-btn" data-email="${user.email}" id="getUpdateUserModal">Update</button></td>
            <td><button class="delete-btn" data-email="${user.email}" id="deleteUser">Delete</button></td>
        </tr>
       ` )

    table + `</table >`;
    return table;
}

export async function addUser() {
    const user =
    {
        surname: document.getElementById("surName").value,
        email: document.getElementById("email").value,
        company: document.getElementById("company").value,
        name: document.getElementById("name").value,
        password: document.getElementById("password").value,    
        companyId: document.getElementById("company").value
    }

    return await fetchUsers.addUser(user);
}

export async function getByEmailUser(email) {
    const user = await fetchUsers.getById(email);
    
    document.getElementById("surName").value = user.surname;
    document.getElementById("name").value = user.name;
    document.getElementById("company").value = user.company;
    document.querySelector("#submit-btn").dataset.userid = user.userId;
}

export async function updateUser(id) {
    const user = {
        "id": id,
        "surname": document.getElementById("surName").value,
        "name": document.getElementById("name").value,
        "companyId": document.getElementById("company").value
    }

        await fetchUsers.update(user)
}

export async function deleteUserAsync(id)
{
    await fetchUsers.deleteUser(id);
}








