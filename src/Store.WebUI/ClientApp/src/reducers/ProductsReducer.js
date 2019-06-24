import { LOAD_PRODUCTS , loadProducts} from '../actions/ProductsActions';

const INIT_PRODUCTS = [
    {
     productId: 1, productName: 'Keyborad', productDescription: 'Some awesome keyboard', productImgURL: './mockImg/keyboard.jpg' ,  unitPrice: 30 }
];
export default function productsReducer(state = INIT_PRODUCTS, action = {}) {
   
    switch (action.type) {
        case LOAD_PRODUCTS:
            return action.payload.products;
            
    }

    function findProductIndex(products, id) {
        return products.findIndex((p) => p.id === id)
    }

    return state;
}

