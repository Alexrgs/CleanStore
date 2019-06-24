export const ADD_TO_CART = 'ADD_TO_CART';
export const DELETE_FROM_CART = 'DELETE_FROM_CART';
export const UPDATE_ITEM_UNITS = 'UPDATE_ITEM_UNITS';
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
export function updateItemUnits({ productId, quantity }) {
    return {
        type: UPDATE_ITEM_UNITS,
        payload: { productId, quantity }
    }
}

export function checkOut({  }) {
    return {
        type: CHECKOUT,
        payload: { }
    }
}