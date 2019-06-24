﻿import React from 'react';
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux';
import { deleteFromCart, updateItemQuantity, checkOut } from '../actions/CartActions';
import { Col, Row, Panel, Badge, Button } from 'react-bootstrap';
import CartItem from "./CartItem";
import { CartClient } from '../api/ApiClients';

class Cart extends React.Component {
    
    componentDidMount() {
        new CartClient().get().then(p => {
            this.setState({ cart: p.items });
        });
    }
    renderCart() {
        return (
            <Panel className='cartList' header='' bsStyle='primary'>
                {this.cartList()}
                <Row>
                    <Col xs={12} sm={6}>
                        <Button onClick={() => this.props.handleCheckOut()}
                            bsSize='small' bsStyle='danger'>Checkout</Button>
                    </Col>
                </Row>
            </Panel>
        );
    }
    handleDeleteFromCart(productId) {
        this.props.deleteFromCart({ productId })
    }
    handleDeductUnit(productId) {
        let quantity = -1;
        this.props.updateItemQuantity({ productId, quantity })
    }
    handleAddUnit(productId) {
        let quantity = 1;
        this.props.updateItemQuantity({ productId, quantity })
    }
    handleCheckOut() {
        this.props.checkOut()
    }


    cartList() {
        return (
            this.props.cart.map(cartItem => {
                return (
                    <CartItem key={cartItem.productId}
                        cartItem={cartItem}
                        onAddUnit={this.handleAddUnit.bind(this, cartItem.productId)}
                        onDeductUnit={this.handleDeductUnit.bind(this, cartItem.productId)}
                        handleDeleteFromCart={this.handleDeleteFromCart.bind(this, cartItem.productId)} />
                );
            })
        );
    }

    cartTotal() {
        return (
            <Panel>
                <Row>
                    <Col xs={12} sm={6}>
                        <h4>TOTAL: <Badge pullRight>$ {this.totalAmount(this.props.cart)}</Badge></h4>
                    </Col>
                </Row>
            </Panel>
        );
    }
    totalAmount(cartArray) {
        return cartArray.reduce((acum, item) => {
            acum += item.unitPrice * item.quantity;
            return acum;
        }, 0);
    }

    render() {
        if (this.props.cart.length !== 0) {
            return (
                <asproductIde className='cart'>
                    {this.renderCart()}
                    {this.cartTotal()}
                </asproductIde>
            );
        }

        return (
            <asproductIde className='cart'>cart empty</asproductIde>
        );
    }
}

function mapStateToProps(state) {
    return {
        cart: state.cart
    }
}
function mapActionsToProps(dispatch) {
    return bindActionCreators({
        deleteFromCart,
        updateItemQuantity
    }, dispatch);
}

export default connect(mapStateToProps, mapActionsToProps)(Cart);