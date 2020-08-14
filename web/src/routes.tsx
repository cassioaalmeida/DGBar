import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import ProductList from './Pages/ProductList';
import CloseOrder from './Pages/CloseOrder';

function Routes() {
  return (
    <BrowserRouter>
      <Route path='/' exact component={ProductList} />
      <Route path='/close-order' exact component={CloseOrder} />
    </BrowserRouter>
  );
}

export default Routes;
