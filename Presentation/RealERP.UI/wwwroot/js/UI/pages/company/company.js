import { fetchCompany } from "../../services/companyService.js"
import { createCompanyTable } from "../../table/companyTable.js"

export async function getAllCompany(page, size) {
    const companies = await fetchCompany.getAll(page, size)
    console.log(companies)
    let table = createCompanyTable();
    let id = 0;
    console.log(companies.companyDto)
    companies.companyDto.forEach(x => {
        table += `
         <tr>
         <td> ${++id} </td>
         <td>${x.name}</td>
         <td>${x.email}</td>
         <td>${x.address}</td>
         <td>${x.phone}  </td>
         <td>${x.country}  </td>
         <td>${x.city}  </td>
         <td><button data-id="${x.id}"id="getCompanyModal" class="update-btn">Update</button></td>
         <td><button data-id="${x.id}" id="deleteCompany" class="delete-btn">Sil</button></td>
         </tr>
        `

    })
    table += `</table>`
    return table;
}

export async function addCompany() {

    let companyDto = {
        name: $("#name").val(),
        email: $("#email").val(),
        address: $("#address").val(),
        phone: $("#phone").val(),
        country: $("#country").val(),
        city: $("#city").val()
    }
    debugger;

    await fetchCompany.add(companyDto);
}

export async function getByIdCompany(id) {

    const company = await fetchCompany.getById(id);

    $("#name").val(company.company.name),
        $("#email").val(company.company.email),
        $("#address").val(company.company.address),
        $("#phone").val(company.company.phone),
        $("#country").val(company.company.country),
        $("#city").val(company.company.city)
    document.querySelector("#submit-btn").dataset.id = id;
}

export async function updateCompany(id) {

    let company = {
        id: id,
        name: $("#name").val(),
        email: $("#email").val(),
        address: $("#address").val(),
        phone: $("#phone").val(),
        country: $("#country").val(),
        city: $("#city").val()
    }
    await fetchCompany.update(company);
}

export async function deleteCompanyAsync(id) {
    await fetchCompany.delete(id);
}