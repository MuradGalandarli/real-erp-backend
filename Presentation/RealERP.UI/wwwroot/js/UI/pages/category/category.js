import { createCategoryTable } from "../../table/categoryTable.js"
import { fetchCategory } from "../../services/categoryService.js"
import { apiRequest } from "../../core/api.js";

export async function getAllCategory(page, size) {
    let table = createCategoryTable();
    const data = await fetchCategory.getAll(page, size);

    let id = 0;
    data.forEach(category => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${category.name}</td>
        <td>${category.description}</td>
        <td>${category.companyId}</td>
        <td><button  class="update-btn" data-id="${category.id}" id="updateCategory">Update</button></td>
        <td><button class="delete-btn" data-id="${category.id}" id="deleteCategory">Delete</button></td>
        </tr>
        `
    })

    return table += `</table>`
}

export async function addCategory() {

    const name = $("#name").val();
    const description = $("#description").val();
    const companyId = $("#company").val();
    let category = {
        "name": name,
        "description": description,
        "companyId": companyId

    };
    await fetchCategory.add(category);
}

export async function deleteCategory(id) {

    await fetchCategory.delete(id);
}

export async function getByIdCategory(id) {
    const category = await fetchCategory.getById(id);

    $("#name").val(category.name);
    $("#description").val(category.description);
    $("#company").val(category.companyId);
    $("#submit-btn").data("id", id);
}

export async function updateCategory(id) {
    const category = {
        "id": id,
        "name": $("#name").val(),
        "description": $("#description").val(),
        "companyId": $("#company").val()
    }
    await fetchCategory.update(category);
}


