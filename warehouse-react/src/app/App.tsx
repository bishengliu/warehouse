import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import { Footer, NavBar } from '../components';
import RootRoute from '../routes';
import './app.css';

const App = () => 
<div className='app'>
  <BrowserRouter>
    <NavBar />
    <RootRoute />
    <Footer />
  </BrowserRouter> 
</div>

export default App;
