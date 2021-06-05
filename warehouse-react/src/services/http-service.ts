import axios, {
  AxiosInstance, AxiosRequestConfig, AxiosPromise, AxiosError, AxiosResponse,
} from 'axios';
import axiosRetry from 'axios-retry';

const client: AxiosInstance = axios.create({
  baseURL: process.env.REACT_APP_API_BASE_URL,
});

axiosRetry(client, {
  retries: 3, // number of retries
  retryDelay: (retryCount) => {
    console.log(`retry attempt: ${retryCount}`);
    return retryCount * 2000; // time interval between retries
  },
});

// redirection
const redirectTo = (document: Document, path: string) => {
  document.location.href = path;
};

// handle success
const handleSuccess = (response: AxiosResponse) => {
  console.debug('resquest successful!', response);
  return response;
};

// handle errors
const handleErrors = (error: AxiosError) => {
  if (error && error.response) {
    // Request was made but server responded with something
    // other than 2xx
    console.error('Status:', error.response.status);
    console.error('Data:', error.response.data);
    console.error('Headers:', error.response.headers);

    switch (error.response.status) {
      case 404:
        redirectTo(document, '/');
        break;
      default:
        redirectTo(document, '/');
        break;
    }
  } else {
    // Something else happened while setting up the request
    // triggered the error
    console.error('Error Message:', error.message || 'unknown error!');
  }

  return Promise.reject(error.response || error.message || 'unknown error!');
};

client.interceptors.response.use(handleSuccess, handleErrors);

const httpService = (options: AxiosRequestConfig): AxiosPromise<unknown> => client(options);

export default httpService;
