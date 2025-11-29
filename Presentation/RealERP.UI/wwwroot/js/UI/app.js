import { getAllUserTable, closeModal } from "../UI/pages/user/user.js"
import { modalUser } from "../UI/components/modals/addUserModal.js"

const content = document.getElementById("Content");


function openModal(html) {
    content.insertAdjacentHTML("beforeend", html);
}


// EVENT DELEGATION
document.addEventListener("click", (e) => {

    if (e.target.matches("#getModal")) {
        console.log("Modal worked")
        openModal(modalUser());
    }

    // Modal bağla
    if (e.target.classList.contains("close-btn")) {
        e.target.closest(".modal-overlay").remove();
    }
});

// Submit event delegation
document.addEventListener("submit", (e) => {
    if (e.target.id === "addUserForm") {
        e.preventDefault();

        const name = e.target.name.value;
        const email = e.target.email.value;

        console.log("Ad:", name, "Email:", email);

        // Reset
        e.target.reset();

        // Modalı bağla
        const modal = e.target.closest(".modal-overlay");
        if (modal) modal.remove();
    }
});




    content.innerHTML = await getAllUserTable()

