import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { Table, Spinner } from 'react-bootstrap';
import AppState from '../../redux/states/app-state';
import { getAllArticlesActionCreatorAsync } from '../../redux/actions/article-action-creators';

const Inventory = (): JSX.Element => {
  const [isLoaded, setIsLoaded] = useState(false);
  const articleState = useSelector((state: AppState) => state.articleState);
  const dispatch = useDispatch();

  const loadData = () => dispatch(getAllArticlesActionCreatorAsync());

  if (!isLoaded) {
    loadData();
    setIsLoaded(true);
  }

  return (
    <div>
      {
        !isLoaded && (
          <div className="text-left p-3">
            <Spinner animation="border" variant="secondary" />
            <span> loading...</span>
          </div>

        )
      }

      {
        articleState.articles.length === 0 && isLoaded
        && (
          <div>No article found!</div>
        )
      }

      { articleState.articles.length > 0 && isLoaded
        && (
          <Table responsive striped bordered hover variant="light">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Price</th>
                <th>Stock</th>
                <th>Description</th>
                <th>actions</th>
              </tr>
            </thead>
            <tbody>
              {
                articleState.articles.map((article) => (
                  <tr>
                    <td>
                      { article.id }
                    </td>
                    <td>
                      { article.name }
                    </td>
                    <td>
                      { article.price }
                    </td>
                    <td>
                      { article.stock }
                    </td>
                    <td>
                      { article.description }
                    </td>
                    <td>
                      <span>action</span>
                    </td>
                  </tr>
                ))
              }
            </tbody>
          </Table>
        )}
    </div>
  );
};

export default Inventory;
