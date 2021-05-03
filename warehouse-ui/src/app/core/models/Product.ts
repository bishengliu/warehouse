export class Product {
    id: number;
    name: string;
    description: string;
    articles: Array<ProductArticle>;
}

export class ProductArticle {
    id: number;
    name: string;
    amount: number;
    price: number;
}