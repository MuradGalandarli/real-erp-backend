import { fetchBrand } from "../../services/brandService.js"
import { fetchWarehouse } from "../../services/warehouseService.js";
import { brandTable } from "../../table/brandTable.js"

export async function getAllBrand(page, size) {

    const brands = await fetchBrand.getAll(page, size); 
    console.log(brands)
    let table = brandTable();
    let id = 0;
    brands.forEach(brand => {
        table += `
        <tr>
        <td>${++id}</td>
        <td>${brand.brandName}</td>
        <td>${brand.companyId}</td>
         <td><button data-id=${brand.id} class="update-btn" id="getUpdateBrandModal">Update</button></td>
        <td><button data-id=${brand.id} id="deleteBrand" class="delete-btn" >Delete</button></td>
        </tr>
        `
    })

    table += `</table>`
    return table
}

export async function addBrandAsync() {

    let brand = {
        brandName: document.getElementById("name").value,
        companyId: document.getElementById("company").value
    }
    await fetchBrand.add(brand);
}
export async function getByIdBrandAsync(id) {
    const brand = await fetchBrand.getById(id);
    document.getElementById("name").value = brand.brandName;
    document.getElementById("company").value = brand.companyId;
    document.querySelector("#submit-btn").dataset.id = id;
}

export async function updateBrand() {

    const brand = {
        id: document.querySelector("#submit-btn").dataset.id,
        brandName: document.getElementById("name").value,
        companyId: document.getElementById("company").value
    }

    await fetchBrand.update(brand);
}
export async function deleteBrand(id) {
    await fetchBrand.delete(id);
}

