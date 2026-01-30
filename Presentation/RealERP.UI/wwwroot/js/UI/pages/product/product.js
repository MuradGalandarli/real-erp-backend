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