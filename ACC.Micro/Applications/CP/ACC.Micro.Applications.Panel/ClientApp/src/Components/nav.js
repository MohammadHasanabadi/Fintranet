import React from 'react'

//import {
//    AppBar,
//    Toolbar,
//    CssBaseline,
//    Typography,
//    makeStyles,
//} from "@material-ui/core";
import { Link } from "react-router-dom";


const Nav = () => {

    return (
        //<AppBar position="static">
        //    <CssBaseline />
        //    <Toolbar>
        //        <Typography  >
        //            Navbar
        //        </Typography>
                <div >
                    <Link to='/home' />
                    <Link to='/about' />
                </div>
        //    </Toolbar>
        //</AppBar>

    )
}

export default Nav;