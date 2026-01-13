import { createCategoryTable } from "../../table/categoryTable.js"
import { fetchCategory } from "../../services/categoryService.js"
import { apiRequest } from "../../core/api.js";

export async function getAllCategory(page, size) {
    let table = createCategoryTable();
    const data = await fetchCategory.getAll(page, size);
    
    let id=0;
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
  
    const name = document.getElementById("name").value;
    const description = document.getElementById("description").value;
    const companyId = document.getElementById("company").value;
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

    document.getElementById("name").value = category.name;
    document.getElementById("description").value = category.description;
    document.getElementById("company").value = category.companyId;
    document.querySelector("#submit-btn").dataset.id = id;
}

export async function updateCategory(id) {
    const category = {
        "id": id,
        "name": document.getElementById("name").value,
        "description": document.getElementById("description").value,
        "companyId": document.getElementById("company").value
    }
    await fetchCategory.update(category);
}


