import React, { FormEvent } from 'react';

import {
  Grid,
  TableCell,
  TableHead,
  TableRow,
  TableContainer,
  Paper,
  Table,
  TableBody,
  Button,
} from '@material-ui/core';
import api from '../../Service/api';
import './styles.css';
import { useHistory } from 'react-router-dom';

export interface Products {
  productId: number;
  name: string;
  price: number;
  quantity: number;
}
export interface Invoice {
  orderId: number;
  price: number;
  discount: number;
  products: Products[];
}
interface InvoiceProps {
  invoice: Invoice;
}

const InvoiceItem: React.FC<InvoiceProps> = ({ invoice }) => {
  const history = useHistory();
  function closeOrder(e: FormEvent) {
    e.preventDefault();

    var orderId = invoice.orderId;

    api
      .post('Invoice', {
        orderId,
        headers: {
          Authorization: 'Bearer ' + globalThis.token,
        },
      })
      .then(() => {
        alert('Comanda fechada com sucesso');
      })
      .catch(function (error) {
        console.log(error);
        if (error.response) {
          alert(error.response.data);
        } else if (error.message) {
          alert(error.message);
        } else alert(error);
      });
  }

  const resetOrder = (e: FormEvent) => {
    e.preventDefault();

    var orderId = invoice.orderId;

    api
      .delete('Request', {
        data: {
          orderId: orderId,
        },
        headers: {
          Authorization: 'Bearer ' + globalThis.token,
        },
      })
      .then(() => {
        alert('Comanda resetada com sucesso');
        history.push('/products');
      })
      .catch(function (error) {
        alert('Comanda já está fechada, não é possivel resetar');
      });
  };

  return (
    <div>
      {invoice.products && invoice.products.length > 0 && (
        <div className='item-container'>
          <Button variant='contained' color='primary' onClick={closeOrder}>
            Fechar Comanda
          </Button>
          <Button variant='contained' color='primary' onClick={resetOrder}>
            Resetar Comanda
          </Button>
          <Grid
            container
            direction='column'
            justify='center'
            alignItems='stretch'
          >
            <TableContainer component={Paper}>
              <Table className='table' size='small' aria-label='a dense table'>
                <TableHead>
                  <TableRow>
                    <TableCell>Product</TableCell>
                    <TableCell align='right'>Quantity</TableCell>
                    <TableCell align='right'>Price {' (R$)'}</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {invoice.products &&
                    invoice.products.map((item) => (
                      <TableRow key={item.productId}>
                        <TableCell component='th' scope='row'>
                          {item.name}
                        </TableCell>
                        <TableCell align='right'>{item.quantity}</TableCell>
                        <TableCell align='right'>
                          {Intl.NumberFormat('pt-BR', {
                            style: 'currency',
                            currency: 'BRL',
                          }).format(item.price)}
                        </TableCell>
                      </TableRow>
                    ))}
                  <TableRow>
                    <TableCell>
                      <b>Sub total</b>
                    </TableCell>
                    <TableCell align='right'></TableCell>
                    <TableCell align='right'>
                      {Intl.NumberFormat('pt-BR', {
                        style: 'currency',
                        currency: 'BRL',
                      }).format(invoice.price)}
                    </TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>
                      <b>Desconto</b>
                    </TableCell>
                    <TableCell align='right'></TableCell>
                    <TableCell align='right'>
                      {Intl.NumberFormat('pt-BR', {
                        style: 'currency',
                        currency: 'BRL',
                      }).format(invoice.discount)}
                    </TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>
                      <b>Total</b>
                    </TableCell>
                    <TableCell align='right'></TableCell>
                    <TableCell align='right'>
                      {Intl.NumberFormat('pt-BR', {
                        style: 'currency',
                        currency: 'BRL',
                      }).format(invoice.price - invoice.discount)}
                    </TableCell>
                  </TableRow>
                </TableBody>
              </Table>
            </TableContainer>
          </Grid>
        </div>
      )}
    </div>
  );
};

export default InvoiceItem;
