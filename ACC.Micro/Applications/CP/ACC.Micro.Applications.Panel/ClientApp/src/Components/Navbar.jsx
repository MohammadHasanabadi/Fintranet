import { Component } from "react";
import Nav from "./nav";
import ProductsContext from './Context/productsContext'


class Navbar extends Component {

    static contextType = ProductsContext;


    render() {

        return (
            <>
                <nav className='navbar navbar-light bg-light'>
                    <div className='container-fluid'>
                        Navbar {this.calculateCount()}
                    </div>
                </nav>

            </>
        );
    }

    calculateCount =()=> {
        let count = 0;
        this.context.Products.map((item) => {
            count += item.count;
        })
        return count;
    }

}

export default Navbar;