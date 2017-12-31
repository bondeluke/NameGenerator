import * as Redux from 'redux';
import logger from 'redux-logger'

export interface AppState {
    count: number;
}

var defaultState: AppState = {
    count: 0
}

var rootReducer: Redux.Reducer<AppState> = (y: AppState, a: Redux.AnyAction) => {
    return { count: y.count + 1 }
};

var store = Redux.createStore(rootReducer, defaultState, Redux.applyMiddleware(logger));

export function dispatch(a: Redux.AnyAction) {
    store.dispatch(a);
}

export function getState() {
    return store.getState();
}

export function getStore() {
    return store;
}