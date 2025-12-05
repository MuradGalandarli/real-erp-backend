import { getAllUserTable } from "../UI/pages/user/user.js"
import { modalAddForUser, modalUpdateForEmployee } from "./components/modals/modal.js"
import { getAllEmployeeAsync, getByIdEmployeeAsync, updateEmployeeAsync, addEmployee } from "../UI/pages/employee/employee.js"


const content = document.getElementById("Content");


function openModal(html) {
    const wrapper = document.createElement("div");
    wrapper.innerHTML = html;
    const modalEl = wrapper.firstElementChild;
    document.body.appendChild(modalEl);
}

document.addEventListener("click", (e) => {

    if (e.target.matches("#getAddUserModal")) {
     
        openModal(modalAddForUser());
        
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



    document.getElementById("userTableRender").addEventListener("click", async () => {
        content.innerHTML = await getAllUserTable();
    })

    document.getElementById("employeeTableRender").addEventListener("click", async () => {
        content.innerHTML = await getAllEmployeeAsync();
    })

//document.getElementById("getByIdEmployee").addEventListener("click", () => {

//})

document.addEventListener("click", async (e) => {

    if (e.target.matches("#getUpdateEmployeModal")) {
       
        const id = e.target.dataset.userId;
        openModal(modalUpdateForEmployee());
       
        document.getElementById("formMode").value = "update";
        const showDiv = document.getElementById("show");
        if (showDiv) {
            showDiv.style.display = "none"; 
        }
        
        await getByIdEmployeeAsync(id);
    }

    if (e.target.matches("#getAddModal")) {
        openModal(modalUpdateForEmployee());
        document.getElementById("formMode").value = "add";
    }

    if (e.target.classList.contains("close-btn")) {
        e.target.closest(".modal-overlay").remove();
    }
});


document.addEventListener("submit",async (e) => {
    if (e.target.id === "employeeForm") {
        e.preventDefault();

        const mode = document.getElementById("formMode").value;
        if (mode == "update") {
            const id = document.querySelector("#submit-btn").dataset.employeeid;
            await updateEmployeeAsync(id);  
            console.log("update")
        }
        if (mode == "add") {
            await addEmployee();
        }

        content.innerHTML = await getAllEmployeeAsync();
        e.target.reset();

        const modal = e.target.closest(".modal-overlay");
        if (modal) modal.remove();
    }
});






content.innerHTML = await getAllUserTable()