import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import ProductList from './Pages/ProductList';
import CloseOrder from './Pages/CloseOrder';
import HomePage from './Pages/HomePage';

function Routes() {
  return (
    <BrowserRouter>
      <Route path='/' exact component={HomePage} />
      <Route path='/products' exact component={ProductList} />
      <Route path='/close-order' exact component={CloseOrder} />
    </BrowserRouter>
  );
}

export default Routes;
