import { Action } from 'redux';
import Article from '../../types';

export interface SetArticlesAction extends Action {
    articles: Article[];
}

export interface SetSingleArticleAction extends Action {
    article: Article;
}
