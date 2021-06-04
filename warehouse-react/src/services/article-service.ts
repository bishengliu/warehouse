// import Article from '../types/article';
import { AxiosPromise } from 'axios';
import httpService from './http-service';

// const articles: Article[] = [new Article('A1', 10, 10, 'description')];
const getAllArticles = (): AxiosPromise => httpService({
  url: '/Inventory',
  method: 'GET',
});

const getArticleById = (id: number): AxiosPromise => httpService({
  url: `/inventory/${id}`,
  method: 'GET',
});

const ArticleService = {
  getAllArticles,
  getArticleById,
};

export default ArticleService;
