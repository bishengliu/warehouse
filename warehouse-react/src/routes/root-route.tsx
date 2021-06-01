import React from 'react';
import {Route, Switch } from 'react-router-dom';
import {Home, Inventory, Product} from '../features';

const RootRoute = (props: any) => 

    <div className='app-content'>
        <Switch>
            <Route path='/' exact><Home /></Route>
            <Route path='/inventory' exact><Inventory /></Route>
            <Route path='/product' exact><Product /></Route>
        </Switch>
    </div>

export default RootRoute;