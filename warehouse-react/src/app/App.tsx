import React from 'react';
import { Footer, NavBar } from '../components';
import RootRoute from '../routes';
import './app.css';

const App = (): JSX.Element => (
  <div className="app">
    <NavBar />
    <RootRoute />
    <Footer />
  </div>
);

export default App;
