import { Component } from 'react';
import ProductsContext from './Context/productsContext'


function according() {
    return <>
        <div class="accordion" id="accordionExample">
            <div class="accordion-item">
                <h2 class="accordion-header" id="headingOne">
                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                        Accordion Item #1
                    </button>
                </h2>
                <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        <strong>This is the first item's accordion body.</strong> It is shown by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header" id="headingTwo">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                        Accordion Item #2
                    </button>
                </h2>
                <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        <strong>This is the second item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header" id="headingThree">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                        Accordion Item #3
                    </button>
                </h2>
                <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        <strong>This is the third item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                    </div>
                </div>
            </div>
        </div>
    </>
}

class Product extends Component {
    imageUrl = 'https://picsum.photos/200';
    static contextType = ProductsContext;

    //state = {
    //    count: this.props.count,
    //    data: null
    //}

    render() {
        const { productName } = this.props;

        return (
            <div>
                <span className='m-2'>{productName}</span>
                <span >{this.props.count}</span>
                <button className='m-2 btn btn-sm btn-success' onClick={this.increament.bind(this)}>+</button>
                <button className='m-2 btn btn-sm btn-info' onClick={this.descreament.bind(this)}>-</button>
                <button className='m-2 btn btn-sm btn-danger' onClick={() => this.delete('deleted')}>delete</button>
                <img src={this.imageUrl} style={{ borderRadius: '50%' }} />
                <p>{this.props.children}</p>

            </div>
        );
    }

    increament() {
        //this.props.increament(this.props.Id)
        this.context.onincreament(this.props.Id)
    }

    descreament() {
        //this.props.decreament(this.props.Id)
        this.context.ondecreament(this.props.Id)


    }

    delete(item) {
        //this.props.onDelete(this.props.Id);
        this.context.ondeleteItem(this.props.Id);

    }



}

export default Product;





//return (
//    <div>
//        <span className='m-2'>{productName}</span>
//        <span >{this.props.count}</span>
//        <button className='m-2 btn btn-sm btn-success' onClick={this.increament.bind(this)}>+</button>
//        <button className='m-2 btn btn-sm btn-info' onClick={this.descreament.bind(this)}>-</button>
//        <button className='m-2 btn btn-sm btn-danger' onClick={() => this.delete('deleted')}>delete</button>
//        <img src={this.imageUrl} style={{ borderRadius: '50%' }} />
//        <p>{this.props.children}</p>

//    </div>
//);