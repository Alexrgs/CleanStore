import { ProductsClient } from '../api/ApiClients';

export const ADD_PRODUCT = 'ADD_PRODUCT';
export const UPDATE_PRODUCT = 'UPDATE_PRODUCT';
export const LOAD_PRODUCTS = 'LOAD_PRODUCTS';

export function addProduct({ productId, productName, productImgURL, unitPrice }) {
    return {
        type: ADD_PRODUCT,
        payload: { productId, productName, productImgURL, unitPrice }
    }
}
export function updateProduct({ productId, productName }) {
    return {
        type: UPDATE_PRODUCT,
        payload: { productId, productName }
    }
}

export function loadProducts(products) {
    return {
        type: LOAD_PRODUCTS,
        payload: { products }
    }
}

export const getAllProducts = () => dispatch => {
    new ProductsClient().getAll().then(p => {
        dispatch(loadProducts(p.products));
    });
}