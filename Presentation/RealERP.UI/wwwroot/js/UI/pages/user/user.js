import { createUserTableHeader } from "../../table/userTable.js";
import { fetchUsers } from "../../services/userService.js";


export async function getAllUserTable() {
    const content = document.getElementById("Content")
    let table = await createUserTableHeader()
    const users = await fetchUsers.getAll(1, 10);

    const mapUser = users.map(user => ({
        id: user.Id,
        name: user.name,
        email: user.email,
        surname: user.surname
    }));
    let id = 0

    mapUser.forEach(user =>

        table += `
        <tr>
          <td>${++id}</td>
            <td>${user.surname}</td>
            <td>${user.name}</td>
            <td>${user.email}</td>
            <td><button  class="update-btn" data-email="${user.email}" id="getUpdateUserModal">Update</button></td>
            <td><button class="delete-btn" data-userid="${user.id}">Delete</button></td>
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
        name: document.getElementById("name").value,
        password: document.getElementById("password").value
    }

    return await fetchUsers.addUser(user);
}

export async function getByEmailUser(email) {
    const user = await fetchUsers.getById(email);
    console.log(user)
    document.getElementById("surName").value = user.surname;
    document.getElementById("name").value = user.name;
    document.querySelector("#submit-btn").dataset.userid = user.userId;
}

export async function updateUser(id) {
  
    const user = {
        "id": id,
        "surname": document.getElementById("surName").value,
        "name": document.getElementById("name").value
    }

        await fetchUsers.update(user)
        console.log("work")
    }








