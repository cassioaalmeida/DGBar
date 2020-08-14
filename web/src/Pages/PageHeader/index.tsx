import React from 'react';
import {
  AppBar,
  Toolbar,
  Typography,
  MenuItem,
  Button,
  Menu,
} from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';

import './styles.css';
import { NavLink } from 'react-router-dom';

function PageHeader() {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div>
      <AppBar position='static'>
        <Toolbar variant='dense'>
          <Button
            aria-controls='simple-menu'
            aria-haspopup='true'
            onClick={handleClick}
          >
            <MenuIcon />
          </Button>
          <Menu
            id='simple-menu'
            anchorEl={anchorEl}
            keepMounted
            open={Boolean(anchorEl)}
            onClose={handleClose}
          >
            <MenuItem onClick={handleClose}>
              <NavLink to='/'> Products </NavLink>
            </MenuItem>
            <MenuItem onClick={handleClose}>
              <NavLink to='/close-order'> Close Order </NavLink>
            </MenuItem>
          </Menu>
          <div className='pageName'>
            <Typography variant='h6' color='inherit'>
              Products
            </Typography>
          </div>
        </Toolbar>
      </AppBar>
    </div>
  );
}

export default PageHeader;
