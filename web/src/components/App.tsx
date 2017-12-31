import * as React from 'react';
import { dispatch } from '../store';

interface AppProps { count: number }

export const App = (props: AppProps) => (
    <div>
        <h1>You've clicked it {props.count} times</h1>
        <button onClick={e => dispatch({ type: 'click'})}>Click me!</button>
    </div>
);
// 'HelloProps' describes the shape of props.
// State is never set so we use the '{}' type.
//export class HelloClass extends React.Component<AppProps, {}> {
//    render() {
//        return <h1>Hello from {this.props.compiler} and {this.props.framework}!</h1>;
//    }
//}