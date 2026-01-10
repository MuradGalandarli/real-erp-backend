

export function modalForUser() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>User</h2>
            <form id="userForm">
            <input type="hidden" Id="userFromMode" value="addUser"

                <label>Name:</label>
                <input type="text" id="surName" name="surname" required />

                 <label>Surname:</label>
                <input type="text" id="name" name="name" required />


                 <div id="show" style="display:none;">
    <label>Email:</label>
    <input type="email" id="email" name="email" style="width:335px;" />

    <label>Password:</label>
    <input type="password" id="password" name="password" style="width:335px;" />
</div>


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


export function modalForDepartment() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Department</h2>
            <form id="departmentForm">
            <input type="hidden" id="formMode" value="add">

                <label>Name:</label>
                <input type="text" id="name" name="name" required />

                <button type="submit" id="submit-btn">Save</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`
}

export function modalForCategory() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Category</h2>
            <form id="categoryForm">
            <input type="hidden" id="formMode" value="add">

                <label>Name:</label>
                <input type="text" id="name" name="name" required />
                 <label>Description:</label>
                <input type="text" id="description" name="description" required />

                <button type="submit" id="submit-btn">Save</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`
}


export function modalForBrand() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Brand</h2>
            <form id="brandForm">
            <input type="hidden" id="formMode" value="add">

                <label>Name:</label>
                <input type="text" id="name" name="name" required />
              
                <button type="submit" id="submit-btn">Save</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`
}
export function modalForCompany() {
    return `
    <div class="modal-overlay">
        <div class="modal">
            <h2>Company</h2>
            <form id="companyForm">
            <input type="hidden" id="formMode" value="add">

                <label>Name:</label>
                <input type="text" id="name" name="name" required />

                 <label>Email:</label>
                <input type="text" id="email" name="email" required />

                 <label>Address:</label>
                <input type="text" id="address" name="address" required />

                 <label>Phone:</label>
                <input type="text" id="phone" name="phone" required />

                 <label>Country:</label>
                <input type="text" id="country" name="country" required />

                 <label>City:</label>
                <input type="text" id="city" name="city" required />
              
                <button type="submit" id="submit-btn">Save</button>
            </form>
            <button class="close-btn">X</button>
        </div>
    </div>`
}
