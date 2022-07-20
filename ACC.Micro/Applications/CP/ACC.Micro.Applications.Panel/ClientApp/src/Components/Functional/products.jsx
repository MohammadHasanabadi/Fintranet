import Product from './product'
import { useState, useContext } from 'react'
import ProductsContext from '../Context/productsContext'


const Products = () => {

    //const [productsdata, setProductData] = useState(
    //    [{ Id: '1', productName: 'laptob', count: 5 },
    //    { Id: '2', productName: 'Monitor', count: 3 },
    //    { Id: '3', productName: 'Mobile', count: 2 }]
    //);

    const productsContext = useContext(ProductsContext);


    return (
        <>
            <button className='btn btn-primary' onClick={resetCount}>Reset</button>
            {
                productsdata.map(
                    (item) => (
                        <Product Id={item.Id}  productName={item.productName}
                            count={item.count} key={item.Id}>
                            this is test
                        </Product>
                    ))
            }

        </>
    );

    function deleteItem(itemId) {
        const newProducts = productsdata.filter(item => item.Id !== itemId);
        setProductData(newProducts);


    }

    function resetCount() {
        const newProducts = productsdata.map((item) => {
            item.count = 0;
            return item;
        });
        setProductData(newProducts);
    }

    function handleIncreament(itemId) {
        const newProducts = [...productsdata];
        const index = newProducts.findIndex(x => x.Id === itemId);
        newProducts[index].count += 1;
        setProductData(newProducts);
    }

    function handleDecreament(itemId) {
        const newProducts = [...productsdata];
        const index = newProducts.findIndex(x => x.Id === itemId);
        newProducts[index].count -= 1;
        setProductData(newProducts);
    }
}

export default Products;





//return (
//    <>
//        <button className='btn btn-primary' onClick={resetCount}>Reset</button>
//        {
//            productsdata.map(
//                (item) => (
//                    <Product Id={item.Id} onDelete={deleteItem} productName={item.productName}
//                        handleIncreament={handleIncreament} handleDecreament={handleDecreament}
//                        count={item.count} key={item.Id}>
//                        this is test
//                    </Product>
//                ))
//        }

//    </>
//);