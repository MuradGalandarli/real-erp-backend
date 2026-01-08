import { fetchCompany } from "../../services/companyService.js"
import { createCompanyTable } from "../../table/companyTable.js"

export async function getAllCompany(page, size) {
    const companies = await fetchCompany.getAll(page, size)
    console.log(companies)
    let table = createCompanyTable();
    let id = 0;
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
         </tr>
        `
        
    })
    table += `</table>`
    return table;

}