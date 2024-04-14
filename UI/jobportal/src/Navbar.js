import { Link} from "react-router-dom"
export default function Navbar() {
    return (
        <nav className="nav">
            <CustomLink to="/home" className="site-titile">
            Job Portal
            </CustomLink>
            <ul>
               
                <CustomLink to="/whyus">Why Us</CustomLink>
                <CustomLink to="/publish">Publish</CustomLink>
                <CustomLink to="/contactus">Contact Us</CustomLink>
               
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