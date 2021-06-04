import { combineReducers, Reducer } from 'redux';
import AppState from '../states/app-state';
import ArticleReducer from './article-reducers';

const RootReducer: Reducer<AppState> = combineReducers<AppState>({ articleState: ArticleReducer });

export default RootReducer;
