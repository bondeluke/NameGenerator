import * as React from 'react';
import { connect } from 'react-redux';
import { dispatch, AppState } from '../store';

interface AppProps { count: number }

export const App = (props: AppProps) => (
    <div>
        <h1>You've clicked it {props.count} times</h1>
        <button onClick={e => dispatch({ type: 'click'})}>Click me!</button>
    </div>
);

var mapStateToProps = (state: AppState) => {
    return { count: state.count }
}

export default connect(mapStateToProps)(App);
// 'HelloProps' describes the shape of props.
// State is never set so we use the '{}' type.
//export class HelloClass extends React.Component<AppProps, {}> {
//    render() {
//        return <h1>Hello from {this.props.compiler} and {this.props.framework}!</h1>;
//    }
//}