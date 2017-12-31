import * as React from 'react';
import { connect } from 'react-redux';
import { dispatch, AppState } from '../store';

interface NameProps {
    names: Array<string>
}

export const Names = (props: NameProps) => (
    <div>
        {
            props.names.map(n => (<div key={n}>{n}</div>))
        }
    </div>
);

var mapStateToProps = (state: AppState): NameProps => {
    return { names: state.names }
}

export default connect(mapStateToProps)(Names);