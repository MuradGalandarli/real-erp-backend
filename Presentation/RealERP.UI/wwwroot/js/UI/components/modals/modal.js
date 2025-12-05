

//[Required(ErrorMessage = "User Name is required")]
//        public string ? Username { get; set; }
//[EmailAddress]
//[Required(ErrorMessage = "Email is required")]
//        public string ? Email { get; set; }
//[Required(ErrorMessage = "Password is required")]
//        public string ? Password { get; set; }
//        public string Name { get; set; }
export function modalForUser() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Add User</h2>
            <form id="addUserForm">
            <input type="hidden" Id="userFromMode" value="addUser"

                <label>Name:</label>
                <input type="text" id="surName" name="surname" required />

                 <label>Surname:</label>
                <input type="text" id="name" name="name" required />

                <label>Email:</label>
                <input type="email" id="email" name="email" required />

                 <label>Password:</label>
                <input type="password" id="password" name="Password" required />

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

               <div id="show" style="display:block;">
    <label style="display:block">UserId:</label>
    <input type="text" id="userId" name="userId" style="width:335px;" />
</div>


                <button type="submit" id="submit-btn">Save</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`
}
