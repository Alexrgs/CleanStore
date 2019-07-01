import React from 'react';
import {Card, CardImg, CardText, CardBody, CardTitle, CardSubtitle, Button} from 'reactstrap';

class ProductItem extends React.Component {
   
    render() {
        return (
            <Card >
                <CardImg top  src={this.props.product.productImgURL} alt={this.props.product.productName} />
                <CardBody>
                    <CardTitle>{this.props.product.productName}</CardTitle>
                    <CardSubtitle>$ {this.props.product.unitPrice}</CardSubtitle>
                    <CardText>
                        {this.props.product.productDescription}
                    </CardText>
                    <Button onClick={() => this.props.handleOnAdd(this.props.product)} variant="primary">Buy</Button>
                </CardBody>
            </Card>
        );
    }
}

export default ProductItem;