import { Component } from "react";
import Product from './product';
import ProductsContext from './Context/productsContext'


class Products extends Component {

    constructor(props) {
        super(props)
    }

    componentWillMount() {

    }

    componentDidUpdate() {

    }

    componentWillUnmount() {

    }

    

    static contextType = ProductsContext;

    render() {
        //const { ProductsData } = this.state;
        //const { ondeleteItem, onresetCount, onincreament, ondecreament, ProductsData } = this.props;
        return (
            <>
                <button className='btn btn-primary' onClick={this.context.onresetCount}>Reset</button>
                {
                    this.context.ProductsData.map(
                        (item, index) => (
                            <Product Id={item.Id}
                                productName={item.productName} count={item.count} key={item.Id}>
                                this is children test
                            </Product>
                        ))
                }
            </>
        );
    }

}


export default Products;




//<Product Id={item.Id} onDelete={this.context.ondeleteItem}
//    increament={onincreament} decreament={this.context.ondecreament}
//    productName={item.productName} count={item.count} key={item.Id}>
//    this is children test
//</Product>