import React from 'react';
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux';
import { addToCart } from '../actions/CartActions'
import { Grid, Row, Col } from 'react-bootstrap';
import ProductItem from "./ProductItem";
import Cart from './Cart'

class ProductsList extends React.Component {
    dispachAddToCart(product) {
        this.props.addToCart(product);
    }
    renderProducts() {
        return (
            this.props.products.map((p) => {
                return (
                    <Col className='productsList' xs={12} sm={6} md={4} key={p.productId}>
                        <ProductItem handleOnAdd={this.dispachAddToCart.bind(this)} product={p} />
                    </Col>
                );
            })
        );
    }

    render() {
        return (
            <Grid>
                <Row><h1>Shopping Cart</h1></Row>
                <Row><Cart /></Row>
                <Row style={{ margin: '15px' }}>
                    {this.renderProducts()}
                </Row>
            </Grid>
        );
    }
}

function mapStateToProps(state) {
    return {
        products: state.products
    }
}
function mapActionsToProps(dispatch) {
    return bindActionCreators({
        addToCart
    }, dispatch);
}

export default connect(mapStateToProps, mapActionsToProps)(ProductsList);