import React from 'react';
import styled from 'styled-components';
import NextCustomer from './nextCustomer';
import CustomerList from './customerList';

const Container = styled.div`    
    padding: 1rem;
    margin: 1rem;
    display:flex;
    flex-direction: column;
`;

export default function Menu(props) {
    return (
        <>
            <Container>
            <NextCustomer googleMapsApiKey={props.googleMapsApiKey} locations={props.locations} subscriptions={props.subscriptions} setSubscriptions={props.setSubscriptions} removeLastPlaces={props.removeLastPlaces}></NextCustomer>
                <CustomerList locations={props.locations} subscriptions={props.subscriptions}></CustomerList>
            </Container>
        </>
    );
}