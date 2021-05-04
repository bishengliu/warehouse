export interface Product {
    id: number;
    name: string;
    description: string;
    articles: Array<ProductArticle>;
}

export interface ProductArticle {
    id: number;
    name: string;
    amount: number;
    price: number;
}