import { createCategoryTable } from "../../table/categoryTable.js"
import { fetchCategory } from "../../services/categoryService.js"

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
        <td><button  class="update-btn">Update</button></td>
        <td><button class="delete-btn">Delete</button></td>
        </tr>
        `
    })

    return table += `</table>`
}

export async function addCategory() {
    debugger;
    const name = document.getElementById("name").value;
    const description = document.getElementById("description").value;
    let category = {
        "name": name,
        "description": description
    };
    await fetchCategory.add(category);
}
