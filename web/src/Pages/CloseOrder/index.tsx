import React, { useState, FormEvent } from 'react';
import PageHeader from '../PageHeader';
import { Button, TextField } from '@material-ui/core';

import './styles.css';
import api from '../../Service/api';

function CloseOrder() {
  const [invoice, setInvoice] = useState([]);
  const [order, setOrder] = useState([]);

  async function loadInvoice(e: FormEvent) {
    e.preventDefault();
    var orderId = order;

    const response = await api.get('Invoice', {
      params: {
        orderId,
      },
    });

    console.log(response.data);

    setInvoice(response.data);
  }

  return (
    <div>
      <PageHeader />
      <div>
        <form className='text-input' noValidate autoComplete='off'>
          <TextField
            id='standard-basic'
            label='Comanda'
            type='number'
            onChange={(e) => setOrder(e.target.value as any)}
          />
          <Button variant='contained' color='primary' onClick={loadInvoice}>
            Visualizar NF
          </Button>
        </form>
      </div>
    </div>
  );
}

export default CloseOrder;
