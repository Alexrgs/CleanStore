import React from 'react';
import { Well, Col, Row, Button } from 'react-bootstrap';
import Img from 'react-image'

class ProductItem extends React.Component {
   
    render() {
        return (
            <Well>
                <Row>
                    <Col xs={12} className='productItem'>
                        <Img src={[this.props.product.productImgURL,'./img/No_image_3x4.svg']} alt={this.props.product.productName} height={100} />                         
                        <h4>{this.props.product.productName}</h4>
                        <p>{this.props.product.productDescription}</p>
                        <p>Price: $ {this.props.product.unitPrice}</p>
                        <Button onClick={() => this.props.handleOnAdd(this.props.product)} bsStyle='primary'>ADD</Button>
                    </Col>
                </Row>
            </Well>
        );
    }
}

export default ProductItem;