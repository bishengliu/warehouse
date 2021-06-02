// import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';

// export const store = configureStore({
//   reducer: { },
// });

// export type AppDispatch = typeof store.dispatch;
// export type RootState = ReturnType<typeof store.getState>;
// export type AppThunk<ReturnType = void> = ThunkAction<
//   ReturnType,
//   RootState,
//   unknown,
//   Action<string>
// >;

import {
  createStore, applyMiddleware, compose, Store, StoreEnhancer, Middleware, AnyAction,
} from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import AppState from './states/app-state';
import RootReducer from './reducers/root-reducer';

const middlewares: Middleware[] = [];
const middlewareEnhancers: StoreEnhancer<any, any> = applyMiddleware(...middlewares);

const storeEnhancers: any[] = [];

const composedEnhancers: StoreEnhancer<Store<AppState, AnyAction>, unknown> = compose(
  composeWithDevTools(middlewareEnhancers), ...storeEnhancers,
);

const store: Store<AppState> = createStore(RootReducer, undefined, composedEnhancers);

export default store;
