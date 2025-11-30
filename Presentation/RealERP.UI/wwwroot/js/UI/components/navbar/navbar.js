

export function getNavbar() {
    const nav = `
    <nav class="navbar">
        <div class="logo">
            <a href="/">
                <img src="https://media.geeksforgeeks.org/wp-content/cdn-uploads/gfg_200x200-min.png"
                    alt="gfg_logo">
            </a>
        </div>
        <div class="menu">
            <span class="line"></span>
            <span class="line"></span>
            <span class="line"></span>
        </div>
        <div class="nav-menu hide">
            <a href="#" id="userTableRender">User</a>
            <a href="#" id="employeeTableRender">Employee</a>
            <a href="#">About</a>
            <a href="#">Contact</a>
        </div>
    </nav>`
    return nav;
}