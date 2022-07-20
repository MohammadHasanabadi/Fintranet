import { Component } from 'react'
import React from 'react'
import Navbar from './Components/Navbar';
import Products from './Components/products'
import ProductsContext from './Components/Context/productsContext'

class App extends Component {

    state = {
        ProductsData: [{ Id: '1', productName: 'laptob', count: 5 },
        { Id: '2', productName: 'Monitor', count: 3 },
        { Id: '3', productName: 'Mobile', count: 2 }]
    };

    static contextType = ProductsContext;


    render() {
        return (
            <ProductsContext.Provider
                value={{
                    Products: this.state.ProductsData,
                    onresetCount: this.resetCount,
                    ProductsData: this.state.ProductsData,
                    ondeleteItem: this.deleteItem,
                    onincreament: this.increament,
                    ondecreament: this.decreament
                }}

            >
                <Navbar />
                <Products />
            </ProductsContext.Provider >
        );
    }


    deleteItem = (itemId) => {
        const newProducts = this.state.ProductsData.filter(x => x.Id !== itemId);
        this.setState({ ProductsData: newProducts });
    }

    resetCount = () => {
        const newProductsData = this.state.ProductsData.map(item => {
            item.count = 0;
            return item;
        })

        this.setState({ ProductsData: newProductsData })
    }

    increament = (productId) => {
        const newProducts = [...this.state.ProductsData];
        const index = newProducts.findIndex(x => x.Id === productId);
        newProducts[index].count += 1;
        this.setState({ ProductsData: newProducts });
    }

    decreament = (productId) => {
        const newProducts = [...this.state.ProductsData];
        const index = newProducts.findIndex(x => x.Id === productId);
        newProducts[index].count -= 1;
        this.setState({ ProductsData: newProducts });
    }
}

export default App;