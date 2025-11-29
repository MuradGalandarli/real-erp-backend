import { createUserTableHeader } from "../../table/userTable.js";
import { fetchUsers } from "../../services/userService.js";
//import { modalUser } from "../../components/modals/addUserModal.js"


export async function getAllUserTable() {
    const content = document.getElementById("Content")
    let table = await createUserTableHeader();
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

export function closeModal(e, clickedOutside) {
    console.log("AAA")
    debugger;
    if (clickedOutside) {
        if (e.target.classList.contains(".modal-overlay"))
            modal.classList.add("hide");
    } else modal.classList.add("hide");
}


//document.getElementById("getModal").addEventListener("click", () => {

//    const content = document.getElementById("Content");
//    content.innerHTML = modalUser();

//})
//await getAllUserTable();

////const openBtn = document.querySelector(".open-modal-btn");
//const modal = document.querySelector(".modal-overlay");
//const closeBtn = document.querySelector(".close-modal-btn");


 
//export function closeModal(modal, content, getAllUserTable, e, clickedOutside) {
//    debugger;
//    // Kənara klik zamanı bağlanır
//    if (clickedOutside) {
//        if (e.target.classList.contains("modal-overlay")) {
//            modal.classList.add("hide");
//        }
//    }
//    else {
//        modal.classList.add("hide");
//    }

//    // Modal bağlandıqdan sonra table yenilə
//    getAllUserTable();
//}


//console.log(document.getElementById("closeModal"));
//openBtn.addEventListener("click", openModal);
//modal.addEventListener("click", (e) => closeModal(e, true));
//closeBtn.addEventListener("click", closeModal);









