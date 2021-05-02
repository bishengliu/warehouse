# Warehouse application

A simple .Net Core backend application for warehouse. 

# start application

- install [Docker Compise](https://docs.docker.com/compose/install/);
- run `docker-compose up -id` in the root of the application folder, where `docker-compose.yml` is located;
- endpoint **documentation**: [http://localhost:8080](http://localhost:8080/)
- backend api basic **healthcheck** endpoint: [http://localhost:8080/health](http://localhost:8080/health)

# Project file structure

| Folder/File                                   | Description |
| -------------                                 |:-------------:|
| warehouse-api                                 | contains all the source code for backend api |
| warehouse-api/src/Warehouse.API               | .net core webapi application |
| warehouse-api/src/Warehouse.Entities          | entity/database design |
| warehouse-api/src/Warehouse.Entities          | entity/database design |
| warehouse-api/src/Warehouse.Services          | warehouse services |
| warehouse-api/tests/Warehouse.ServiceTests    | unit tests for warehouse services |
| docker-compose.yml                            | bring up api and mssql as docker containers |
| dockerfiles                                   | dockerfiles, env and db init script |
| dockerfiles/api.Dockerfile                    | api docker file |
| dockerfiles/demo.env                          | env for api server |
| dockerfiles/mssql.Dockerfile                  | mssql server dockerfile |
| dockerfiles/db                                | mssql init script |

# Endpoint brief description
| Endpoint | HttpMethod| Description|
| ------------- | ------------- |:-------------:|
| /api/Inventory | GET | get all articles|
| /api/Inventory/{id} | GET | get one article|
| /api/Inventory | POST | add a new article|
| /api/Inventory/upload | POST | add articles vai file (json) upload |
| /api/Inventory/{id} | PUT | update an article|
| /api/Products | GET | get all products |
| /api/Products/{id} | GET | get one product |
| /api/Products | POST | add a new product |
| /api/Products/{id} | PUT | update a product |
| /api/Products/{id} | DELETE | delete a product |
| /api/Products | POST | add a new product |
| /api/Products/sell | POST | sell a product and update inventory/article |
| /api/Products/upload | POST | add products via file (json) upload |
| /api/Products/stocks | GET | get stock info for all product |
| /api/Products/stocks/{id} | GET | get a product stock info |


# database design
![warehouse db](./db_diagram.png)


# file upload specification
- you can upload a json file containing the articles via [http://localhost:8080/api/Inventory/upload](http://localhost:8080/api/Inventory/upload). The json file is expected to have the following structure: 


```json
{
  "inventory": [
    {
      "art_id": "1",
      "name": "leg",
      "stock": "12"
    },
    {
      "art_id": "2",
      "name": "screw",
      "stock": "17"
    },
    {
      "art_id": "3",
      "name": "seat",
      "stock": "2"
    },
    {
      "art_id": "4",
      "name": "table top",
      "stock": "1"
    }
  ]
}
````

- you can upload a json file containing the products via [http://localhost:8080/api/Products/upload](http://localhost:8080/api/Products/upload). The json file is expected to have the following structure (all the articles in the product must be predefind in warehouse): 

```json
{
  "products": [
    {
      "name": "Dining Chair",
      "contain_articles": [
        {
          "art_id": "1",
          "amount_of": "4"
        },
        {
          "art_id": "2",
          "amount_of": "8"
        },
        {
          "art_id": "3",
          "amount_of": "1"
        }
      ]
    },
    {
      "name": "Dinning Table",
      "contain_articles": [
        {
          "art_id": "1",
          "amount_of": "4"
        },
        {
          "art_id": "2",
          "amount_of": "8"
        },
        {
          "art_id": "4",
          "amount_of": "1"
        }
      ]
    }
  ]
}

```



## DESIGN

####    Serverless or monolithic

#### application design
- frontend(REACT) plus backend (RESTful api)

#### features


#### SQL vs NON-SQL

#### db design


#### deployment


#### scalability


#### points of furture improvement


