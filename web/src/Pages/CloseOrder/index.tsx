import React from 'react';
import PageHeader from '../PageHeader';
import { Button, TextField } from '@material-ui/core';

function CloseOrder() {
  return (
    <div>
      <PageHeader />
      <div>
        <form className='text-input' noValidate autoComplete='off'>
          <TextField id='standard-basic' label='Comanda' type='number' />
        </form>
        <Button variant='contained' color='primary'>
          Visualizar NF
        </Button>
      </div>
    </div>
  );
}

export default CloseOrder;
