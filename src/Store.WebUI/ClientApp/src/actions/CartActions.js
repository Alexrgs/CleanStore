import { CartClient } from '../api/ApiClients';

export const ADD_TO_CART = 'ADD_TO_CART';
export const DELETE_FROM_CART = 'DELETE_FROM_CART';
export const UPDATE_ITEM_QUANTITY = 'UPDATE_ITEM_QUANTITY';
export const LOAD_CART = 'LOAD_CART';
export const CHECKOUT = 'CHECKOUT';

export function addToCart({ productId, productName, productImgURL, unitPrice, quantity=1}) {
    return {
        type: ADD_TO_CART,
        payload: { productId, productName, productImgURL, unitPrice, quantity }
    }
}
export function deleteFromCart({ productId }) {
    return {
        type: DELETE_FROM_CART,
        payload: { productId }
    }
}
export function updateItemQuantity({ productId, quantity }) {
    return {
        type: UPDATE_ITEM_QUANTITY,
        payload: { productId, quantity }
    }
}

export function checkOut({  }) {
    return {
        type: CHECKOUT,
        payload: { }
    }
}

export function loadCart(cart) {
    return {
        type: LOAD_CART,
        payload: { cart }
    }
}