import 'bootstrap/dist/css/bootstrap.css'
import React from 'react';
import ReactDOM from 'react-dom'
import { BrowserRouter } from 'react-router-dom'
import { createStore, applyMiddleware } from 'redux'
import { Provider } from 'react-redux'
import { createLogger } from 'redux-logger'
import thunk from 'redux-thunk'
import reducers from './reducers'
import { getAllProducts } from './actions/ProductsActions'
import App from './App';
//import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const middleware = [thunk];
if (process.env.NODE_ENV !== 'production') {
    middleware.push(createLogger());
}

const store = createStore(
    reducers,
    applyMiddleware(...middleware)
)

store.dispatch(getAllProducts());

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <Provider store={store}>
            <App />
        </Provider>
    </BrowserRouter>,
    rootElement);

// Uncomment the line above that imports the registerServiceWorker function
// and the line below to register the generated service worker.
// By default create-react-app includes a service worker to improve the
// performance of the application by caching static assets. This service
// worker can interfere with the Identity UI, so it is
// disabled by default when Identity is being used.
//
//registerServiceWorker();

