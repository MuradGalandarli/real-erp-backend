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
        name: document.getElementById("name").value,
        email: document.getElementById("email").value,
        address: document.getElementById("address").value,
        phone: document.getElementById("phone").value,
        country: document.getElementById("country").value,
        city: document.getElementById("city").value
    }
    await fetchCompany.add(companyDto);
}

export async function getByIdCompany(id) {

    const company = await fetchCompany.getById(id);

    document.getElementById("name").value = company.company.name,
        document.getElementById("email").value = company.company.email,
        document.getElementById("address").value = company.company.address,
        document.getElementById("phone").value = company.company.phone,
        document.getElementById("country").value = company.company.country,
        document.getElementById("city").value = company.company.city
    document.querySelector("#submit-btn").dataset.id = id;
}

export async function updateCompany(id) {

   
    let company = {
        id :id,
        name: document.getElementById("name").value,
        email: document.getElementById("email").value,
        address: document.getElementById("address").value,
        phone: document.getElementById("phone").value,
        country: document.getElementById("country").value,
        city: document.getElementById("city").value
    }
    debugger;
     await fetchCompany.update(company);
    
}