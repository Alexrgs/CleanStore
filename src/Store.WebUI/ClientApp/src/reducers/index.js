import { combineReducers } from 'redux';
import productsReducer from "./ProductsReducer";
import cartReducer from "./CartReducer";

export default combineReducers({
    products: productsReducer,
    cart: cartReducer
});