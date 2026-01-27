import { fetchWarehouse } from "../../services/warehouseService.js"
import { createWarehouseTable } from "../../table/warehouseTable.js"

export async function GetAllWarehouse(page, size) {
    
    
    let varehouses = await fetchWarehouse.getAll(page, size);
    let table = createWarehouseTable();
    let id = 0;
    varehouses.forEach(warehouse => {
        table +=
        `
        <tr>
        <td>${++id}</td>
        <td>${warehouse.name}</td>
        <td>${warehouse.description}</td>
        <td>${warehouse.location}</td>
        <td>${warehouse.companyId}</td>
        <td><button data-id=${warehouse.id} class="update-btn" id="getUpdateWarehouseModal">Update</button></td>
        <td><button data-id=${warehouse.id} id="deleteBrand" class="delete-btn" >Delete</button></td>
        </tr>
        `
    })
    table += `</table>`
    return table;
}

export async function getByIdWarehouseAsync(id) {
    const warehouse = await fetchWarehouse.getbyId(id);
    document.getElementById("name").value = warehouse.name
    document.getElementById("description").value = warehouse.description
    document.getElementById("location").value = warehouse.location
    document.getElementById("company").value = warehouse.companyId
    document.querySelector("#submit-btn").value = id;
}

export async function updateWarehouseAsync() {

    debugger;
    let warehouse =
    {
        id: document.querySelector("#submit-btn").value,
        name: document.getElementById("name").value,
        description: document.getElementById("description").value = warehouse.description,
        location: document.getElementById("location").value,
        companyId: document.getElementById("company").value
    }
    await fetchWarehouse.update(warehouse);
}
