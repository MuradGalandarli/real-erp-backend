import { getNavbar } from "../components/navbar/navbar.js"

export async function createUserTableHeader() {
    const table = `

    <h2> User list </h2>
    <button id="getModal"> Add </button>

    <table border="1" width="100%">
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Update</th>
            <th>Delete</th> 
        </tr>
    `;

    return table;
}
