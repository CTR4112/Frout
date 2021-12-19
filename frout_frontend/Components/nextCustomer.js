import React from 'react';
import Button from 'react-bootstrap/Button';
import styled from 'styled-components';
import Geocode from "react-geocode";

const PadDiv = styled.div`    
    padding: 1rem;
    margin: 1rem; 
`;

export default function nextCustomer(props) {
    const [address, setAddress] = React.useState('');
    const googleMapsApiKey = props.googleMapsApiKey;

    Geocode.setApiKey(googleMapsApiKey);

    if (props.locations.length > 0) {
        const lastPlace = props.locations[0];

        Geocode.fromLatLng(lastPlace.latitude, lastPlace.longitude).then(
            (response) => {
                setAddress(response.results[0].formatted_address);
            },
            (error) => {
                console.error(error);
            }
        );
    }

    return (
        <div>
            <h3>Next Customer</h3>
            <p>Firstname: <br></br>
                { props.subscriptions[0].customer.firstName} </p>
            <p>Lastname: <br></br>
                { props.subscriptions[0].customer.lastName} </p>
            <p>Adress: <br></br>
                {address}</p>
            <hr></hr>

            <PadDiv>
                <Button variant="primary" className='m-3' onClick={() => props.removeLastPlaces()}>Delivered</Button>
                <Button variant="primary" className='m-3'> Skip</Button>
            </PadDiv>
        </div >
    );
}