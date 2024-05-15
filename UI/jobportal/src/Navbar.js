import { Link} from "react-router-dom"
export default function Navbar() {
    return (
        <nav className="nav">
            <CustomLink to="/MainPage" className="site-titile">
            Job Portal
            </CustomLink>
            <ul>
               
                <CustomLink to="/Whyus">Why Us</CustomLink>
                <CustomLink to="/Publish">Publish</CustomLink>
                <CustomLink to="/Contactus">Contact Us</CustomLink>

           
                
               
            </ul>
            <CustomLink to="/Profile" className="site-profile">
            Profile
            </CustomLink>
        </nav>
    )
}

function CustomLink({ to, childrem, ...props}){
    const path = window.location.pathname

    return (
        <li className={path == to ? "active" : ""}>
            <Link to={to} {...props}>

            </Link>
        </li>
    )
}