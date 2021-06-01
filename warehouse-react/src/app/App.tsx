import React from 'react';
import { Footer, NavBar } from '../components';
import RootRoute from '../routes';
import './app.css';

const App = () => 
<div className='app'>
    <NavBar />
    <RootRoute />
    <Footer />
</div>

export default App;
