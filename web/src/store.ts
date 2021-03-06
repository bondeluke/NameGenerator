import * as Redux from 'redux';
import logger from 'redux-logger'

export interface AppState {
    count: number;
    names: Array<string>;
}

var defaultState: AppState = {
    count: 0,
    names: []
}

var rootReducer: Redux.Reducer<AppState> = (y: AppState, a: Redux.AnyAction) => {
    if (a.type === "@@redux/INIT")
        return defaultState;

    return { count: y.count + 1, names: a.names }
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