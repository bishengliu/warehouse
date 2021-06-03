// import Article from '../types/article';
import HttpRequest from './http-request';

// const articles: Article[] = [new Article('A1', 10, 10, 'description')];
const get = () => HttpRequest({
  url: '/inventory',
  method: 'GET',
});

const ArticleService = {
  get,
};

export default ArticleService;
