import React, { useState, useEffect } from 'react';
import { Grid, TextField } from '@material-ui/core';
import PageHeader from '../PageHeader';
import ProductItem, { Product } from '../ProductItem';
import api from '../../Service/api';

import './styles.css';
import { Redirect } from 'react-router-dom';

function ProductList() {
  const [products, setProducts] = useState([]);
  const [order, setOrder] = useState([]);

  useEffect(() => {
    searchProducts();
  }, []);

  async function searchProducts() {
    const response = await api.get('Products', {
      headers: {
        Authorization: 'Bearer ' + globalThis.token,
      },
    });
    setProducts(response.data);
  }
  if (!globalThis.token) return <Redirect to='/'></Redirect>;
  else
    return (
      <div>
        <PageHeader />
        <form className='text-input' noValidate autoComplete='off'>
          <TextField
            id='standard-basic'
            label='Comanda'
            type='number'
            onChange={(e) => setOrder(e.target.value as any)}
          />
        </form>

        <Grid
          container
          direction='row'
          justify='flex-start'
          alignItems='flex-start'
        >
          {products.map((product: Product) => {
            return (
              <ProductItem
                key={product.id}
                product={product}
                order={order as any}
              />
            );
          })}
        </Grid>
      </div>
    );
}

export default ProductList;
