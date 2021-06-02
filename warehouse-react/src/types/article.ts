class Article {
    id = 0;

    name: string;

    price: number;

    stock: number;

    description: string;

    constructor(name: string, price: number, stock: number, description: string) {
      this.name = name;
      this.price = price;
      this.stock = stock;
      this.description = description;
    }
}

export default Article;
