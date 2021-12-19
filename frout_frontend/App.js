import React, { useState } from 'react'
import Nav from './Components/nav';
import Map from './Components/map';
import Menu from './Components/menu';
import AllDelivered from './Components/allDelivered';

import styled from 'styled-components';

import Button from 'react-bootstrap/Button';

const Main = styled.main`
    display: flex;
    flex-direction: row;
    padding: 1rem;
    justify-content: center;
    height: auto;
    width:100%;
`;

const Center = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;

export default function App(props) {
    const [view, setView] = React.useState('home');

    const [subscriptions, setSubscriptions] = React.useState([]);
    const [locations, setLocations] = React.useState([{ latitude: 37.7749, longitude: -122.4194 }, { latitude: 42.3601, longitude: -71.0589 }, { latitude: 40.7128, longitude: -74.0060 }, { latitude: 34.0522, longitude: -118.2437 }, { latitude: 41.8781, longitude: -87.629 }]);
    const [farmerName, setFarmerName] = useState("");

    const removeLastPlaces = () => {
        if (subscriptions.length >= 2) {
            setLocations(locations.slice(1));
            // Confirm Delivery to be done
            setSubscriptions(subscriptions.slice(1));
        } else {
            setView("allDelivered");
        }
    }

    const googleMapsApiKey = ''; // Your API key needs to be inserted here!

    React.useEffect(() => {
        fetch('https://localhost:5001/api/Subscriptions/1')
            .then(res => res.json())
            .then((data) => {
                setSubscriptions(data);
                let loc = [];
                data.forEach(subscription => {
                    loc.push(subscription.customer.location);
                });
                setLocations(loc);
                setFarmerName(data[0].farmer.firstName + " " + data[0].farmer.lastName);
            })
    }, []);

    return (
        <>
            <Nav setView={setView} />

            <Main>
                {view === 'map' &&
                    <>
                        <Map
                            googleMapURL={
                                'https://maps.googleapis.com/maps/api/js?key=' +
                                googleMapsApiKey +
                                '&libraries=geometry,drawing,places'
                            }
                            markers={locations || []}
                            loadingElement={<div style={{ height: `100% ` }} />}
                            containerElement={<div className='mx-5' style={{ height: "80vh", width: `70% ` }} />}
                            mapElement={<div style={{ height: `100% `, width: `100% ` }} />}
                            defaultCenter={{ lat: 25.798939, lng: -80.291409 }}
                            defaultZoom={11}
                        />
                        <Menu locations={locations} subscriptions={subscriptions} setSubscriptions={setSubscriptions} removeLastPlaces={removeLastPlaces} googleMapsApiKey={googleMapsApiKey}></Menu>
                    </>
                }
                {view === 'home' &&
                    <Center>
                        <div className='mt-3'>
                            <img
                                src={require('/images/home.png')}
                                height="250rem"

                                className="d-inline-block align-top"
                                alt="Frout Logo"
                            />
                        </div>

                        <hr></hr>
                        <h2><b>Welcome {farmerName}!</b></h2>
                        <h2><b>What do you want to do?</b></h2>
                        <hr></hr>
                        <Button style={{width: "110px"}} variant="success" onClick={() => setView('map')}>Routes</Button>
                        <hr></hr>
                        <Button style={{width: "110px"}} variant="success" onClick={() => setView('map')}>Main Menu</Button>
                        <hr></hr>
                        <Button style={{width: "110px"}} variant="success" onClick={() => setView('map')}>Log off</Button>
                    </Center>
                }
                {view === 'allDelivered' && <AllDelivered setView={setView} /> }
            </Main>
        </>
    );
}