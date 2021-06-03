import axios, { AxiosInstance, AxiosRequestConfig, AxiosPromise } from 'axios';

const client: AxiosInstance = axios.create({
  baseURL: 'http://localhost:8080/api',
});

const HttpRequest = (options: AxiosRequestConfig): AxiosPromise<unknown> => {
  const onSuccess = (response: any) => {
    console.debug('resquest successful!', response);
    return response.data;
  };

  const onError = (error: any) => {
    console.error('Request Failed:', error.config);
    if (error.response) {
      // Request was made but server responded with something
      // other than 2xx
      console.error('Status:', error.response.status);
      console.error('Data:', error.response.data);
      console.error('Headers:', error.response.headers);
    } else {
      // Something else happened while setting up the request
      // triggered the error
      console.error('Error Message:', error.message);
    }

    return Promise.reject(error.response || error.message);
  };

  return client(options)
    .then(onSuccess)
    .catch(onError);
};

export default HttpRequest;
