export function modalAddForUser() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Add User</h2>
            <form id="addUserForm">
                <label>Name:</label>
                <input type="text" name="name" required />

                <label>Email:</label>
                <input type="email" name="email" required />

                <button type="submit" id="submit-btn">Add</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`;
}

export function modalUpdateForEmployee() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Employee</h2>
            <form id="employeeForm">
            <input type="hidden" id="formMode" value="add">

                <label>Full name:</label>
                <input type="text" id="fullName" name="fullName" required />

                <label>Position:</label>
                <input type="text" id="position" name="position" required />

                <label>DepartmentId:</label>
                <input type="text" id="departmentId" name="departmentId" required />

                <div id="show" style="display:block;"readonly>
                <label style="display:block" >UserId:</label>
                <input type="text" id="userId" name="userId" style="width:335px;" />
                </div>

                <button type="submit" id="submit-btn">Save</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`
}
