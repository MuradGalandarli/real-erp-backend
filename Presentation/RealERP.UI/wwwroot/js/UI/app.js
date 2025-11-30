import { getAllUserTable, closeModal } from "../UI/pages/user/user.js"
import { modalUser } from "../UI/components/modals/addUserModal.js"
import { getAllEmployeeAsync } from "../UI/pages/employee/employee.js"
import { getNavbar } from "../UI/components/navbar/navbar.js"

const content = document.getElementById("Content");

function openModal(html) {
    content.insertAdjacentHTML("beforeend", html);
}

document.addEventListener("click", (e) => {

    if (e.target.matches("#getModal")) {
        openModal(modalUser());
    }

    if (e.target.classList.contains("close-btn")) {
        e.target.closest(".modal-overlay").remove();
    }
});

document.addEventListener("submit", (e) => {
    if (e.target.id === "addUserForm") {
        e.preventDefault();
        
        const name = e.target.name.value;
        const email = e.target.email.value;

        console.log("Ad:", name, "Email:", email);

        e.target.reset();

        const modal = e.target.closest(".modal-overlay");
        if (modal) modal.remove();
    }
});

//content.innerHTML = await getNavbar()
    content.innerHTML = await getAllUserTable()


document.getElementById("userTableRender").addEventListener("click", async () => {
    content.innerHTML = await getAllUserTable();
})

document.getElementById("employeeTableRender").addEventListener("click", async () => {
    content.innerHTML = await getAllEmployeeAsync();
})

