import * as React from 'react';

interface AppProps { compiler: string; framework: string; }

export const App = (props: AppProps) => <h1>Hello from {props.compiler} and {props.framework}!</h1>;

// 'HelloProps' describes the shape of props.
// State is never set so we use the '{}' type.
export class HelloClass extends React.Component<AppProps, {}> {
    render() {
        return <h1>Hello from {this.props.compiler} and {this.props.framework}!</h1>;
    }
}