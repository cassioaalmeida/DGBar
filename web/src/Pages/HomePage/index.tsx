import React from 'react';
import PageHeader from '../PageHeader';
import { Button } from '@material-ui/core';
import api from '../../Service/api';
import './styles.css';
import { useHistory } from 'react-router-dom';

function HomePage() {
  const history = useHistory();
  async function authorize() {
    api
      .post('Auth', {})
      .then((response) => {
        console.log(response.data.token);
        globalThis.token = response.data.token;
        history.push('/products');
      })
      .catch(function (error) {
        if (error.response) {
          alert(error.response.data);
        } else if (error.message) {
          alert(error.message);
        } else alert(error);
      });
  }
  return (
    <div>
      <PageHeader />
      <div className='Home-Form'>
        <Button onClick={authorize} variant='contained' color='primary'>
          Authenticate
        </Button>
      </div>
    </div>
  );
}

export default HomePage;
