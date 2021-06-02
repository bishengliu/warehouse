import { Action, ActionCreator } from 'redux';
import { ARTICLE_ACTION_CONSTRANTS as C } from './aricle-action-constants';
import { SetArticlesAction, SetSingleArticleAction } from './article-actions';
import Article from '../../types';
import store from '../store';

const getAllArticlesActionCreatorAsync = () => (dispatch: typeof store.dispatch) => {
  const articles: Article[] = [new Article('A1', 10, 10, 'description')];

  dispatch(getAllArticlesActionCreator(articles));
};

const getAllArticlesActionCreator: ActionCreator<SetArticlesAction> = (articles: Article[]) => (
  {
    type: C.ARTICLE_GET_ALL_ARTICLES,
    articles,
  }
);

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
  deleteSingleArticleActionCreator,
  addSingleArticleActionCreator,
  updateSingleArticleActionCreator,
  addMultipleArticlesActionCreator,
};
