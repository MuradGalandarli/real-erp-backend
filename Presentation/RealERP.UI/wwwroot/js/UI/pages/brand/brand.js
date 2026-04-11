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
        brandName: $("#name").val(),
        companyId: $("#company").val()
    }

    await fetchBrand.add(brand);
}
export async function getByIdBrandAsync(id) {

    const brand = await fetchBrand.getById(id);
    $("#name").val(brand.brandName);
    $("#company").val(brand.companyId);
    $("#submit-btn").data("id", id);
    $("#submit-btn").data("id", id);
    $("#submit-btn").data("id", id);
}

export async function updateBrand() {

    const brand = {
        id: $("#submit-btn").data("id"),
        brandName: $("#name").val(),
        companyId: $("#company").val()
    }

    await fetchBrand.update(brand);
}
export async function deleteBrand(id) {
    await fetchBrand.delete(id);
}

