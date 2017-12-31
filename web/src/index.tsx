import * as React from 'react';
import { Provider } from 'react-redux'
import { getStore } from './store';
import * as ReactDOM from 'react-dom';
import App from './components/App';

ReactDOM.render(
    (
        <Provider store={getStore()}>
            <App />
        </Provider>
    ),
    document.getElementById('app_root')
);