import {
  createStore, applyMiddleware, compose, Store, StoreEnhancer, Middleware, AnyAction,
} from 'redux';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import { composeWithDevTools } from 'redux-devtools-extension';
import AppState from './states/app-state';
import RootReducer from './reducers/root-reducer';

const middlewares: Middleware[] = [
  thunk,
  logger,
];
const middlewareEnhancers: StoreEnhancer<any, any> = applyMiddleware(...middlewares);

const storeEnhancers: any[] = [];

const composedEnhancers: StoreEnhancer<Store<AppState, AnyAction>, unknown> = compose(
  composeWithDevTools(middlewareEnhancers), ...storeEnhancers,
);

const store: Store<AppState> = createStore(RootReducer, undefined, composedEnhancers);

export default store;
