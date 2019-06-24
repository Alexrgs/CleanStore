import React from 'react';
import { Col, Row, Panel, Button, Label, Badge } from 'react-bootstrap';

class CartItem extends React.Component {

    render() {
        return (
            <Panel >
                <Row>
                    <Col xs={12} sm={6}>
                        <h5>{this.props.cartItem.productName} <Badge pullRight>Price: $ {this.props.cartItem.unitPrice}</Badge></h5>
                    </Col>
                    <Col xs={6} sm={4}>
                        <p>Quantity :&nbsp;
                            <Label bsStyle='success'> {this.props.cartItem.quantity} </Label>
                            &nbsp;
                            <Button bsSize='small' onClick={() => this.props.onAddUnit()}>+</Button>
                            <Button bsSize='small' onClick={() => this.props.onDeductUnit()}>-</Button>
                        </p>
                    </Col>
                    <Col xs={6} sm={2}>
                        <Button onClick={() => this.props.handleDeleteFromCart()}
                            bsSize='small' bsStyle='danger'>Remove</Button>
                    </Col>
                    <Col xs={6} sm={2}>
                        <p> Subtotal: $ {this.props.cartItem.unitPrice * this.props.cartItem.quantity} </p>
                    </Col>
                </Row>
            </Panel>
        );
    }
}

export default CartItem;