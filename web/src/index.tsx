import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { App } from './components/App';

ReactDOM.render(
    <App count={0} />,
    document.getElementById('app_root')
);