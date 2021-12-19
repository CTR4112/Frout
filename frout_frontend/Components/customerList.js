import React from 'react';
import styled from 'styled-components';

const CustomerList = styled.div`    
    color:gray;
`;

export default function customerList(props) {
    return (
        <CustomerList>
            <h3>Outstanding deliveries: ({props.subscriptions.length} remaining)</h3>
            <ul>
                {
                    props.subscriptions.slice(1).map((sub, index) =>
                        <li key={index}>Name: {sub.customer.firstName} {sub.customer.lastName}
                        </li>)
                }
            </ul>
        </CustomerList >
    );
}