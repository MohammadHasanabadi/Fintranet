import { useState } from 'react'

function Product({ productName, count, children, Id, onDelete, handleIncreament, handleDecreament }) {

    //const [count, setCount] = useState(productcount);

    //const { productName } = props;

    return (
        <div>
            <span className='m-2'>{productName}</span>
            <span className='m-2' >{count}</span>
            <button className='m-2 btn btn-sm btn-success' onClick={increament}>+</button>
            <button className='m-2 btn btn-sm btn-info' onClick={descreament}>-</button>
            <button className='m-2 btn btn-sm btn-danger' onClick={() => { deleteitem('deleted') }}>delete</button>
            <p>{children}</p>
        </div>
    )

    function increament() {
        handleIncreament(Id);

    }

    function descreament() {
        handleDecreament(Id);
    }

    function deleteitem(item) {
        onDelete(Id);
    }

}



export default Product;