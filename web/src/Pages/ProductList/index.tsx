import React from 'react';
import Button from '@material-ui/core/Button';
import { Grid } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import PageHeader from '../PageHeader';
import ProductItem from '../ProductItem';

function ProductList() {
  return (
    <div>
      <PageHeader />

      <Grid
        container
        direction='row'
        justify='flex-start'
        alignItems='flex-start'
      >
        <ProductItem />
        <ProductItem />
        <ProductItem />
        <ProductItem />
        <ProductItem />
      </Grid>
    </div>
  );
}

export default ProductList;
