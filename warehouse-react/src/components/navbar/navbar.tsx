import React from 'react';
import { Link } from 'react-router-dom';
import './navbar.css';

const NavBar = () => 
<div>
    <Link to='/home'>Home</Link>
    <Link to='/inventory'>Inventory</Link>
    <Link to='/product'>Product</Link>
</div>

export default NavBar;