import React, { FormEvent, useState } from 'react';

import './styles.css';
import { Button, Grid, Typography } from '@material-ui/core';
import api from '../../Service/api';

export interface Product {
  id: string;
  name: string;
  price: number;
}
interface ProductItemProps {
  product: Product;
  order: number;
}

const ProductItem: React.FC<ProductItemProps> = ({ product, order }) => {
  function addProductToOrder(e: FormEvent) {
    e.preventDefault();
    var orderId = order;
    var productId = parseInt(product.id);

    console.log(orderId);
    console.log(productId);

    api
      .post('Request', {
        orderId,
        productId,
      })
      .then(() => {
        alert('Produto inserido na comanda');
      })
      .catch(function (error) {
        if (error.response) {
          console.log(error.response.data);
          alert(error.response.data);
        } else {
          alert(error.message);
        }
      });
  }

  return (
    <div id='product-item'>
      <Grid container direction='column' justify='center' alignItems='stretch'>
        <img
          src='https://img.icons8.com/carbon-copy/100/000000/no-image.png'
          alt=''
        />
        <Typography className='price-label' variant='h6' color='inherit'>
          {product.name}
        </Typography>
        <Typography className='price-label' variant='h6' color='inherit'>
          Preço R$ {product.price},00
        </Typography>
        <Button onClick={addProductToOrder} variant='contained' color='primary'>
          Adicionar
        </Button>
      </Grid>
    </div>
  );
};

export default ProductItem;
