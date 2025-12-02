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

export function modalUpdateForEmployee()
{
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Add User</h2>
            <form id="updateEmployeeForm">
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