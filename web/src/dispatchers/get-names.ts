import { dispatch } from '../store';

export function generateNames() {
    fetch('http://localhost/api/names')
        .then(resp => resp.json())
        .then(response => {
            dispatch({ type: 'names-returned', names: response });
    })
}