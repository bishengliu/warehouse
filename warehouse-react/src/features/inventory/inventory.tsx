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
    console.log(articleState.articles);
    setIsLoaded(true);
  }

  return <div>inventory</div>;
};

export default Inventory;
