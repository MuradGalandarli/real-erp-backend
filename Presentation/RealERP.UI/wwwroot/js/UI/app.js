import { getAllUserTable, addUser, getByEmailUser } from "../UI/pages/user/user.js"
import { modalForUser, modalUpdateForEmployee } from "./components/modals/modal.js"
import { getAllEmployeeAsync, getByIdEmployeeAsync, updateEmployeeAsync, addEmployee } from "../UI/pages/employee/employee.js"


const content = document.getElementById("Content");


function openModal(html) {
    const wrapper = document.createElement("div");
    wrapper.innerHTML = html;
    const modalEl = wrapper.firstElementChild;
    document.body.appendChild(modalEl);
}



    document.getElementById("userTableRender").addEventListener("click", async () => {
        content.innerHTML = await getAllUserTable();
    })

    document.getElementById("employeeTableRender").addEventListener("click", async () => {
        content.innerHTML = await getAllEmployeeAsync();
    })


document.addEventListener("click", async (e) => {
    const id = e.target.dataset.userId;
    if (e.target.matches("#getUpdateEmployeModal")) {
       
       
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


    if (e.target.matches("#getAddUserModal")) {

        openModal(modalForUser());
        const showDiv = document.getElementById("show");
        if (showDiv) {
            showDiv.style.display = "block";
        }

    }
    if (e.target.matches("#getUpdateUserModal")) {
        const email = e.target.dataset.email




        openModal(modalForUser());
        await getByEmailUser(email)
        
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
        }
      
        if (mode == "add") {

            await addEmployee();
           
        }
        content.innerHTML = await getAllEmployeeAsync();
    }
        
        if (e.target.id == "addUserForm") {
            const userMode = document.getElementById("userFromMode").value
            if (userMode == "addUser") {
                
                await addUser();
                content.innerHTML = await getAllUserTable()
            }

   
        }
       
        e.target.reset();

        const modal = e.target.closest(".modal-overlay");
        if (modal) modal.remove();
    
});






content.innerHTML = await getAllUserTable()