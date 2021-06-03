import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
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
  console.log(articleState.articles);
  return (
    <div>
      inventory:
      { articleState.articles.length }
    </div>
  );
};

export default Inventory;
