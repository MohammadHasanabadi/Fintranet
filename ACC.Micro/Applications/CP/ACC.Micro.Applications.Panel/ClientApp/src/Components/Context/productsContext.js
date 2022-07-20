import { createContext } from 'react'

const ProductsContext = createContext(
    {
        Products: [],
        ProductsData: [],
        ondeleteItem: () => { },
        onresetCount: () => { },
        onincreament: () => { },
        ondecreament: () => { }
    }
);

export default ProductsContext;