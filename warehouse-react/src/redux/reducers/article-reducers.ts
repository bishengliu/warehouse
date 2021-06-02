import { Reducer, Action } from 'redux';
import { ArticleState } from '../states/article-state';
import { ARTICLE_ACTION_CONSTRANTS as C } from '../actions/aricle-action-constants';
import { SetArticlesAction } from '../actions/article-actions';

const initState: ArticleState = { articles: [] };

const ArticleReducer: Reducer<ArticleState> = (state: ArticleState = initState, action: Action): ArticleState => {
  switch (action.type) {
    case C.ARTICLE_GET_ALL_ARTICLES: {
      const { articles } = action as SetArticlesAction;
      return {
        ...state,
        articles,
      };
    }
    default:
      return state;
  }
};

export default ArticleReducer;
