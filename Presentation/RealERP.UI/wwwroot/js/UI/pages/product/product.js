import { apiRequest } from "../../core/api.js";
import { fetchProduct } from "../../services/productService.js"
import { createProductTable } from "../../table/productTable.js"

export async function getAllProductAsync(page,size) {

    const products = await fetchProduct.getAll(page, size)
    let table = createProductTable();
    let id = 0;
    products.forEach((product) => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${product.name}</td>
        <td>${product.description}</td>
        <td>${product.categoryId}</td>
        <td>${product.brandId}</td>
        <td>${product.companyId}</td>
        <td><button data-id=${product.id} class="update-btn" id="getUpdateProductModal">Update</button></td>
        <td><button data-id=${product.id} id="deleteProduct" class="delete-btn">Delete</button></td>
        </tr>
        `
    })

    table += `</table>`
    return table;

}

export async function getByIdProductAsync(id) {

    const product = await fetchProduct.getById(id);

    document.getElementById("name").value = product.name
    document.getElementById("description").value = product.description
    document.getElementById("category").value = product.categoryId
    document.getElementById("company").value = product.companyId
    document.getElementById("brand").value = product.brandId
    document.querySelector("#submit-btn").value = id;
}

export async function updateProductAsync() {
    let product = {
        name: document.getElementById("name").value,
        description: document.getElementById("description").value,
        categoryId: document.getElementById("category").value,
        companyId: document.getElementById("company").value,
        brandId: document.getElementById("brand").value,
        id: document.querySelector("#submit-btn").value
    }
    await fetchProduct.update(product);
}
export async function addProductAsync() {
    debugger;
    let product = {
        name: document.getElementById("name").value,
        description: document.getElementById("description").value,
        categoryId: document.getElementById("category").value,
        companyId: document.getElementById("company").value,
        brandId: document.getElementById("brand").value,   
    }
    await fetchProduct.add(product);
}
export async function deleteProductAsync(id) {
    await fetchProduct.delete(id);
}
