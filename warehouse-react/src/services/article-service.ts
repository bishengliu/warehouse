// import Article from '../types/article';
import httpService from './http-service';

// const articles: Article[] = [new Article('A1', 10, 10, 'description')];
const get = () => httpService({
  url: '/inventory',
  method: 'GET',
});

const ArticleService = {
  get,
};

export default ArticleService;
