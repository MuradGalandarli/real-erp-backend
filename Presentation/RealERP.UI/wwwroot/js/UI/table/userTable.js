

export async function createUserTableHeader() {
    const table = `

    <h2> User list </h2>
    <button id="getAddUserModal"> Add </button>

    <table>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
            <th>Company</th>
            <th>Update</th>
            <th>Delete</th> 
        </tr>
    `;

    return table;
}
