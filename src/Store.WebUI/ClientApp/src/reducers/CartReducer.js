import { ADD_TO_CART, DELETE_FROM_CART, UPDATE_ITEM_QUANTITY, LOAD_CART } from '../actions/CartActions';
import { CartClient } from '../api/ApiClients';

export default function cartReducer(state = [], action = {}) {
    switch (action.type) {
        case ADD_TO_CART:
            let existingIndex = findProductIndex(state, action.payload.productId);
            new CartClient().add(action.payload.productId);
            if (existingIndex !== -1) {
                state[existingIndex].units += 1;
                return state.concat([]);
            }
            return state.concat(action.payload);

        case UPDATE_ITEM_QUANTITY:
            let existingItemIndex = findProductIndex(state, action.payload.productId);
            if (state[existingItemIndex].quantity === 0 && action.payload.quantity === -1) {
                break;
            }
            state[existingItemIndex].quantity += action.payload.quantity;
            new CartClient().adjustQuantity(action.payload.productId, state[existingItemIndex].quantity);
            return state.concat([]);

        case DELETE_FROM_CART:
            let indexToDel = findProductIndex(state, action.payload.productId);
            new CartClient().remove(action.payload.productId);
            return [...state.slice(0, indexToDel), ...state.slice(indexToDel + 1)];
        case LOAD_CART:
            let temp = '';
            return action.payload.cart;
    }

    function findProductIndex(products, productId) {
        return products.findIndex((p) => p.productId === productId)
    }

    return state;
}