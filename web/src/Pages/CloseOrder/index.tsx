import React, { useState, FormEvent } from 'react';
import PageHeader from '../PageHeader';
import { Button, TextField } from '@material-ui/core';

import './styles.css';
import api from '../../Service/api';
import InvoiceItem, { Invoice } from '../InvoiceItem';

function CloseOrder() {
  const [invoice, setInvoice] = useState([]);
  const [order, setOrder] = useState([]);
  var response;
  var click = false;

  async function loadInvoice(e: FormEvent) {
    e.preventDefault();
    var orderId = order;

    response = await api.get('Invoice', {
      params: {
        orderId,
      },
    });
    click = true;
    console.log(click);

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
      <div>
        <InvoiceItem invoice={(invoice as unknown) as Invoice} />
      </div>
    </div>
  );
}

export default CloseOrder;
