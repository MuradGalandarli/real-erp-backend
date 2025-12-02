import { getAllUserTable } from "../UI/pages/user/user.js"
import { modalAddForUser, modalUpdateForEmployee } from "./components/modals/modalTest.js"
import { getAllEmployeeAsync } from "../UI/pages/employee/employee.js"


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


//function openModal(html) {
//    document.body.insertAdjacentHTML("beforeend", html);
//}

//document.addEventListener("click", (e) => {

//    if (e.target.matches("#getAddUserModal")) {
//        console.log(modalAddForUser());

//        openModal(modalAddForUser());
//    }


//    document.body.addEventListener("click", (e) => {
//        if (e.target.classList.contains("close-btn")) {
//            e.target.closest(".modal-overlay").remove();
//        }
//    });

//    document.body.addEventListener("submit", (e) => {
//        if (e.target.id === "addUserForm") {
//            e.preventDefault();
//            const formData = new FormData(e.target);
//            console.log("Form submitted:", Object.fromEntries(formData));
//            e.target.closest(".modal-overlay").remove();
//        }
//    });
//})






    document.getElementById("userTableRender").addEventListener("click", async () => {
        content.innerHTML = await getAllUserTable();
    })

    document.getElementById("employeeTableRender").addEventListener("click", async () => {
        content.innerHTML = await getAllEmployeeAsync();
    })





//document.getElementById("getByIdEmployee").addEventListener("click", () => {

//})

document.addEventListener("click", (e) => {

    if (e.target.matches("#getUpdateEmployeModal")) {
        openModal(modalUpdateForEmployee());
    }

    if (e.target.classList.contains("close-btn")) {
        e.target.closest(".modal-overlay").remove();
    }
});


document.addEventListener("submit", (e) => {
    if (e.target.id === "updateEmployeeForm") {
        e.preventDefault();

        const name = e.target.name.value;
        const email = e.target.email.value;

        console.log("Ad:", name, "Email:", email);

        e.target.reset();

        const modal = e.target.closest(".modal-overlay");
        if (modal) modal.remove();
    }
});


content.innerHTML = await getAllUserTable()