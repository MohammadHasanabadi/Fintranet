import { useContext, useState } from 'react'
import ProductsContext from '../Context/productsContext'

const App = () => {
    const productsContext = useContext(productsContext);
    const [productsState, sePproductsState] = useState({
        ProductsData: [{ Id: '1', productName: 'laptob', count: 5 },
        { Id: '2', productName: 'Monitor', count: 3 },
        { Id: '3', productName: 'Mobile', count: 2 }]
    });


    return (
        <>
            <ProductsContext.Provider
                value={{
                    Products: productsState,
                    onresetCount: resetCount,
                    ProductsData: productsState,
                    ondeleteItem: deleteItem,
                    onincreament: increament,
                    ondecreament: decreament

                }}

            >

            </ProductsContext.Provider>

        </>
    );

    function deleteItem(itemId) {
        const newProducts = this.state.ProductsData.filter(x => x.Id !== itemId);
        this.setState({ ProductsData: newProducts });
    }

    function resetCount() {
        const newProductsData = this.state.ProductsData.map(item => {
            item.count = 0;
            return item;
        })

        this.setState({ ProductsData: newProductsData })
    }

    function increament(productId) {
        const newProducts = [...this.state.ProductsData];
        const index = newProducts.findIndex(x => x.Id === productId);
        newProducts[index].count += 1;
        this.setState({ ProductsData: newProducts });
    }

    function decreament(productId) {
        const newProducts = [...this.state.ProductsData];
        const index = newProducts.findIndex(x => x.Id === productId);
        newProducts[index].count -= 1;
        this.setState({ ProductsData: newProducts });
    }
}