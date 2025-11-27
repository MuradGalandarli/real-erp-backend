export async function createUserTableHeader() {

    //const content = document.getElementById("Content");
    //content.innerHTML = "";

    const table = `
    <table border="1" width="100%">
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Update</th>
            <th>Delete</th>
            
        </tr>
    `;

    //content.innerHTML = table;
    return table;
}
