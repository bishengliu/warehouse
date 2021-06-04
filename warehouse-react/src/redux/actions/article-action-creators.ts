import { Action, ActionCreator } from 'redux';
import { ARTICLE_ACTION_CONSTRANTS as C } from './aricle-action-constants';
import { SetArticlesAction, SetSingleArticleAction } from './article-actions';
import Article from '../../types';
import store from '../store';
import ArticleService from '../../services/article-service';

const getAllArticlesActionCreatorAsync = () => (dispatch: typeof store.dispatch) : void => {
  ArticleService
    .getAllArticles()
    .then((res) => dispatch(getAllArticlesActionCreator(res.data)));
};

const getAllArticlesActionCreator: ActionCreator<SetArticlesAction> = (articles: Article[]) => (
  {
    type: C.ARTICLE_GET_ALL_ARTICLES,
    articles,
  }
);

const getSingleArticleActionCreatorAsync = (id: number) => (dispatch: typeof store.dispatch): void => {
  ArticleService
    .getArticleById(id)
    .then((res) => dispatch(getSingleSingleArticleActionCreator(res.data)));
};

const getSingleSingleArticleActionCreator: ActionCreator<SetSingleArticleAction> = (article: Article) => (
  {
    type: C.ARTICLE_GET_SINGLE_ARTICLE,
    article,
  }
);

const deleteSingleArticleActionCreator: ActionCreator<Action> = () => ({ type: C.ARTICLE_DELETE_SINGLE_ARTICLE });

const addSingleArticleActionCreator: ActionCreator<SetSingleArticleAction> = (article: Article) => (
  {
    type: C.ARTICLE_ADD_SINGLE_ARTICLE,
    article,
  }
);

const updateSingleArticleActionCreator: ActionCreator<SetSingleArticleAction> = (article: Article) => (
  {
    type: C.ARTICLE_UPDATE_SINGLE_ARTICLE,
    article,
  }
);

const addMultipleArticlesActionCreator: ActionCreator<SetArticlesAction> = (articles: Article[]) => (
  {
    type: C.ARTICLE_ADD_MULTTIPLE_ARTICLES,
    articles,
  }
);

export {
  getAllArticlesActionCreator,
  getAllArticlesActionCreatorAsync,
  getSingleSingleArticleActionCreator,
  getSingleArticleActionCreatorAsync,
  deleteSingleArticleActionCreator,
  addSingleArticleActionCreator,
  updateSingleArticleActionCreator,
  addMultipleArticlesActionCreator,
};
