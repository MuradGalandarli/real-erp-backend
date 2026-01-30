import { getAllUserTable, addUser, getByEmailUser, updateUser, deleteUserAsync } from "../UI/pages/user/user.js"
import { modalForUser, modalUpdateForEmployee, modalForDepartment, modalForCategory, modalForBrand, modalForCompany, modalForRole, modalForWarehouse } from "./components/modals/modal.js"
import { getAllEmployeeAsync, getByIdEmployeeAsync, updateEmployeeAsync, addEmployee, deleteEmployee } from "../UI/pages/employee/employee.js"
import { getAllDepartmentAsync, addDepartmentAsync, getByIdDepartment, updateDepartmentAsync, deleteDepartment } from "../UI/pages/department/department.js"
import { getAllCategory, addCategory, deleteCategory, getByIdCategory, updateCategory } from "../UI/pages/category/category.js"
import { getAllBrand, addBrandAsync, getByIdBrandAsync, updateBrand, deleteBrand } from "../UI/pages/brand/brand.js"
import { getAllCompany, addCompany, getByIdCompany, updateCompany, deleteCompanyAsync } from "../UI/pages/company/company.js"
import { getAllRole, getByIdRoleAsync, updateRoleAsync, addRoleAsync, deleteRoleAsync } from "../UI/pages/role/role.js"
import { GetAllWarehouse, getByIdWarehouseAsync, updateWarehouseAsync, addWarehouseAsync, deleteWarehouseAsync } from "../../js/UI/pages/warehouse/warehouse.js"
import { getAllProductAsync } from "../UI/pages/product/product.js"

const content = document.getElementById("Content");


function openModal(html) {
    const wrapper = document.createElement("div");
    wrapper.innerHTML = html;
    const modalEl = wrapper.firstElementChild;
    document.body.appendChild(modalEl);
}

document.getElementById("departmentTableRender").addEventListener("click", async () => {
    content.innerHTML = await getAllDepartmentAsync(1, 10);
})

document.getElementById("userTableRender").addEventListener("click", async () => {
    content.innerHTML = await getAllUserTable();
})

document.getElementById("employeeTableRender").addEventListener("click", async () => {
    content.innerHTML = await getAllEmployeeAsync();
})
document.getElementById("categoryTableRender").addEventListener("click", async () => {
    content.innerHTML = await getAllCategory(1, 10);
})
document.getElementById("brandTableRender").addEventListener("click", async () => {
    
    content.innerHTML = await getAllBrand(1, 10);
})
document.getElementById("companyTableRender").addEventListener("click", async () => {

    content.innerHTML = await getAllCompany(1, 10);
})

document.getElementById("roleTableRender").addEventListener("click", async () => {

    content.innerHTML = await getAllRole(1, 10);
})
document.getElementById("warehouseTableRender").addEventListener("click", async () => {

    content.innerHTML = await GetAllWarehouse(1, 10);
})
document.getElementById("productTableRender").addEventListener("click", async () => {

    content.innerHTML = await getAllProductAsync(1, 10);
})

document.addEventListener("click", async (e) => {
    const id = e.target.dataset.userId;
    const email = e.target.dataset.email

    if (e.target.matches("#deleteWarehouse")) {
        await deleteWarehouseAsync(e.target.dataset.id);
        content.innerHTML = await GetAllWarehouse(1, 10);
    }

    if (e.target.matches("#getUpdateWarehouseModal")) {
        openModal(modalForWarehouse())
        await getByIdWarehouseAsync(e.target.dataset.id);
        document.getElementById("formMode").value = "update";
    }

    if (e.target.matches("#deleteRole")) {
        await deleteRoleAsync(e.target.dataset.id);
        content.innerHTML = await getAllRole(1, 10);
    }

    if (e.target.matches("#addWarehouse")) {
        openModal(modalForWarehouse())
    }
    if (e.target.matches("#getRoleModal")) {
        openModal(modalForRole())
        await getByIdRoleAsync(e.target.dataset.id);
        document.getElementById("formMode").value = "update";
    }
    if (e.target.matches("#addRole")) {
        openModal(modalForRole())
    }

    if (e.target.matches("#deleteCompany")) {
        await deleteCompanyAsync(e.target.dataset.id)
        content.innerHTML = await getAllCompany(1, 10);
    }

    if (e.target.matches("#deleteBrand")) {
        debugger;
        await deleteBrand(e.target.dataset.id)
        content.innerHTML = await getAllBrand(1, 10);
    }


    if (e.target.matches("#getCompanyModal")) {
        openModal(modalForCompany())
        await getByIdCompany(e.target.dataset.id);
        document.getElementById("formMode").value = "update";
    }

    if (e.target.matches("#getAddCompanyModal")) {
        openModal(modalForCompany())
    }

    if (e.target.matches("#addBrnad")) {
        openModal(modalForBrand())
    }
    if (e.target.matches("#getUpdateBrandModal")) {
        openModal(modalForBrand())
        document.getElementById("formMode").value = "update";
        await getByIdBrandAsync(e.target.dataset.id)
    }

    if (e.target.matches("#deleteCategory")) {
        const id = e.target.dataset.id;

        await deleteCategory(id);
        content.innerHTML = await getAllCategory(1, 10);
    }

    if (e.target.matches("#addCategory")) {

        openModal(modalForCategory())
    }
    if (e.target.matches("#updateCategory")) {
        const id = e.target.dataset.id;
        openModal(modalForCategory())
        document.getElementById("formMode").value = "update";
        await getByIdCategory(id);
    }

    if (e.target.matches("#deleteUser")) {
        await deleteUserAsync(email);
        content.innerHTML = await getAllUserTable();
    }

    if (e.target.matches("#deleteDepartment")) {

        const id = e.target.dataset.id;
        await deleteDepartment(id)
        content.innerHTML = await getAllDepartmentAsync(1,10)
    }

    if (e.target.matches("#getAddDepartmentModal")) {

        openModal(modalForDepartment());

    }
    if (e.target.matches("#getUpdateDepartmentModal")) {
        openModal(modalForDepartment());
        document.getElementById("formMode").value = "update";
        const id = e.target.dataset.id;
        await getByIdDepartment(id);
    }

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
    if (e.target.matches("#deleteEmployee")) {
        const id = e.target.dataset.id;
        await deleteEmployee(id);
        content.innerHTML = await getAllEmployeeAsync();
    }

    if (e.target.matches("#getAddUserModal")) {

        openModal(modalForUser());
        const showDiv = document.getElementById("show");
        if (showDiv) {
            showDiv.style.display = "block";
        }

    }
    if (e.target.matches("#getUpdateUserModal")) {

        openModal(modalForUser());
        await getByEmailUser(email)
        document.getElementById("formMode").value = "userUpdate";
    }
   
    if (e.target.classList.contains("close-btn")) {
        e.target.closest(".modal-overlay").remove();
    }
});


document.addEventListener("submit", async (e) => {

    e.preventDefault();

    const mode = document.getElementById("formMode").value;

    if (e.target.matches("#warehouseForm")) {
        if (mode == "update") {
            await updateWarehouseAsync();
            content.innerHTML = await GetAllWarehouse(1, 10);
        }
        else {
            debugger;
            await addWarehouseAsync();
            content.innerHTML = await GetAllWarehouse(1, 10);
        }
            
    }

    if (e.target.matches("#roleForm")) {
        if (mode == "update") {
            await updateRoleAsync();
            content.innerHTML = await getAllRole(1, 10);
        }
        else {
            await addRoleAsync();
            content.innerHTML = await getAllRole(1, 10);
        }
    }

    if (e.target.matches("#companyForm")) {
        if (mode == "add") {
            await addCompany();
            content.innerHTML = await getAllCompany(1, 10);
        }
        else {
            const id = document.querySelector("#submit-btn").dataset.id
            await updateCompany(id);
            content.innerHTML = await getAllCompany(1, 10);
        }
    }


    if (e.target.matches("#brandForm")) {
        if (mode == "add") {
            await addBrandAsync();
            content.innerHTML = await getAllBrand(1,10);
        }
        if (mode == "update") {
            await updateBrand();
            content.innerHTML = await getAllBrand(1, 10);

        }
    }

    if (e.target.id == "categoryForm") {
        if (mode == "add") {
            await addCategory();
            content.innerHTML = await getAllCategory(1, 10);
        }
        else {
            
            const id = document.querySelector("#submit-btn").dataset.id
            await updateCategory(id);
            content.innerHTML = await getAllCategory(1, 10)
        }
    }


    if (e.target.id == "departmentForm") {

        if (mode == "add") {

            await addDepartmentAsync();

        }
        else {

            const id = document.querySelector("#submit-btn").dataset.id
            await updateDepartmentAsync(id)
        }
        content.innerHTML = await getAllDepartmentAsync(1, 10);
    }


    if (e.target.id == "employeeForm") {

        if (mode == "update") {
            const id = document.querySelector("#submit-btn").dataset.employeeid;
            await updateEmployeeAsync(id);
        }
        
        if (mode == "add") {

            await addEmployee();

        }
        content.innerHTML = await getAllEmployeeAsync();
    }


    if (e.target.id == "userForm") {
        const userMode = document.getElementById("formMode").value
        if (userMode == "addUser") {
           
            await addUser();
            content.innerHTML = await getAllUserTable()
        }
        if (userMode == "userUpdate") {
            const id = document.querySelector("#submit-btn").dataset.userid
            await updateUser(id);
            content.innerHTML = await getAllUserTable()
        }

    }

    e.target.reset();

    const modal = e.target.closest(".modal-overlay");
    if (modal) modal.remove();

});



content.innerHTML = await getAllUserTable()